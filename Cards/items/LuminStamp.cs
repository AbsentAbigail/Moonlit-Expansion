using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class LuminStamp
    {
        public const string name = "LuminStamp";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Lumin Stamp",
                    attack: null,
                    needsTarget: true,
                    shopPrice: 45,
                    pools: Helpers.Pools.Clunkmaster
                )
                .CanPlayOnHand(true)
                .CanPlayOnBoard(false)
                .CanPlayOnFriendly(true)
                .WithText("Boost the effects of a card in hand by <{a}>")
                .SubscribeToAfterAllBuildEvent(data => data.attackEffects = [MoonlitExpansion.SStack("Increase Effects", 1)]);
        }
    }
}