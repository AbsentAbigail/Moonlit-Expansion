using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;

namespace Moonlit_Expansion.Upgrades
{
    internal class SnowsporeCharm
    {
        public const string name = "CardUpgradeSnowspore";

        public static CardUpgradeDataBuilder Builder()
        {
            return CardUpgradeHelper.SwapEffectsCharm(
                    name,
                    "Snowspore Charm",
                    "Snow", "snow",
                    "Shroom", "shroom"
                );
        }
    }
}