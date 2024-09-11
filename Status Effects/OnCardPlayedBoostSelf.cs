using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnCardPlayedBoostSelf
    {
        public const string name = "On Card Played boost Self";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnCardPlayed>(
                name,
                "Boost own effect by {a}",
                canStack: true,
                effectToApply: "Increase Effects",
                applyToFlags: StatusEffectApplyX.ApplyToFlags.Self);
        }
    }
}