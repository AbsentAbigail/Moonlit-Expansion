using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Status_Effects
{
    internal class InstantSummonReapurr
    {
        public const string name = "Instant Summon Reapurr";

        public static StatusEffectDataBuilder Builder()
        {
            return MoonlitExpansion.StatusCopy("Instant Summon TailsFour", name)
                .WithStackable(true)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectInstantSummon;
                    status.targetSummon = MoonlitExpansion.TryGet<StatusEffectData>(SummonReapurr.name) as StatusEffectSummon;
                    status.withEffects = [MoonlitExpansion.TryGet<StatusEffectData>("Increase Max Health")];
                });
        }
    }
}