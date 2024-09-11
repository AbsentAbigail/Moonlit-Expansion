using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Cards;
using Moonlit_Expansion.statuseffects;

namespace Moonlit_Expansion.cards
{
    internal class Bonetrops
    {
        public const string name = "Bonetrops";
        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                title: "Bonetrops",
                pools: Helpers.Pools.Shademancer)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [
                        MoonlitExpansion.SStack(OnCardPlayedApplyTeethToFrontAllies.name, 2),
                        MoonlitExpansion.SStack(OnCardPlayedApplyTeethToFrontEnemies.name, 1),
                    ];
                });
        }
    }
}