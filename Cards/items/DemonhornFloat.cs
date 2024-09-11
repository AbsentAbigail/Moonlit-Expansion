using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class DemonhornFloat
    {
        public const string name = "DemonhornFloat";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Demonhorn Float",
                0,
                true)
                .SetAttackEffect(MoonlitExpansion.SStack("Demonize", 1))
                .SetTraits(
                    MoonlitExpansion.TStack("Barrage", 1),
                    MoonlitExpansion.TStack("Consume", 1)
                );
        }
    }
}