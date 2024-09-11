using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class TinkeringKit
    {
        public const string name = "TinkeringKit";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Tinkering Kit",
                    needsTarget: true,
                    pools: Helpers.Pools.Clunkmaster)
                .SetTraits(MoonlitExpansion.TStack("Recycle", 1))
                .SetAttackEffect(MoonlitExpansion.SStack("Instant Add Scrap", 1))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = new CardData.StatusEffectStacks[] {
                        MoonlitExpansion.SStack(OnCardPlayedAddAttackToAlliesInRow.name, 1)
                    };
                });
        }
    }
}