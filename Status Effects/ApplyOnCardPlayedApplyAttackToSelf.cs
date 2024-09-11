using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class ApplyOnCardPlayedApplyAttackToSelf
    {
        public const string name = "Apply On Card Played Increase Attack To Self";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectInstantApplyEffectAndUpdateDescription>(
                name,
                "Apply Gain <+{a}><keyword=attack>",
                true,
                true)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectInstantApplyEffectAndUpdateDescription;
                    status.effectToApply = MoonlitExpansion.TryGet<StatusEffectData>("On Card Played Apply Attack To Self");
                });
        }
    }
}