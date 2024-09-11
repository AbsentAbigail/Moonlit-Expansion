namespace Moonlit_Expansion.Helpers
{
    internal static class InjurySystemExtensions
    {
        public static void Injure(this InjurySystem injurySystem, CardData cardData, bool ignoreCardType)
        {
            if (ignoreCardType || injurySystem.CanInjure(cardData))
            {
                cardData.injuries ??= [];

                if (cardData.injuries.Count <= 0)
                {
                    cardData.injuries.Add(new CardData.StatusEffectStacks(injurySystem.injuryEffect, 1));
                }

                injurySystem.injuredThisBattle ??= [];

                injurySystem.injuredThisBattle.Add(cardData);
                Events.InvokeCardInjured(cardData);
            }
        }
    }
}