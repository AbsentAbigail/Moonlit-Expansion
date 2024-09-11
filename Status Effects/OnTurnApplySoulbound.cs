using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnTurnApplySoulbound
    {
        public const string name = "On Hit Apply Soulbound";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnHit>(
                    name,
                    text: "Apply <keyword=soulbound>",
                    effectToApply: "Temporary Soulbound",
                    applyToFlags: ApplyToFlags.Target
                );
        }
    }
}