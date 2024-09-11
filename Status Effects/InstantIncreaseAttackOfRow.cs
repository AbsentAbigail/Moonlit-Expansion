using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Status_Effects
{
    internal class InstantIncreaseAttackOfRow
    {
        public const string name = "Instant Increase Attack Of Units In Row";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultStatusBuilder<StatusEffectInstantApplyEffect>(
                name,
                canBoost: true,
                canStack: true)
                .FreeModify(data =>
                {
                    var status = data as StatusEffectInstantApplyEffect;
                });
        }
    }
}