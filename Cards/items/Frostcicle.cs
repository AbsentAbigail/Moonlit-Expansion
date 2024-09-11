using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class Frostcicle
    {
        public const string name = "Frostcicle";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Frostcicle",
                0,
                true)
                .SetAttackEffect(MoonlitExpansion.SStack("Frost", 7));
        }
    }
}