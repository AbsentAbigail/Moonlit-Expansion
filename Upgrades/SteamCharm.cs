using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class SteamCharm
    {
        public const string name = "CardUpgradeSteam";

        public static CardUpgradeDataBuilder Builder()
        {
            return Charm(
                    name,
                    "Steam Charm",
                    "Apply <1> <keyword=haze>\nGain <keyword=consume> and <keyword=recycle> <1>",
                    Helpers.Pools.Clunkmaster
                )
                .SetAttackEffects(MoonlitExpansion.SStack("Haze", 1))
                .SetTraits(
                    MoonlitExpansion.TStack("Recycle", 1),
                    MoonlitExpansion.TStack("Consume", 1)
                )
                .SetConstraints(TargetConstraintHelper.General<TargetConstraintIsItem>());
        }
    }
}