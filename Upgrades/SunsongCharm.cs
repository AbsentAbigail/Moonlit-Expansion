using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class SunsongCharm
    {
        public const string name = "CardUpgradeSunsong";

        public static CardUpgradeDataBuilder Builder()
        {
            return Charm(
                    name,
                    "Sunsong Charm",
                    $"Count down <sprite name=counter> by <1>"
                )
                .SetAttackEffects(MoonlitExpansion.SStack("Reduce Counter", 1))
                .SetConstraints(TargetConstraintHelper.General<TargetConstraintDoesAttack>());
        }
    }
}