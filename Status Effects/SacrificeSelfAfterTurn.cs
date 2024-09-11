using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class SacrificeSelfAfterTurn
    {
        public const string name = "Sacrifice Self After Turn";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectSacrificeSelfAfterTurn>(
                    name,
                    "Sacrifice self"
                );
        }
    }
}