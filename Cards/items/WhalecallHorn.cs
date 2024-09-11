using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class WhalecallHorn
    {
        public const string name = "WhalecallHorn";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Whalecall Horn",
                null,
                true)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [
                        MoonlitExpansion.SStack(OnCardPlayedApplyIncreaseAttackToAlliesInRow.name, 1),
                        MoonlitExpansion.SStack(OnCardPlayedApplyIncreaseAttackToEnemiesInRow.name, 1)];
                    data.attackEffects = [MoonlitExpansion.SStack(Nothing.name, 1)];
                });
        }
    }
}