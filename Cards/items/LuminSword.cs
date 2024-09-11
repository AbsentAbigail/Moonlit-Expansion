using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class LuminSword
    {
        public const string name = "LuminSword";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Lumin Sword",
                    6,
                    true
                ).WithText("Boost effects by <{a}>")
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.attackEffects = [MoonlitExpansion.SStack("Increase Effects", 1)];
                });
        }
    }
}