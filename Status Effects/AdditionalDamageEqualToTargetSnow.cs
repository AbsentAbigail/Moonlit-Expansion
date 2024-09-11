using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;

namespace Moonlit_Expansion.Status_Effects
{
    internal class AdditionalDamageEqualToTargetSnow
    {
        public const string name = "Additional Damage Equal To Target Snow";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectBonusDamageEqualToX>(
                name,
                "Deal additional damage equal to targets <keyword=snow>")
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectBonusDamageEqualToX;
                    status.on = StatusEffectBonusDamageEqualToX.On.ScriptableAmount;
                    status.scriptableAmount = ScriptableHelper.CreateScriptable<ScriptableEnemyStatus>("Equal To Enemy Snow", t => t.effectType = "snow");
                });
        }

        public class ScriptableEnemyStatus : ScriptableAmount
        {
            public string effectType;

            public override int Get(Entity entity)
            {
                int result = 0;

                foreach (var target in entity.targetMode.GetTargets(entity, null, null))
                {
                    StatusEffectData statusEffectData = target.FindStatus(effectType);
                    if ((bool)statusEffectData && statusEffectData.count > 0)
                    {
                        result += statusEffectData.count;
                    }
                }

                return result;
            }
        }
    }
}