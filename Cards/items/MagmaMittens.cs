using Deadpan.Enums.Engine.Components.Modding;
using Moonlit_Expansion.Status_Effects;

namespace Moonlit_Expansion.Cards.items
{
    internal class MagmaMittens
    {
        public const string name = "MagmaMittens";

        public static CardDataBuilder Builder()
        {
            return CardHelper.DefaultItemBuilder(
                    name,
                    "Magma Mittens",
                    needsTarget: true
                ).CanPlayOnHand(true)
                .SetTraits(MoonlitExpansion.TStack("Consume", 1))
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.targetConstraints = [TargetConstraintHelper.General<TargetConstraintAttackMoreThan>(modification: t => t.value = -1)];
                    data.attackEffects = [MoonlitExpansion.SStack(ApplyOnCardPlayedApplyAttackToSelf.name, 1)];
                });
        }
    }
}