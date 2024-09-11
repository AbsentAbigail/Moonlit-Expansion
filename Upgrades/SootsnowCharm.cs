using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class SootsnowCharm
    {
        public const string name = "CardUpgradeSootsnow";

        public static CardUpgradeDataBuilder Builder()
        {
            return SwapEffectsCharm(
                    name,
                    "Sootsnow Charm",
                    "Snow", "snow",
                    "Null", "null",
                    Helpers.Pools.Clunkmaster
                )
                .IsSnowdwellerPool();
        }
    }
}