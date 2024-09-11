using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonlit_Expansion.Status_Effects
{
    internal class ActionSacrifice : PlayAction
    {
        public Entity entity;

        public ActionSacrifice(Entity entity)
        {
            this.entity = entity;
        }

        public override System.Collections.IEnumerator Run()
        {
            if (!entity.IsAliveAndExists())
                yield break;

            yield return Sequences.WaitForAnimationEnd(entity);

            entity.lastHit = new Hit(Battle.GetCardsOnBoard(entity.owner).First(card => card.data.id != entity.data.id), entity);
            yield return entity.Kill();
        }
    }
}
