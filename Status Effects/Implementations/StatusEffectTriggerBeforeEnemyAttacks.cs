using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectTriggerBeforeEnemyAttacks : StatusEffectData
    {
        public List<Trigger> interceptedTriggers = new List<Trigger>();

        public override void Init()
        {
            Events.OnEntityPreTrigger += Check;
            this.OnTurnEnd += TurnEnd;
        }

        public override bool RunTurnEndEvent(Entity entity)
        {
            return target == entity && base.RunTurnEndEvent(entity);
        }

        public IEnumerator TurnEnd(Entity entity)
        {
            interceptedTriggers.Clear();
            yield break;
        }

        public void OnDestroy()
        {
            Events.OnEntityPreTrigger -= Check;
        }

        public void Check(ref Trigger trigger)
        {
            if (interceptedTriggers.Contains(trigger))
                return;

            if (!target.alive && !Battle.IsOnBoard(target))
                return;

            Entity attacker = trigger.entity;
            if (attacker == null)
                return;

            if (attacker.owner == target.owner)
                return;

            if (trigger.targets == null)
                return;

            var doesAttack = TargetConstraintHelper.General<TargetConstraintDoesAttack>();
            if (!doesAttack.Check(attacker))
                return;

            StealTrigger(ref trigger);
        }

        public void StealTrigger(ref Trigger trigger)
        {
            var originalTrigger = trigger;
            interceptedTriggers.Add(originalTrigger);
            Entity[] targets = (target.targetMode ? target.targetMode.GetTargets(target, null, null) : null);
            trigger = new Trigger(target, target, "basic", targets);
            ActionQueue.Stack(new ActionProcessTrigger(originalTrigger));
        }
    }
}