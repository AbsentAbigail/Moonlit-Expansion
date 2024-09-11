using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class Snowberries
    {
        public const string name = "Snowberries";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Snowberries",
                needsTarget: true)
                .SetAttackEffect(
                    MoonlitExpansion.SStack("Increase Max Health", 6),
                    MoonlitExpansion.SStack("Snow", 2)
                );
        }
    }
}