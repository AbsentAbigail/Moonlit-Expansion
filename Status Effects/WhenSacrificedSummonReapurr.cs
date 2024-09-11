using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Cards;
using Moonlit_Expansion.Cards.companions;

namespace Moonlit_Expansion.Status_Effects
{
    internal class WhenSacrificedSummonReapurr
    {
        public const string name = "When Sacrificed Summon Reapurr";

        public static StatusEffectDataBuilder Builder()
        {
            return MoonlitExpansion.StatusCopy("When Sacrificed Summon TailsFour", name)
                .WithText("Summon Reapurr")
                .WithTextInsert(CardHelper.CardTag(Reapurr.name))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectApplyXWhenDestroyed;
                    status.effectToApply = MoonlitExpansion.TryGet<StatusEffectData>(InstantSummonReapurr.name);
                });
        }
    }
}