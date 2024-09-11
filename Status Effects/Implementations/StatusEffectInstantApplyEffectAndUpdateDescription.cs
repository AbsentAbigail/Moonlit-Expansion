using System.Collections;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectInstantApplyEffectAndUpdateDescription : StatusEffectInstant
    {
        public StatusEffectData effectToApply;

        public ScriptableAmount scriptableAmount;

        public override IEnumerator Process()
        {
            int num = (scriptableAmount ? scriptableAmount.Get(target) : GetAmount());
            yield return StatusEffectSystem.Apply(target, applier, effectToApply, num);
            target.display.promptUpdateDescription = true;
            target.PromptUpdate();
            yield return base.Process();
        }
    }
}