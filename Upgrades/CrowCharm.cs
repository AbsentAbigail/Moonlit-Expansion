using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Upgrades
{
    internal class CrowCharm
    {
        public const string name = "CardUpgradeCrow";

        public static CardUpgradeDataBuilder Builder()
        {
            return CardUpgradeHelper.Charm(
                    name,
                    "Crow Charm",
                    "When an ally is killed, gain <keyword=fury 2>"
                )
                .SetConstraints(
                    TargetConstraintHelper.General<TargetConstraintIsUnit>(),
                    TargetConstraintHelper.General<TargetConstraintDoesAttack>()
                )
                .SubscribeToAfterAllBuildEvent(data => data.effects = [MoonlitExpansion.SStack(WhenAllyIsKilledApplyFuryToSelf.name, 2)]);
        }
    }
}