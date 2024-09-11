using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Cards;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.cards
{
    internal class Frierre
    {
        public const string name = "Frierre";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                    name,
                    "Frierre",
                    6, 3
                )
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [
                        MoonlitExpansion.SStack(TriggerWhenAnythingIsHitWithFrost.name, 1)
                    ];
                });
        }
    }
}