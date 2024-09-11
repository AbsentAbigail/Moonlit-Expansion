using Moonlit_Expansion.Helpers;
using System.Linq;
using UnityEngine;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectSurvivor : StatusEffectData
    {
        public override void Init()
        {
            preventDeath = true;
            Events.OnEntityDisplayUpdated += EntityDisplayUpdated;
        }

        public void OnDestroy()
        {
            Events.OnEntityDisplayUpdated -= EntityDisplayUpdated;
        }

        public void EntityDisplayUpdated(Entity entity)
        {
            if (!IsInjured() && target.hp.current <= 0 && entity == target)
            {
                TryActivate();
            }
        }

        public override bool RunPostHitEvent(Hit hit)
        {
            if (!IsInjured() && hit.target == target && target.hp.current <= 0)
            {
                TryActivate();
            }

            return false;
        }

        public void TryActivate()
        {
            bool flag = true;
            foreach (StatusEffectData statusEffect in target.statusEffects)
            {
                if (statusEffect != this && statusEffect.preventDeath)
                {
                    flag = false;
                    break;
                }
            }

            if (!flag)
            {
                return;
            }

            LogHelper.Log("Survivor activated. Restore ally");
            target.hp.current = Mathf.CeilToInt(target.hp.max / 2f);
            target.damage.current = Mathf.CeilToInt(target.damage.max / 2f);

            LogHelper.Log("Apply Injury");

            InjurySystem injurySystem = FindObjectOfType<InjurySystem>();
            injurySystem?.Injure(target.data, true);

            LogHelper.Log("Remove Survivor");
            target.display.promptUpdateDescription = true;
            target.PromptUpdate();
        }

        private bool IsInjured()
        {
            bool injured = target.data.injuries.Any();
            preventDeath = !injured;
            return injured;
        }
    }
}