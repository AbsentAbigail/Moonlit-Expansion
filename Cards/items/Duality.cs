using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class Duality
    {
        public const string name = "Duality";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Duality",
                0,
                true)
                .SetAttackEffect(MoonlitExpansion.SStack("Frost", 1))
                .SubscribeToAfterAllBuildEvent(data => data.startWithEffects = [MoonlitExpansion.SStack(OnCardPlayedBoostSelf.name, 1)]);
        }
    }
}