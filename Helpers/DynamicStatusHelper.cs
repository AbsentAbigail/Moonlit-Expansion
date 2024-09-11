using Deadpan.Enums.Engine.Components.Modding;
using HarmonyLib;
using System;
using System.IO;
using System.Linq;

namespace Moonlit_Expansion.Helpers
{
    internal class DynamicStatusHelper
    {
        public struct DynamicStatus
        {
            public string originalName;
            public string originalStatus;
            public string replacedStatus;
            public string originalKeyword;
            public string replacedKeyword;

            public readonly string[] ToArray() => [originalName, originalStatus, replacedStatus, originalKeyword, replacedKeyword];

            public static DynamicStatus FromArray(params string[] values)
            {
                return new DynamicStatus()
                {
                    originalName = values[0],
                    originalStatus = values[1],
                    replacedStatus = values[2],
                    originalKeyword = values[3],
                    replacedKeyword = values[4]
                };
            }
        }

        public static string path = Path.Combine(MoonlitExpansion.Instance.ModDirectory, "dynamicStatuses.csv");

        public static void OverrideFile()
        {
            File.WriteAllText(path, "");
        }

        public static void AppendLine(DynamicStatus dynamicStatus)
        {
            string text = string.Join(",", dynamicStatus.ToArray());
            LogHelper.Warn("Added line to CSV: " + text);
            File.AppendAllLines(path, [text]);
        }

        public static void LoadFromFile()
        {
            if (!File.Exists(path))
                return;
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                LogHelper.Warn("Reading line from CSV: " + line);
                LoadFromtStruct(DynamicStatus.FromArray(line.Split(',')));
            }
        }

        public static void LoadFromtStruct(DynamicStatus status)
        {
            var originalEffect = MoonlitExpansion.TryGetOrNull<StatusEffectData>(status.originalName);
            if (originalEffect == null)
                return;

            StatusEffectData originalStatus = MoonlitExpansion.TryGet<StatusEffectData>(status.originalStatus);
            StatusEffectData newStatus = MoonlitExpansion.TryGet<StatusEffectData>(status.replacedStatus);
            
            bool _ = false;
            var created = CopyStatusWithEffectSwap(originalEffect, originalStatus, newStatus, status.originalKeyword, status.replacedKeyword, out _);

            AddressableLoader.AddToGroup(typeof(StatusEffectData).Name, created);
        }

        public static StatusEffectData CopyStatusWithEffectSwap(
            StatusEffectData originalEffect,
            StatusEffectData originalStatus, StatusEffectData newStatus,
            string originalKeyword, string newKeyword,
            out bool existed
        )
        {
            existed = false;
            string newName = originalEffect.name.Replace(MoonlitExpansion.Instance.GUID + ".", "").Replace(originalStatus.name, newStatus.name);
            StatusEffectData statusEffectData = MoonlitExpansion.TryGetOrNull<StatusEffectData>(newName);
            if ((bool)statusEffectData)
            {
                existed = true;
                return statusEffectData;
            }

            string originalType = originalStatus.type;
            string newType = newStatus.type;
            LogHelper.Warn($"Creating status effect [{newName}]");
            string text = originalEffect.textKey.GetLocalizedString().Replace($"<keyword={originalKeyword}>", $"<keyword={newKeyword}>");
            string textInsert = originalEffect.textInsert.Replace($"<keyword={originalKeyword}>", $"<keyword={newKeyword}>");

            return MoonlitExpansion.StatusCopy(originalEffect.name.Replace(MoonlitExpansion.Instance.GUID + ".", ""), newName)
                .WithText(text)
                .WithTextInsert(textInsert)
                .FreeModify(data =>
                {
                    var instantDoubleX = data as StatusEffectInstantDoubleX;
                    if ((bool)instantDoubleX && instantDoubleX.statusToDouble.type == originalType)
                        instantDoubleX.statusToDouble.type = newType;

                    var whenYAppliedTo = data as StatusEffectApplyXWhenYAppliedTo;
                    if ((bool)whenYAppliedTo && whenYAppliedTo.effectToApply.type == originalType)
                        whenYAppliedTo.effectToApply = newStatus;

                    if ((bool)whenYAppliedTo && whenYAppliedTo.whenAppliedTypes.Contains(originalType))
                    {
                        int i = Array.IndexOf(whenYAppliedTo.whenAppliedTypes, originalType);
                        whenYAppliedTo.whenAppliedTypes[i] = newType;
                    }

                    var whenYAppliedToAlly = data as StatusEffectApplyXWhenYAppliedToAlly;
                    if ((bool)whenYAppliedToAlly && whenYAppliedToAlly.effectToApply.type == originalType)
                        whenYAppliedToAlly.effectToApply = newStatus;
                    if ((bool)whenYAppliedToAlly && whenYAppliedToAlly.whenAppliedType == originalType)
                        whenYAppliedToAlly.whenAppliedType = newType;

                    var whenYAppliedToSelf = data as StatusEffectApplyXWhenYAppliedToSelf;
                    if ((bool)whenYAppliedToSelf && whenYAppliedToSelf.effectToApply.type == originalType)
                        whenYAppliedToSelf.effectToApply = newStatus;
                    if ((bool)whenYAppliedToSelf && whenYAppliedToSelf.whenAppliedType == originalType)
                        whenYAppliedToSelf.whenAppliedType = newType;

                    var whenUnitIsKilled = data as StatusEffectApplyXWhenUnitIsKilled;
                    if ((bool)whenUnitIsKilled && whenUnitIsKilled.unitConstraints.Any(tc => tc is TargetConstraintHasStatus tcStatus && tcStatus.status == originalStatus))
                    {
                        foreach (TargetConstraint tc in whenUnitIsKilled.unitConstraints)
                        {
                            if (tc is not TargetConstraintHasStatus tcStatus)
                                continue;

                            if (tcStatus.status != originalStatus)
                                continue;

                            var newTc = TargetConstraintHelper.HasStatus(newStatus.name, not: tc.not);

                            whenUnitIsKilled.unitConstraints.RemoveFromArray(tc);
                            whenUnitIsKilled.unitConstraints.AddItem(newTc);
                        }
                    }

                    var applyX = data as StatusEffectApplyX;
                    if ((bool)applyX && applyX.effectToApply.type == originalType)
                        applyX.effectToApply = newStatus;
                    if ((bool)applyX && applyX.targetConstraints.Any(tc => tc is TargetConstraintHasStatus tcStatus && tcStatus.status == originalStatus))
                    {
                        foreach (TargetConstraint tc in applyX.targetConstraints)
                        {
                            if (tc is not TargetConstraintHasStatus tcStatus)
                                continue;

                            if (tcStatus.status != originalStatus)
                                continue;

                            var newTc = TargetConstraintHelper.HasStatus(newStatus.name, not: tc.not);

                            applyX.targetConstraints.RemoveFromArray(tc);
                            applyX.targetConstraints.AddItem(newTc);
                        }
                    }
                    if ((bool)applyX && applyX.contextEqualAmount is ScriptableCurrentStatus scriptable && scriptable.statusType == originalType)
                    {
                        scriptable.statusType = newType;
                    }

                    var bonusDamageEqualToX = data as StatusEffectBonusDamageEqualToX;
                    if ((bool)bonusDamageEqualToX && bonusDamageEqualToX.effectType == originalType)
                        bonusDamageEqualToX.effectType = newType;
                }).Build();
        }
    }
}