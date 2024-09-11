using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.clunkers
{
    internal class Sentrik
    {
        public const string name = "Sentrik";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultClunkerBuilder(
                name,
                "Sentrik",
                scrap: 1, attack: 1)
            .SubscribeToAfterAllBuildEvent(data =>
            {
                data.startWithEffects = data.startWithEffects.AddToArray(MoonlitExpansion.SStack(TriggerBeforeEnemyAttacks.name, 1));
            });
        }
    }
}