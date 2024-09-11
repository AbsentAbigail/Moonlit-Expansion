using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.companions
{
    internal class Frostbiter
    {
        public const string name = "Frostbiter";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                name,
                "Frostbiter",
                6, 1, 3)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = new CardData.StatusEffectStacks[]
                    {
                        MoonlitExpansion.SStack(ApplyAttackToSelfWhenFrostApplied.name, 1)
                    };
                });
        }
    }
}