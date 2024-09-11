using System.Linq;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectApplyXAfterCardPlayed : StatusEffectApplyX
    {
        public override bool RunCardPlayedEvent(Entity entity, Entity[] targets)
        {
            if (entity != target)
                return false;

            if (target.silenced)
                return false;
            
            bool hasQueuedTriggers = ActionQueue.GetActions().Any(a => (a as ActionTrigger) != null && (a as ActionTrigger).entity == target);
            if (hasQueuedTriggers)
                return false;

            LogHelper.Log("Triggered");
            foreach (var t in GetTargets())
            {
                ActionQueue.Add(new ActionApplyStatus(t, target, effectToApply, GetAmount()));
            }

            return false;
        }
    }
}