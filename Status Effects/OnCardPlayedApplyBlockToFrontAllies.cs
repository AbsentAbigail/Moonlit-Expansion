using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;
using Moonlit_Expansion.Status_Effects.Implementations;

namespace Moonlit_Expansion.statuseffects
{
    internal class OnCardPlayedApplyBlockToFrontAllies
    {
        public const string name = "On Card Played Apply Block To Front Allies";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectOnCardPlayedApplyXToFrontAllies>(
                name,
                "Apply <{a}> <keyword=block> to front allies",
                canBoost: true,
                canStack: true,
                effectToApply: "Block");
        }
    }
}