using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnKillBoostRandomAlly
    {
        public const string name = "On Kill Boost Random Ally";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnKill>(
                    name,
                    text: "On kill, boost the effects of a random ally by <{a}>",
                    canBoost: true,
                    canStack: true,
                    effectToApply: "Increase Effects",
                    ApplyToFlags.RandomAlly
                );
        }
    }
}