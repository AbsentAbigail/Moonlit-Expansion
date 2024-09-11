using Deadpan.Enums.Engine.Components.Modding;
using static Moonlit_Expansion.Helpers.KeyworkHelper;

namespace Moonlit_Expansion.Keywords
{
    internal class Survivor
    {
        public const string name = "survivor";
        public static string tag = KeywordHelper.Tag(name);

        public static KeywordDataBuilder Builder()
        {
            return KeywordHelper.Keyword(
                    name,
                    "Survivor",
                    "When health reaches 0 and this card is not <keyword=injured>, restore health to half, reduce attack by half, and become <keyword=injured>"
                );
        }
    }
}