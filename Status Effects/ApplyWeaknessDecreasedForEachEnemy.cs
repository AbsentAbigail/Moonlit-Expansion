using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.Status_Effects
{
    internal class InstantApplyWeaknessDecreasedForEachEnemy
    {
        public const string name = "Instant Apply Weakness Decreased For Each Enemey";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnHitForEachEnemy>(
                name,
                "Apply <{a}><keyword=weakness>, decreased by 1 for each enemy",
                true,
                true,
                "Weakness",
                StatusEffectApplyX.ApplyToFlags.Target)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectApplyXOnHitForEachEnemy;
                    status.increasePerEnemy = -1;
                });
        }
    }
}