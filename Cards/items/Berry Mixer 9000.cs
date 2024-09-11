using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class BerryMixer9000
    {
        public const string name = "BerryMixer9000";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Berry Mixer 9000",
                needsTarget: true,
                pools: Helpers.Pools.Clunkmaster)
                .CanPlayOnHand(true)
                .SetAttackEffect(
                    MoonlitExpansion.SStack("Increase Max Health", 4),
                    MoonlitExpansion.SStack("Heal (No Ping)", 4)
                )
                .SetTraits(MoonlitExpansion.TStack("Recycle", 1));
        }
    }
}