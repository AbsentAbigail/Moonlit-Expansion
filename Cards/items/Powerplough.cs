using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class Powerplough
    {
        public const string name = "Powerplough";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Powerplough",
                0,
                true,
                pools: Helpers.Pools.Snowdweller)
                .SetTraits(MoonlitExpansion.TStack("Barrage", 1))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.startWithEffects = [MoonlitExpansion.SStack(AdditionalDamageEqualToTargetSnow.name, 1)];
                });
        }
    }
}