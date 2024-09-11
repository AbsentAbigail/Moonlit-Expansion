using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnTurnApplyFrostToAllEnemies
    {
        public const string name = "On Turn Apply Frost To All Enemies";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnTurn>(
                    name,
                    text: "Apply <{a}> <keyword=frost> to all enemies",
                    canBoost: true,
                    canStack: true,
                    effectToApply: "Frost",
                    applyToFlags: ApplyToFlags.Enemies
                );
        }
    }
}