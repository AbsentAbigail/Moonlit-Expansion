using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class WispCandies
    {
        public const string name = "WispCandies";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Wisp Candies",
                null,
                pools: Helpers.Pools.Shademancer)
                .SetTraits(MoonlitExpansion.TStack("Consume", 1))
                .SubscribeToAfterAllBuildEvent(data => data.startWithEffects = [MoonlitExpansion.SStack(OnCardPlayedApplyOverloadToAllEnemies.name, 2)]);
        }
    }
}