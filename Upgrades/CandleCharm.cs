using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;

namespace Moonlit_Expansion.Upgrades
{
    internal class CandleCharm
    {
        public const string name = "CardUpgradeCandle";

        public static CardUpgradeDataBuilder Builder()
        {
            return CardUpgradeHelper.Charm(
                    name,
                    "Candle Charm",
                    $"Gain <1> <keyword=attack>\nDeal <1> damage to self"
                )
                .SetConstraints(
                    TargetConstraintHelper.Or(
                        null, false,
                        TargetConstraintHelper.General<TargetConstraintHasHealth>(),
                        TargetConstraintHelper.HasStatus("Scrap")
                    ),
                    TargetConstraintHelper.General<TargetConstraintDoesAttack>()
                )
                .SetEffects(
                    MoonlitExpansion.SStack("On Turn Apply Attack To Self", 1),
                    MoonlitExpansion.SStack("On Card Played Damage To Self", 1)
                );
        }
    }
}