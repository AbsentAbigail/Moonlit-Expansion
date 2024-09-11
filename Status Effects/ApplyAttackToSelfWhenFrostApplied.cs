using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class ApplyAttackToSelfWhenFrostApplied
    {
        public const string name = "Apply Gain Attack To Self When Frost Applied";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXWhenYAppliedTo>(
                name,
                text: "Gain <{a}><keyword=attack> when anything is hit with <keyword=frost>",
                canBoost: true,
                canStack: true,
                effectToApply: "Increase Attack",
                applyToFlags: ApplyToFlags.Self
                )
                .FreeModify(data =>
                {
                    var realData = data as StatusEffectApplyXWhenYAppliedTo;
                    realData.whenAppliedTypes = [
                        MoonlitExpansion.TryGet<StatusEffectData>("Frost").type
                    ];
                    realData.whenAppliedToFlags = ApplyToFlags.Self | ApplyToFlags.Allies | ApplyToFlags.Enemies | ApplyToFlags.Hand;
                });
        }
    }
}