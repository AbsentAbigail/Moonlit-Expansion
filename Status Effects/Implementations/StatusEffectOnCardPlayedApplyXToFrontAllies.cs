using HarmonyLib;
using System.Collections;
using System.Collections.Generic;

namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectOnCardPlayedApplyXToFrontAllies : StatusEffectApplyXOnCardPlayed
    {
        public bool enemies = false;

        public override void Init()
        {
            OnCardPlayed += Check;
        }

        public new IEnumerator Check(Entity entity, Entity[] targets)
        {
            return Run(GetTargets());
        }

        public List<Entity> GetTargets()
        {
            var targets = new List<Entity>();
            var character = enemies ? Battle.instance.enemy : target.owner;
            var rows = Battle.instance.rows.GetValueSafe(character);

            if (rows == null)
                return targets;

            foreach (var row in rows)
            {
                if (row is not CardSlotLane lane)
                    continue;

                Entity frontAlly = null;

                foreach (var slot in lane.slots)
                {
                    frontAlly = slot.GetTop();
                    if (frontAlly == null)
                        continue;

                    targets.Add(frontAlly);
                    break;
                }
            }

            return targets;
        }
    }
}