using System.Collections;
using UnityEngine;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectSafeTemporaryTrait : StatusEffectTemporaryTrait
    {
        public int queued = 0;
        public int finished = 0;

        public override IEnumerator StackRoutine(int stacks)
        {
            int current = queued;
            queued++;
            yield return new WaitUntil(() => finished == current);
            yield return base.StackRoutine(stacks);
            finished++;
        }
    }
}