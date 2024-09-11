using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class WhenAnyCounterReachesZeroCountDownSelf
    {
        public const string name = "Count Down Self When Any Counter Reaches Zero";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXWhenAnyCounterReachesZero>(
                name,
                "Count down by <{a}> when any <keyword=counter> reaches 0",
                canStack: true,
                canBoost: true,
                effectToApply: "Reduce Counter",
                applyToFlags: ApplyToFlags.Self);
        }
    }
}