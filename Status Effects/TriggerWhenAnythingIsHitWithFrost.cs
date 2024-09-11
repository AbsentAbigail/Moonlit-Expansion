using Deadpan.Enums.Engine.Components.Modding;
using static StatusEffectTriggerWhenStatusApplied;

namespace Moonlit_Expansion.Status_Effects
{
    internal class TriggerWhenAnythingIsHitWithFrost
    {
        public const string name = "Trigger When Anything Is Hit With Frost";

        public static StatusEffectDataBuilder Builder()
        {
            return MoonlitExpansion.StatusCopy("Trigger Against When Frost Applied", name)
                .WithText("Trigger when anything is hit with {e}")
                .FreeModify(data =>
                {
                    var realData = data as StatusEffectTriggerWhenStatusApplied;

                    realData.triggerType = TriggerType.Normal;
                });
        }
    }
}