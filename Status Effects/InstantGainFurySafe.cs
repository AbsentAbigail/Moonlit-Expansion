using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class InstantGainFurySafe
    {
        public const string name = "Instant Gain Fury Safe";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectSafeTemporaryTrait>(
                name)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectSafeTemporaryTrait;
                    status.trait = MoonlitExpansion.TryGet<TraitData>("Fury");
                });
        }
    }
}