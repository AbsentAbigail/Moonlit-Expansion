using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class BattleBandage
    {
        public const string name = "BattleBandage";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                name,
                "Battle Bandage",
                needsTarget: true)
                .SetTraits([MoonlitExpansion.TStack("Consume", 1)])
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.attackEffects = [MoonlitExpansion.SStack(InstantGainSurvivor.name, 1)];
                });
        }
    }
}