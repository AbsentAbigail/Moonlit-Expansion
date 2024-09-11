using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnTurnApplyBomToAllEnemies
    {
        public const string name = "On Turn Apply Weakness To All Enemies";
        
        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnTurn>(
                    name,
                    "Apply <{a}> <keyword=weakness> to all enemies",
                    canBoost: true,
                    canStack: true,
                    effectToApply: "Weakness",
                    applyToFlags: ApplyToFlags.Enemies
                );
        }
    }
}