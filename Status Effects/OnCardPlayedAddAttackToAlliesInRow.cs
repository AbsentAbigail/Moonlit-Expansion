using Deadpan.Enums.Engine.Components.Modding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatusEffectApplyX;

namespace Moonlit_Expansion.Status_Effects
{
    internal class OnCardPlayedAddAttackToAlliesInRow
    {
        public const string name = "On Card Played Add Attack To Allies In Row";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXOnCardPlayed>(
                name,
                text: "Apply <{a}> <keyword=attack> to allies in row",
                canBoost: true,
                canStack: true,
                effectToApply: "Increase Attack",
                applyToFlags: ApplyToFlags.AlliesInRow);
        }
    }
}
