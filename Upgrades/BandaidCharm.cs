using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;
using Moonlit_Expansion.Traits;

namespace Moonlit_Expansion.Upgrades
{
    internal class BandaidCharm
    {
        public const string name = "CardUpgradeBandaid";

        public static CardUpgradeDataBuilder Builder()
        {
            return CardUpgradeHelper.Charm(
                    name,
                    "Bandaid Charm",
                    $"Gain {Keywords.Survivor.tag}"
                )
                .SubscribeToAfterAllBuildEvent(data => data.giveTraits = [MoonlitExpansion.TStack(Survivor.name, 1)]);
        }
    }
}