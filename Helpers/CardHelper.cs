using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using Moonlit_Expansion.Helpers;

namespace Moonlit_Expansion.Cards
{
    internal static class CardHelper
    {
        public static string CardTag(string name)
        {
            return $"<card={MoonlitExpansion.Instance.GUID}.{name}>";
        }

        public static CardDataBuilder DefaultUnitBuilder(string name, string title, int? hp = null, int? attack = null, int counter = 0, Pools pools = Pools.General)
        {
            return new CardDataBuilder(MoonlitExpansion.Instance)
                .CreateUnit(name, title)
                .SetStats(hp, attack, counter)
                .SetSprites(name + ".png", name + "BG.png")
                .WithPools(UnitPools(pools));
        }

        public static CardDataBuilder DefaultClunkerBuilder(string name, string title, int scrap = 1, int? attack = null, int counter = 0, Pools pools = Pools.General)
        {
            return new CardDataBuilder(MoonlitExpansion.Instance)
                .CreateUnit(name, title)
                .WithCardType("Clunker")
                .SetStats(null, attack, counter)
                .SetStartWithEffect(MoonlitExpansion.SStack("Scrap", scrap))
                .SetSprites(name + ".png", name + "BG.png")
                .WithPools(ItemPools(pools));
        }

        public static CardDataBuilder DefaultItemBuilder(string name, string title, int? attack = null, bool needsTarget = false, Pools pools = Pools.General, int shopPrice = 50)
        {
            return new CardDataBuilder(MoonlitExpansion.Instance)
                .CreateItem(name, title)
                .SetDamage(attack)
                .NeedsTarget(needsTarget)
                .WithValue(shopPrice)
                .SetSprites(name + ".png", name + "BG.png")
                .WithPools(ItemPools(pools));
        }

        public static CardDataBuilder DropsBling(this CardDataBuilder builder, int amount)
        {
            return builder.WithValue(amount * 36);
        }

        public static string[] UnitPools(Pools pool)
        {
            string[] pools = [];

            if (pool.HasFlag(Helpers.Pools.General))
                pools = pools.AddToArray("GeneralUnitPool");

            if (pool.HasFlag(Helpers.Pools.Snowdweller))
                pools = pools.AddToArray("BasicUnitPool");

            if (pool.HasFlag(Helpers.Pools.Shademancer))
                pools = pools.AddToArray("MagicUnitPool");

            if (pool.HasFlag(Helpers.Pools.Clunkmaster))
                pools = pools.AddToArray("ClunkUnitPool");

            return pools;
        }

        public static string[] ItemPools(Pools pool)
        {
            string[] pools = [];

            if (pool.HasFlag(Helpers.Pools.General))
                pools = pools.AddToArray("GeneralItemPool");

            if (pool.HasFlag(Helpers.Pools.Snowdweller))
                pools = pools.AddToArray("BasicItemPool");

            if (pool.HasFlag(Helpers.Pools.Shademancer))
                pools = pools.AddToArray("MagicItemPool");

            if (pool.HasFlag(Helpers.Pools.Clunkmaster))
                pools = pools.AddToArray("ClunkItemPool");

            return pools;
        }
    }
}