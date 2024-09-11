using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.companions
{
    internal class Rango
    {
        public const string name = "Rango";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                name,
                "Rango", 4, 1, 4)
                .SetTraits(MoonlitExpansion.TStack("Barrage", 1))
                .SetStartWithEffect(MoonlitExpansion.SStack("MultiHit", 1));
        }
    }
}