using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Cards;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.cards
{
    internal class LuminLady
    {
        public const string name = "LuminLady";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                    name,
                    "Lumin Lady",
                    5, 5, 4
                )
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [MoonlitExpansion.SStack(OnKillBoostRandomAlly.name, 1)];
                });
        }
    }
}