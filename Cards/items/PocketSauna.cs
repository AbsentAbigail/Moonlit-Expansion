using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using Moonlit_Expansion.Cards;

namespace Moonlit_Expansion.cards
{
    internal class PocketSauna
    {
        public const string name = "PocketSauna";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                title: "Pocket Sauna",
                attack: 0,
                needsTarget: true)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = data.startWithEffects.AddToArray(MoonlitExpansion.SStack("On Card Played Apply Attack To Self", 2));
                    data.attackEffects = data.attackEffects.AddToArray(MoonlitExpansion.SStack("Increase Attack", 2));
                });
        }
    }
}