namespace Moonlit_Expansion.Status_Effects.Implementations
{
    internal class StatusEffectSacrificeSelfAfterTurn : StatusEffectData
    {
        public bool cardPlayed;

        public override bool RunCardPlayedEvent(Entity entity, Entity[] targets)
        {
            if (!cardPlayed && entity == target && !target.silenced)
            {
                ActionQueue.Add(new ActionSacrifice(entity));
                cardPlayed = true;
            }

            return false;
        }
    }
}