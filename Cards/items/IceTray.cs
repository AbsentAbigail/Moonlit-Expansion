using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class IceTray
    {
        public const string name = "IceTray";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Ice Tray",
                    needsTarget: true
                )
                .SetTraits(
                    MoonlitExpansion.TStack("Consume", 1),
                    MoonlitExpansion.TStack("Barrage", 1)
                )
                .SetAttackEffect(MoonlitExpansion.SStack("Block", 1));
        }
    }
}