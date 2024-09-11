using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class SharkToothCharm
    {
        public const string name = "CardUpgradeSharkTooth";

        public static CardUpgradeDataBuilder Builder()
        {
            return Charm(
                    name,
                    "Shark Tooth Charm",
                    "Gain <2> <keyword=teeth> on kill",
                    Helpers.Pools.Shademancer
                )
                .SetEffects(MoonlitExpansion.SStack("On Kill Apply Teeth To Self", 2))
                .SetConstraints(TargetConstraintHelper.General<TargetConstraintIsUnit>());
        }
    }
}