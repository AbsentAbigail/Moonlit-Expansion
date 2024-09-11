using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class Calamarink
    {
        public const string name = "Calamarink";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Calamarink",
                0,
                true,
                Helpers.Pools.Clunkmaster)
                .SetAttackEffect(MoonlitExpansion.SStack("Null", 5))
                .SetTraits(
                    MoonlitExpansion.TStack("Barrage", 1),
                    MoonlitExpansion.TStack("Consume", 1)
                );
        }
    }
}