namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectApplyXWhenAnyCounterReachesZero : StatusEffectApplyX
    {
        public override void Init()
        {
            Events.OnActionQueued += ActionQueued;
        }

        public void OnDestroy()
        {
            Events.OnActionQueued -= ActionQueued;
        }

        private void ActionQueued(PlayAction playAction)
        {
            if (playAction is not ActionTriggerByCounter triggerAction)
                return;
            if (triggerAction.entity == target)
                return;

            foreach (var entity in GetTargets())
                ActionQueue.Stack(new ActionApplyStatus(entity, target, effectToApply, GetAmount()));
        }
    }
}