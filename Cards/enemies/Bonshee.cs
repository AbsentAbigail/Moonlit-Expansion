using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.companions
{
    internal class Bonshee
    {
        public const string name = "Bonshee";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultUnitBuilder(
                name,
                "Bonshee",
                10, 0, 3)
                .WithCardType("Enemy")
                .DropsBling(7)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = new CardData.StatusEffectStacks[]
                    {
                        MoonlitExpansion.SStack("ImmuneToSnow", 1),
                        MoonlitExpansion.SStack(OnTurnApplySoulboundToSelf.name, 1),
                        MoonlitExpansion.SStack(OnTurnApplySoulbound.name, 1),
                        MoonlitExpansion.SStack(SacrificeSelfAfterTurn.name, 1)
                    };
                });
        }
    }
}