using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Cards.items
{
    internal class BoneBroth
    {
        public const string name = "BoneBroth";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Bone Broth",
                null,
                true,
                Helpers.Pools.Shademancer)
                .SetAttackEffect(
                    MoonlitExpansion.SStack("Teeth", 5),
                    MoonlitExpansion.SStack("Reduce Max Health", 2)
                )
                .SetTraits(MoonlitExpansion.TStack("Consume", 1));
        }
    }
}