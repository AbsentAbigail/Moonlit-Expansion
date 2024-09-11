using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class Survivor
    {
        public const string name = "Survivor";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectSurvivor>(
                    name
                );
        }
    }
}