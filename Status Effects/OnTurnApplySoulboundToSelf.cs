using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnTurnApplySoulboundToSelf
    {
        public const string name = "On Card Played Apply Soulbound To Self";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnTurn>(
                    name,
                    text: "Gain <keyword=soulbound>",
                    effectToApply: "Temporary Soulbound",
                    applyToFlags: ApplyToFlags.Self
                );
        }
    }
}