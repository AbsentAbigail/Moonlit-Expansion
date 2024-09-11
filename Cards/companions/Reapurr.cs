using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.companions
{
    internal class Reapurr
    {
        public const string name = "Reapurr";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                    name,
                    "Reapurr",
                    1, 7, 4
                ).WithCardType("Summoned");
        }
    }
}