using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.statuseffects
{
    internal class OnCardPlayedApplyTeethToFrontEnemies
    {
        public const string name = "On Card Played Apply Teeth To Front Enemies";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectOnCardPlayedApplyXToFrontAllies>(
                    name,
                    "Apply <{a}> <keyword=teeth> to front enemies",
                    canBoost: true,
                    canStack: true,
                    effectToApply: "Teeth"
                )
                .SubscribeToAfterAllBuildEvent(data => (data as StatusEffectOnCardPlayedApplyXToFrontAllies).enemies = true);
        }
    }
}