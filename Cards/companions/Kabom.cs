using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.companions
{
    internal class Kabom
    {
        public const string name = "Kabom";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                name,
                "Kabom",
                hp: 5, counter: 5,
                pools: Helpers.Pools.Clunkmaster)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects =
                    [
                        MoonlitExpansion.SStack("MultiHit", 1),
                        MoonlitExpansion.SStack(OnTurnApplyBomToAllEnemies.name, 1)
                    ];
                });
        }
    }
}