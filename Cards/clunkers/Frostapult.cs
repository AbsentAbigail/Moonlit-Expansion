using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.clunkers
{
    internal class Frostapult
    {
        public const string name = "Frostapult";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultClunkerBuilder(
                name,
                title: "Frostapult",
                scrap: 1,
                counter: 4)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = data.startWithEffects.AddToArray(MoonlitExpansion.SStack(OnTurnApplyFrostToAllEnemies.name, 2));
                });
        }
    }
}