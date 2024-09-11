using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class Frostchucks
    {
        public const string name = "Frostchucks";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Frostchucks",
                0,
                true)
                .SetAttackEffect(MoonlitExpansion.SStack("Frost", 2))
                .SetTraits(MoonlitExpansion.TStack("Aimless", 1))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [
                        MoonlitExpansion.SStack("MultiHit", 1),
                        MoonlitExpansion.SStack(AfterCardPlayedAddFrenzyToSelf.name, 1)
                    ];
                });
        }
    }
}