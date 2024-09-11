using Deadpan.Enums.Engine.Components.Modding;

namespace Moonlit_Expansion.Traits
{
    internal class Survivor
    {
        public const string name = "Survivor";

        public static TraitDataBuilder Builder()
        {
            return new TraitDataBuilder(MoonlitExpansion.Instance)
                .Create(name)
                .SubscribeToAfterAllBuildEvent(data =>
                {
                    data.effects = [MoonlitExpansion.TryGet<StatusEffectData>(Status_Effects.Survivor.name)];
                    data.keyword = MoonlitExpansion.TryGet<KeywordData>(Keywords.Survivor.name);
                });
        }
    }
}