using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class Shivcicle
    {
        public const string name = "Shivcicle";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Shivcicle",
                1,
                true)
                .SetAttackEffect(MoonlitExpansion.SStack("Frost", 1))
                .SetTraits(MoonlitExpansion.TStack("Noomlin", 1));
        }
    }
}