using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.companions
{
    internal class SunPriest
    {
        public const string name = "SunPriest";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                    name,
                    "Sun Priest",
                    5, null, 10
                )
                .SubscribeToAfterAllBuildEvent(data => data.startWithEffects = [
                        MoonlitExpansion.SStack(WhenAnyCounterReachesZeroCountDownSelf.name, 1),
                        MoonlitExpansion.SStack("On Card Played Reduce Counter To Allies", 1)
                    ]
                );
        }
    }
}