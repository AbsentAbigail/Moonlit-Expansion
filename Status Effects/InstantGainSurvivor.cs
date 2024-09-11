using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.KeyworkHelper;

namespace Moonlit_Expansion.Status_Effects
{
    internal class InstantGainSurvivor
    {
        public const string name = "Instant Gain Survivor";

        public static StatusEffectDataBuilder Builder()
        {
            return StatusEffectHelper.DefaultApplyXBuilder<StatusEffectApplyXInstant>(
                name,
                $"Apply {KeywordHelper.Tag(Keywords.Survivor.name)}",
                effectToApply: TemporarySurvivor.name,
                applyToFlags: StatusEffectApplyX.ApplyToFlags.Self)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.applyFormatKey = MoonlitExpansion.TryGet<StatusEffectData>("Shroom").applyFormatKey;
                });
        }
    }
}