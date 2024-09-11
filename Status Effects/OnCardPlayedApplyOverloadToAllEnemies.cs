using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnCardPlayedApplyOverloadToAllEnemies
    {
        public const string name = "On Card Played Apply Overload To All Enemies";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnCardPlayed>(
                name,
                "Apply <{a}><keyword=overload> to all enemies",
                true,
                true,
                "Overload",
                StatusEffectApplyX.ApplyToFlags.Enemies);
        }
    }
}