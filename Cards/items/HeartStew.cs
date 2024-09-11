using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class HeartStew
    {
        public const string name = "HeartStew";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Heart Stew",
                null,
                true)
                .SetAttackEffect(
                    MoonlitExpansion.SStack("Increase Max Health", 8)
                )
                .SetTraits(MoonlitExpansion.TStack("Consume", 1));
        }
    }
}