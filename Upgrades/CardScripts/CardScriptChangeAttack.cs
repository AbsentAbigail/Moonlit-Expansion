namespace Moonlit_Expansion.Upgrades.CardScripts
{
    internal class CardScriptChangeAttack : CardScript
    {
        public int attackChange = 3;

        public override void Run(CardData target)
        {
            target.damage += attackChange;
        }
    }
}