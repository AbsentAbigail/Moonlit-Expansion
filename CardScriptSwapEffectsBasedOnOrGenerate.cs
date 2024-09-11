using Moonlit_Expansion.Helpers;
using UnityEngine;

namespace Moonlit_Expansion
{
    internal class CardScriptSwapEffectsBasedOnOrGenerate : CardScript
    {
        [SerializeField]
        public StatusEffectData statusA;

        [SerializeField]
        public StatusEffectData statusB;

        public string keywordA;

        public string keywordB;

        public override void Run(CardData target)
        {
            CardData.StatusEffectStacks[] attackEffects = target.attackEffects;
            foreach (CardData.StatusEffectStacks statusEffectStacks in attackEffects)
            {
                if (statusEffectStacks.data.type == statusA.type)
                {
                    statusEffectStacks.data = statusB;
                }
                else if (statusEffectStacks.data.type == statusB.type)
                {
                    statusEffectStacks.data = statusA;
                }
                else if (statusEffectStacks.data is StatusEffectInstantDoubleX effect)
                {
                    TrySwap(effect, statusEffectStacks, statusA, statusB, keywordA, keywordB);
                }
            }

            attackEffects = target.startWithEffects;
            foreach (CardData.StatusEffectStacks statusEffectStacks2 in attackEffects)
            {
                StatusEffectData data = statusEffectStacks2.data;
                if (data is not StatusEffectApplyXWhenYAppliedTo effect2)
                {
                    if (data is not StatusEffectApplyXWhenYAppliedToAlly effect3)
                    {
                        if (data is not StatusEffectApplyXWhenYAppliedToSelf effect4)
                        {
                            if (data is not StatusEffectApplyX effect5)
                            {
                                if (data is StatusEffectBonusDamageEqualToX effect6)
                                {
                                    TrySwap(effect6, statusEffectStacks2, statusA, statusB, keywordA, keywordB);
                                }
                            }
                            else
                            {
                                TrySwap(effect5, statusEffectStacks2, statusA, statusB, keywordA, keywordB);
                            }
                        }
                        else
                        {
                            TrySwap(effect4, statusEffectStacks2, statusA, statusB, keywordA, keywordB);
                        }
                    }
                    else
                    {
                        TrySwap(effect3, statusEffectStacks2, statusA, statusB, keywordA, keywordB);
                    }
                }
                else
                {
                    TrySwap(effect2, statusEffectStacks2, statusA, statusB, keywordA, keywordB);
                }
            }
        }

        public static void TrySwap(StatusEffectInstantDoubleX effect, CardData.StatusEffectStacks stacks, StatusEffectData a, StatusEffectData b, string kwA, string kwB)
        {
            if ((bool)effect.statusToDouble)
            {
                if (effect.statusToDouble.type == a.type)
                {
                    SwapOrGenerate(stacks, a, b, kwA, kwB);
                }
                else if (effect.statusToDouble.type == b.type)
                {
                    SwapOrGenerate(stacks, b, a, kwB, kwA);
                }
            }
        }

        public static void TrySwap(StatusEffectApplyX effect, CardData.StatusEffectStacks stacks, StatusEffectData a, StatusEffectData b, string kwA, string kwB)
        {
            if ((bool)effect.effectToApply)
            {
                if (effect.effectToApply.type == a.type)
                {
                    SwapOrGenerate(stacks, a, b, kwA, kwB);
                }
                else if (effect.effectToApply.type == b.type)
                {
                    SwapOrGenerate(stacks, b, a, kwB, kwA);
                }
            }
        }

        public static void TrySwap(StatusEffectApplyXWhenYAppliedTo effect, CardData.StatusEffectStacks stacks, StatusEffectData a, StatusEffectData b, string kwA, string kwB)
        {
            if (effect.whenAppliedTypes.Contains(a.type) || ((bool)effect.effectToApply && effect.effectToApply.type == a.type))
            {
                SwapOrGenerate(stacks, a, b, kwA, kwB);
            }
            else if (effect.whenAppliedTypes.Contains(b.type) || ((bool)effect.effectToApply && effect.effectToApply.type == b.type))
            {
                SwapOrGenerate(stacks, b, a, kwB, kwA);
            }
        }

        public static void TrySwap(StatusEffectApplyXWhenYAppliedToAlly effect, CardData.StatusEffectStacks stacks, StatusEffectData a, StatusEffectData b, string kwA, string kwB)
        {
            if (effect.whenAppliedType == a.type || ((bool)effect.effectToApply && effect.effectToApply.type == a.type))
            {
                SwapOrGenerate(stacks, a, b, kwA, kwB);
            }
            else if (effect.whenAppliedType == b.type || ((bool)effect.effectToApply && effect.effectToApply.type == b.type))
            {
                SwapOrGenerate(stacks, b, a, kwB, kwA);
            }
        }

        public static void TrySwap(StatusEffectApplyXWhenYAppliedToSelf effect, CardData.StatusEffectStacks stacks, StatusEffectData a, StatusEffectData b, string kwA, string kwB)
        {
            if (effect.whenAppliedType == a.type || ((bool)effect.effectToApply && effect.effectToApply.type == a.type))
            {
                SwapOrGenerate(stacks, a, b, kwA, kwB);
            }
            else if (effect.whenAppliedType == b.type || ((bool)effect.effectToApply && effect.effectToApply.type == b.type))
            {
                SwapOrGenerate(stacks, b, a, kwB, kwA);
            }
        }

        public static void TrySwap(StatusEffectBonusDamageEqualToX effect, CardData.StatusEffectStacks stacks, StatusEffectData a, StatusEffectData b, string kwA, string kwB)
        {
            if (effect.effectType == a.type)
            {
                SwapOrGenerate(stacks, a, b, kwA, kwB);
            }
            else if (effect.effectType == b.type)
            {
                SwapOrGenerate(stacks, b, a, kwB, kwA);
            }
        }

        public static bool SwapOrGenerate(
                CardData.StatusEffectStacks stacks,
                StatusEffectData statusOriginal, StatusEffectData statusReplace,
                string keywordOriginal, string keywordReplace
            )
        {
            var created = DynamicStatusHelper.CopyStatusWithEffectSwap(stacks.data, statusOriginal, statusReplace, keywordOriginal, keywordReplace, out bool existed);

            if (!existed)
            {
                DynamicStatusHelper.AppendLine(
                    DynamicStatusHelper.DynamicStatus.FromArray(
                        stacks.data.name, // Original Name
                        statusOriginal.name,
                        statusReplace.name,
                        keywordOriginal,
                        keywordReplace
                    )
                );
                AddressableLoader.AddToGroup(typeof(StatusEffectData).Name, created);
            }
            stacks.data = created;
            return true;
        }
    }
}