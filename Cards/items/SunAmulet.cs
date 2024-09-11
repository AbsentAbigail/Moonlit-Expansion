using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class SunAmulet
    {
        public const string name = "SunAmulet";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Sun Amulet",
                needsTarget: true)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.attackEffects = [
                        MoonlitExpansion.SStack("Increase Attack", 3),
                        MoonlitExpansion.SStack("Increase Max Counter", 1)
                    ];
                });
        }
    }
}