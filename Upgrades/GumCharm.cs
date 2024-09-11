using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Helpers;

namespace Moonlit_Expansion.Upgrades
{
    internal class GumCharm
    {
        public const string name = "CardUpgradeGum";

        public static CardUpgradeDataBuilder Builder()
        {
            return CardUpgradeHelper.Charm(
                name,
                "Gum Charm",
                "Remove <keyword=consume>\nAdd <2><card=Deadweight> to your hand")
                .SetEffects(MoonlitExpansion.SStack("On Card Played Add Gunk To Hand", 2))
                .SetConstraints(
                    TargetConstraintHelper.General<TargetConstraintHasTrait>(
                        "Has Consume",
                        tc => tc.trait = MoonlitExpansion.TryGet<TraitData>("Consume")
                    )
                )
                .SubscribeToAfterAllBuildEvent(data =>
                    data.scripts = [ScriptableHelper.CreateScriptable<CardScriptRemoveTrait>(
                        "Remove Consume", s => s.toRemove = [MoonlitExpansion.TryGet<TraitData>("Consume")]
                    )]
                );
        }
    }
}