using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class StatusEffectHelper
    {
        public static StatusEffectDataBuilder DefaultStatusBuilder<T>(
            string name,
            string text = null,
            bool canBoost = false,
            bool canStack = false) where T : StatusEffectData
        {
            var status = new StatusEffectDataBuilder(MoonlitExpansion.Instance)
                .Create<T>(name)
                .WithCanBeBoosted(canBoost)
                .WithStackable(canStack);

            if (text != null)
                status.WithText(text);

            return status;
        }

        public static StatusEffectDataBuilder DefaultApplyXBuilder<T>(
            string name,
            string text = null,
            bool canBoost = false,
            bool canStack = false,
            string effectToApply = "Snow",
            ApplyToFlags applyToFlags = ApplyToFlags.None) where T : StatusEffectApplyX
        {
            return DefaultStatusBuilder<T>(name, text, canBoost, canStack)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as T;

                    status.effectToApply = MoonlitExpansion.TryGet<StatusEffectData>(effectToApply);
                    status.applyToFlags = applyToFlags;
                });
        }
    }
}