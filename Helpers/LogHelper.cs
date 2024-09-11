using UnityEngine;

namespace Moonlit_Expansion
{
    internal static class LogHelper
    {
        private static string Prefix = "Moonlit";

        public static void Log(string message)
        {
            Debug.Log($"[{Prefix}] {message}");
        }

        public static void Warn(string message)
        {
            Debug.LogWarning($"[{Prefix} Warning] {message}");
        }

        public static void Error(string message)
        {
            Debug.LogError($"[{Prefix} Error] {message}");
        }
    }
}