using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;

namespace Moonlit_Expansion.Upgrades
{
    internal class RoseHipCharm
    {
        public const string name = "CardUpgradeRoseHip";

        public static CardUpgradeDataBuilder Builder()
        {
            return CardUpgradeHelper.Charm(
                name,
                "Rose Hip Charm",
                "Gain <keyword=teeth> equal to <keyword=health>\nReduce <keyword=health> by half",
                Pools.Shademancer)
                .SetConstraints(TargetConstraintHelper.General<TargetConstraintHealthMoreThan>("Health more than 1", tc => tc.value = 1))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.scripts = [
                        ScriptableHelper.CreateScriptable<CardScriptGainStatusEqualTo>("Gain Teeth Equal To Health", s => {
                            s.equalToStat = CardScriptGainStatusEqualTo.Stat.Health;
                            s.statusName = "Teeth";
                            s.multiplier = 1f;
                        }),
                        ScriptableHelper.CreateScriptable<CardScriptMultiplyHealth>("Half Health", s => {
                            s.multiply = 0.5f;
                            s.roundUp = true;
                        })
                    ];
                });
        }
    }
}