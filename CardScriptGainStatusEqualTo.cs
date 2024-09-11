using HarmonyLib;
using UnityEngine;
using static CardData;

namespace Moonlit_Expansion
{
    internal class CardScriptGainStatusEqualTo : CardScript
    {
        public enum Stat
        {
            Health,
            Attack,
            Counter
        }

        public Stat equalToStat;
        public string statusName;
        public float multiplier;

        public override void Run(CardData target)
        {
            int amount = Find(target);
            StatusEffectStacks status = MoonlitExpansion.SStack(statusName, amount);

            target.startWithEffects = target.startWithEffects.AddToArray(status);
        }

        private int Find(CardData card)
        {
            return equalToStat switch
            {
                Stat.Health => Find(card.hp),
                Stat.Attack => Find(card.damage),
                Stat.Counter => Find(card.counter),
                _ => 0,
            };
        }

        private int Find(int i)
        {
            float f = (float)i * multiplier;
            return Mathf.CeilToInt(f);
        }
    }
}