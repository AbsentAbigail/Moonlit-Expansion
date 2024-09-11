using System.Collections;
using System.Linq;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectApplyXOnHitForEachEnemy : StatusEffectApplyXOnHit
    {
        public int increasePerEnemy;

        public override void Init()
        {
            if (postHit)
            {
                base.PostHit += CheckHit;
            }
            else
            {
                base.OnHit += CheckHit;
            }
        }

        public new IEnumerator CheckHit(Hit hit)
        {
            if ((bool)effectToApply)
            {
                yield return Run(GetTargets(hit), GetAmount());
            }

            storedHit.Remove(hit);
        }
        public override int GetAmount()
        {
            int amount = base.GetAmount();
            int adjustedAmount = amount + increasePerEnemy * target.GetAllEnemies().Count();
            LogHelper.Log($"Amount: {amount}; Adjusted Amount: {adjustedAmount}");
            return adjustedAmount;
        }
    }
}