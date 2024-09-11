using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class ReapurrMask
    {
        public const string name = "ReapurrMask";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Reapurr Mask",
                    needsTarget: true,
                    pools: Helpers.Pools.Shademancer
                )
                .CanPlayOnEnemy(false)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.attackEffects = [
                        MoonlitExpansion.SStack(InstantSummonReapurrWithBonusHealth.name, 1),
                        MoonlitExpansion.SStack("Kill", 1),
                    ];
                });
        }
    }
}