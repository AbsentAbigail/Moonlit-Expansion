using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;

namespace Moonlit_Expansion.Helpers
{
    internal static class CardUpgradeHelper
    {
        public static CardUpgradeDataBuilder Charm(string name, string title, string text, Pools pool = Helpers.Pools.General)
        {
            return new CardUpgradeDataBuilder(MoonlitExpansion.Instance)
                .Create(name)
                .WithType(CardUpgradeData.Type.Charm)
                .WithImage($"{name}.png")
                .WithTitle(title)
                .WithText(text)
                .WithPools(Pools(pool));
        }

        public static CardUpgradeDataBuilder SwapEffectsCharm(string name, string title,
            string effect1, string keyword1, string effect2, string keyword2,
            Pools pool = Helpers.Pools.General)
        {
            return Charm(name, title, $"Replace <keyword={keyword1}> with <keyword={keyword2}> and vice versa", pool)
                .SetConstraints(
                    TargetConstraintHelper.Or(
                        name: $"Has Effects Based On {effect1} Or {effect2}",
                        not: false,
                        TargetConstraintHelper.HasEffectBasedOn(effect1),
                        TargetConstraintHelper.HasEffectBasedOn(effect2)
                    ),
                    TargetConstraintHelper.And(
                        name: $"Does Not Have Effects Based On {effect1} Or {effect2}",
                        not: true,
                        TargetConstraintHelper.HasEffectBasedOn(effect1),
                        TargetConstraintHelper.HasEffectBasedOn(effect2)
                    )
                )
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    StatusEffectData statusA = MoonlitExpansion.TryGet<StatusEffectData>(effect1);
                    StatusEffectData statusB = MoonlitExpansion.TryGet<StatusEffectData>(effect2);

                    CardScriptSwapEffectsBasedOnOrGenerate script = ScriptableHelper.CreateScriptable<CardScriptSwapEffectsBasedOnOrGenerate>($"{name} Script");
                    script.statusA = statusA;
                    script.statusB = statusB;
                    script.keywordA = keyword1;
                    script.keywordB = keyword2;
                    data.scripts = [script];
                });
        }

        public static string[] Pools(Pools pool)
        {
            string[] pools = [];

            if (pool.HasFlag(Helpers.Pools.General))
                pools = pools.AddToArray("GeneralCharmPool");

            if (pool.HasFlag(Helpers.Pools.Snowdweller))
                pools = pools.AddToArray("BasicCharmPool");

            if (pool.HasFlag(Helpers.Pools.Shademancer))
                pools = pools.AddToArray("MagicCharmPool");

            if (pool.HasFlag(Helpers.Pools.Clunkmaster))
                pools = pools.AddToArray("ClunkCharmPool");

            return pools;
        }

        public static CardUpgradeDataBuilder IsGeneralPool(this CardUpgradeDataBuilder builder)
        {
            return builder.AddPool("GeneralCharmPool");
        }

        public static CardUpgradeDataBuilder IsSnowdwellerPool(this CardUpgradeDataBuilder builder)
        {
            return builder.AddPool("BasicCharmPool");
        }

        public static CardUpgradeDataBuilder IsShademancerPool(this CardUpgradeDataBuilder builder)
        {
            return builder.AddPool("MagicCharmPool");
        }

        public static CardUpgradeDataBuilder IsClunkmasterPool(this CardUpgradeDataBuilder builder)
        {
            return builder.AddPool("ClunkCharmPool");
        }
    }
}