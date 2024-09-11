using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.statuseffects;

namespace Moonlit_Expansion.Cards.items
{
    internal class Cubarrier
    {
        public const string name = "Cubarrier";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Cubarrier")
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [
                        MoonlitExpansion.SStack(OnCardPlayedApplyBlockToFrontAllies.name, 1),
                        MoonlitExpansion.SStack(OnCardPlayedApplyBlockToFrontEnemies.name, 1)
                    ];
                });
        }
    }
}