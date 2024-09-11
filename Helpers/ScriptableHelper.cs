using System;
using UnityEngine;

namespace Moonlit_Expansion.Helpers
{
    internal static class ScriptableHelper
    {
        public static T CreateScriptable<T>(string name, Action<T> modification = null) where T : ScriptableObject
        {
            var data = ScriptableObject.CreateInstance<T>();
            data.name = name;
            modification?.Invoke(data);
            return data;
        }
    }
}