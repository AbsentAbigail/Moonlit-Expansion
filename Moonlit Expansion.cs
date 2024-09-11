using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using Moonlit_Expansion.cards;
using Moonlit_Expansion.Cards.clunkers;
using Moonlit_Expansion.Cards.companions;
using Moonlit_Expansion.Cards.items;
using Moonlit_Expansion.Helpers;
using Moonlit_Expansion.Status_Effects;
using Moonlit_Expansion.statuseffects;
using Moonlit_Expansion.Upgrades;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Moonlit_Expansion
{
    public class MoonlitExpansion : WildfrostMod
    {
        public static MoonlitExpansion Instance;

        public MoonlitExpansion(string modDirectory) : base(modDirectory)
        {
            Instance = this;
        }

        public override string GUID => "absentabigail.wildfrost.moonlit";
        public override string[] Depends => [];
        public override string Title => "Moonlit Expansion [WIP]";
        public override string Description => "Adding new cards and charms! Credit to Moondial for the concepts, Artemis_ and MegaMarine for the art";

        private List<object> assets;
        private bool loaded = false;

        public override void Load()
        {
            TryGet<KeywordData>("injured").showName = true;

            if (!loaded) CreateModAssets();
            base.Load();

            Events.OnModLoaded += ModLoaded;
        }

        public override void Unload()
        {
            TryGet<KeywordData>("injured").showName = false;

            UnloadBossPatch();
            UnloadFromClasses();
            base.Unload();

            Events.OnModLoaded -= ModLoaded;
        }

        private void ModLoaded(WildfrostMod arg0)
        {
            DynamicStatusHelper.LoadFromFile();
        }

        public void CreateModAssets()
        {
            assets = [
                /**
                 * Status Effects
                 */
                OnCardPlayedApplyTeethToFrontAllies.Builder(),
                OnCardPlayedApplyTeethToFrontEnemies.Builder(),
                OnKillBoostRandomAlly.Builder(),
                TriggerWhenAnythingIsHitWithFrost.Builder(),
                ApplyAttackToSelfWhenFrostApplied.Builder(),
                OnTurnApplyFrostToAllEnemies.Builder(),
                OnCardPlayedAddAttackToAlliesInRow.Builder(),
                OnTurnApplySoulboundToSelf.Builder(),
                OnTurnApplySoulbound.Builder(),
                SacrificeSelfAfterTurn.Builder(),
                OnTurnApplyBomToAllEnemies.Builder(),
                TriggerBeforeEnemyAttacks.Builder(),
                WhenAllyIsKilledApplyFuryToSelf.Builder(),
                Survivor.Builder(),
                WhenAnyCounterReachesZeroCountDownSelf.Builder(),
                WhenSacrificedSummonReapurr.Builder(),
                InstantSummonReapurr.Builder(),
                SummonReapurr.Builder(),
                InstantSummonReapurrWithBonusHealth.Builder(),
                InstantGainSurvivor.Builder(),
                TemporarySurvivor.Builder(),
                InstantGainFurySafe.Builder(),
                AdditionalDamageEqualToTargetSnow.Builder(),
                OnCardPlayedApplyBlockToFrontAllies.Builder(),
                OnCardPlayedApplyBlockToFrontEnemies.Builder(),
                OnCardPlayedBoostSelf.Builder(),
                ApplyOnCardPlayedApplyAttackToSelf.Builder(),
                OnCardPlayedApplyIncreaseAttackToAlliesInRow.Builder(),
                OnCardPlayedApplyIncreaseAttackToEnemiesInRow.Builder(),
                Nothing.Builder(),
                AfterCardPlayedAddFrenzyToSelf.Builder(),
                InstantApplyWeaknessDecreasedForEachEnemy.Builder(),
                OnCardPlayedApplyOverloadToAllEnemies.Builder(),

                /**
                 * Keywords
                 */
                Keywords.Survivor.Builder(),

                /**
                 * Traits
                 */
                Traits.Survivor.Builder(),

                /**
                 * Cards (Units)
                 */
                LuminLady.Builder(),
                Frierre.Builder(),
                Frostbiter.Builder(),
                Frostapult.Builder(),
                Bonshee.Builder(),
                Kabom.Builder(),
                Rango.Builder(),
                Sentrik.Builder(),
                SunPriest.Builder(),
                Reapurr.Builder(),

                /**
                 * Cards (Items)
                 */
                Bonetrops.Builder(),
                TinkeringKit.Builder(),
                PocketSauna.Builder(),
                LuminStamp.Builder(),
                ReapurrMask.Builder(),
                BerryMixer9000.Builder(),
                BattleBandage.Builder(),
                Powerplough.Builder(),
                SunAmulet.Builder(),
                Cubarrier.Builder(),
                LuminSword.Builder(),
                Snowberries.Builder(),
                MagmaMittens.Builder(),
                WhalecallHorn.Builder(),
                Frostchucks.Builder(),
                Shivcicle.Builder(),
                Duality.Builder(),
                BumkinPie.Builder(),
                DemonhornFloat.Builder(),
                BoneBroth.Builder(),
                HongosHamburger.Builder(),
                Calamarink.Builder(),
                HeartStew.Builder(),
                IceTray.Builder(),
                WispCandies.Builder(),
                Frostcicle.Builder(),

                /**
                 * Card Upgrades
                 */
                SootsnowCharm.Builder(),
                SunsongCharm.Builder(),
                CandleCharm.Builder(),
                SnowsporeCharm.Builder(),
                BloodbladeCharm.Builder(),
                SharkToothCharm.Builder(),
                BomPrint.Builder(),
                SteamCharm.Builder(),
                CrowCharm.Builder(),
                BandaidCharm.Builder(),
                FrostdustCharm.Builder(),
                RoseHipCharm.Builder(),
                GumCharm.Builder(),
            ];

            loaded = true;
        }

        public void UnloadFromClasses()
        {
            List<ClassData> tribes = AddressableLoader.GetGroup<ClassData>("ClassData");
            foreach (ClassData tribe in tribes)
            {
                if (tribe == null || tribe.rewardPools == null)
                    continue;

                foreach (RewardPool pool in tribe.rewardPools)
                {
                    if (pool == null)
                        continue;

                    pool.list.RemoveAllWhere((item) => item == null || item.ModAdded == this);
                }
            }
        }

        private void UnloadBossPatch()
        {
            FinalBossGenerationSettings[] finalBoss = Resources.FindObjectsOfTypeAll<FinalBossGenerationSettings>();
            CardData bonshee = TryGet<CardData>(Bonshee.name);
            foreach (FinalBossGenerationSettings finalBossSettings in finalBoss)
            {
                finalBossSettings.enemyOptions = finalBossSettings.enemyOptions.Where(e => e.enemy != bonshee).ToArray();
            }
        }

        [HarmonyPatch(typeof(FinalBossGenerationSettings), "GenerateBonusEnemies", [
            typeof(int), typeof(IEnumerable<CardData>), typeof(CardData[])
        ])]
        internal static class AppendCardReplacement
        {
            internal static void Prefix(FinalBossGenerationSettings __instance)
            {
                var enemyGenerator = ScriptableObject.CreateInstance<FinalBossEnemyGenerator>();
                enemyGenerator.enemy = TryGet<CardData>(Bonshee.name);
                enemyGenerator.fromCards = [
                    TryGet<CardData>("SkullMuffin"),
                    TryGet<CardData>("Scythe"),
                    TryGet<CardData>("VoidStaff"),
                    TryGet<CardData>("Bonescraper"),
                ];
                __instance.enemyOptions = __instance.enemyOptions.AddToArray(enemyGenerator);
            }
        }

        public override List<T> AddAssets<T, Y>()
        {
            if (assets.OfType<T>().Any())
                Debug.LogWarning($"[{Title}] adding {typeof(Y).Name}s: {assets.OfType<T>().Select(a => a._data.name).Join()}");
            return assets.OfType<T>().ToList();
        }

        public static T TryGet<T>(string name) where T : DataFile
        {
            T data;
            if (typeof(StatusEffectData).IsAssignableFrom(typeof(T)))
                data = Instance.Get<StatusEffectData>(name) as T;
            else
                data = Instance.Get<T>(name);

            if (data == null)
                throw new Exception($"TryGet Error: Could not find a [{typeof(T).Name}] with the name [{name}] or [{Extensions.PrefixGUID(name, Instance)}]");

            return data;
        }

        public static T TryGetOrNull<T>(string name) where T : DataFile
        {
            T data;
            if (typeof(StatusEffectData).IsAssignableFrom(typeof(T)))
                data = Instance.Get<StatusEffectData>(name) as T;
            else
                data = Instance.Get<T>(name);

            return data;
        }

        public static CardData.StatusEffectStacks SStack(string name, int amount) => new(Instance.Get<StatusEffectData>(name), amount);

        public static CardData.TraitStacks TStack(string name, int amount) => new(Instance.Get<TraitData>(name), amount);

        public static StatusEffectDataBuilder StatusCopy(string oldName, string newName)
        {
            StatusEffectData data = TryGet<StatusEffectData>(oldName).InstantiateKeepName();
            data.name = Instance.GUID + "." + newName;
            StatusEffectDataBuilder builder = data.Edit<StatusEffectData, StatusEffectDataBuilder>();
            builder.Mod = Instance;
            return builder;
        }
    }
}