using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class FrostdustCharm
    {
        public const string name = "CardUpgradeFrostdust";

        public static CardUpgradeDataBuilder Builder()
        {
            return SwapEffectsCharm(
                    name,
                    "Frostdust Charm",
                    "Frost",
                    "frost",
                    "Snow",
                    "snow"
                );
        }
    }
}