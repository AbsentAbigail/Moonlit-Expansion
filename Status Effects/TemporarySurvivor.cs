using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Status_Effects
{
    internal class TemporarySurvivor
    {
        public const string name = "Temporary Survivor";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectTemporaryTrait>(name)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectTemporaryTrait;
                    status.trait = MoonlitExpansion.TryGet<TraitData>(Traits.Survivor.name);
                });
        }
    }
}