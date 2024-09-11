using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Cards.companions;

namespace Moonlit_Expansion.Status_Effects
{
    internal class SummonReapurr
    {
        public const string name = "Summon Reapurr";

        public static StatusEffectDataBuilder Builder()
        {
            return MoonlitExpansion.StatusCopy("Summon TailsFour", name)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectSummon;
                    status.summonCard = MoonlitExpansion.TryGet<CardData>(Reapurr.name);
                });
        }
    }
}