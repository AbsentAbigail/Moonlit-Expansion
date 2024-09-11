using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class AfterCardPlayedAddFrenzyToSelf
    {
        public const string name = "After Card Played Add Frenzy To Self";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXAfterCardPlayed>(
                name,
                "Gain <{a}><keyword=frenzy> after use",
                true,
                true,
                "MultiHit",
                StatusEffectApplyX.ApplyToFlags.Self);
        }
    }
}