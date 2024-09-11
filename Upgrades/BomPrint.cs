using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class BomPrint
    {
        public const string name = "CardUpgradeBomPrint";

        public static CardUpgradeDataBuilder Builder()
        {
            return SwapEffectsCharm(
                    name,
                    "Bom Print",
                    "Weakness", "weakness",
                    "Null", "null",
                    Helpers.Pools.Clunkmaster
                );
        }
    }
}