using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;
using Moonlit_Expansion.Upgrades.CardScripts;
using UnityEngine;
using static Moonlit_Expansion.Helpers.CardUpgradeHelper;

namespace Moonlit_Expansion.Upgrades
{
    internal class BloodbladeCharm
    {
        public const string name = "CardUpgradeBloodblade";
        public static CardUpgradeDataBuilder Builder()
        {
            return Charm(
                    name,
                    "Bloodblade Charm",
                    "Gain \"Trigger when an ally is sacrificed\" and remove Counter\n+3<keyword=attack>",
                    Helpers.Pools.Shademancer
                )
                .WithSetCounter(true)
                .SetBecomesTarget(true)
                .ChangeCounter(0)
                .SetEffects(MoonlitExpansion.SStack("When Ally Is Sacrificed Trigger To Self", 1))
                .SetConstraints(TargetConstraintHelper.MaxCounterMoreThan(0))
                .SubscribeToAfterAllBuildEvent(data => data.scripts = [ScriptableObject.CreateInstance<CardScriptChangeAttack>()]);
        }
    }
}