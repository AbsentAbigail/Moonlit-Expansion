using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonlit_Expansion.Status_Effects
{
    internal class InstantSummonReapurrWithBonusHealth
    {
        public const string name = "";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXInstant>(
                name,
                "Summon {0} with equal <keyword=health> equal to target",
                true,
                true,
                InstantSummonReapurr.name,
                StatusEffectApplyX.ApplyToFlags.Self)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectApplyXInstant;
                    status.scriptableAmount = ScriptableHelper.CreateScriptable<ScriptableCurrentHealth>("Current Health");
                });
        }
    }
}
