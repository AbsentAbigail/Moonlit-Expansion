using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class HongosHamburger
    {
        public const string name = "HongosHamburger";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Hongo's Hamburger",
                    0,
                    true,
                    Helpers.Pools.Snowdweller
                )
                .SetAttackEffect(MoonlitExpansion.SStack("Shroom", 6))
                .SetTraits(MoonlitExpansion.TStack("Consume", 1));
        }
    }
}