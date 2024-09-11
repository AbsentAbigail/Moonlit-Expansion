namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectApplyToSummonFromTarget : StatusEffectApplyX
    {
        public override void Init()
        {
            Events.OnEntitySummoned += EntitySummoned;
        }

        public void OnDestroy()
        {
            Events.OnEntitySummoned -= EntitySummoned;
        }

        public void EntitySummoned(Entity entity, Entity summonedBy)
        {
            if (summonedBy.data.id != target.data.id)
                return;

            int amount = scriptableAmount.Get(target);
            if (amount <= 0)
                return;

            ActionQueue.Stack(new ActionApplyStatus(entity, summonedBy, effectToApply, amount)
            {
                fixedPosition = true
            });
        }
    }
}