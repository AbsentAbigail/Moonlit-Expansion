using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class BumkinPie
    {
        public const string name = "BumkinPie";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Bumkin Pie",
                0,
                pools: Helpers.Pools.Clunkmaster)
                .SetTraits(MoonlitExpansion.TStack("Consume", 1))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [
                        MoonlitExpansion.SStack("Hit All Enemies", 1),
                        MoonlitExpansion.SStack(InstantApplyWeaknessDecreasedForEachEnemy.name, 7)
                    ];
                });
        }
    }
}