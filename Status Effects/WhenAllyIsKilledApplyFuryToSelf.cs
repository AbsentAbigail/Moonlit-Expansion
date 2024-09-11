using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Status_Effects
{
    internal class WhenAllyIsKilledApplyFuryToSelf
    {
        public const string name = "When Ally Is Killed Apply Fury To Self";

        public static StatusEffectDataBuilder Builder()
        {
            return MoonlitExpansion.StatusCopy("When Ally Is Killed Apply Attack To Self", name)
                .WithText("Gain <keyword=fury {a}> when an ally is killed")
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    var status = data as StatusEffectApplyX;
                    status.separateActions = true;
                    status.effectToApply = MoonlitExpansion.TryGet<StatusEffectData>(InstantGainFurySafe.name);
                });
        }
    }
}