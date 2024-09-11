using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class TriggerBeforeEnemyAttacks
    {
        public const string name = "Trigger Before Enemy Attacks";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectTriggerBeforeEnemyAttacks>(
                    name,
                    "Trigger before an enemy attacks"
                );
        }
    }
}