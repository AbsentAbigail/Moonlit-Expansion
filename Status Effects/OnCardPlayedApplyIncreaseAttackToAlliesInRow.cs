using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnCardPlayedApplyIncreaseAttackToAlliesInRow
    {
        public const string name = "On Card Played Apply Increase Attack To Allies In Row";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnCardPlayed>(
                name,
                "Increase <keyword=attack> of allies in row by <{a}>",
                canBoost: true,
                canStack: true,
                effectToApply: "Increase Attack",
                applyToFlags: ApplyToFlags.AlliesInRow);
        }
    }
}