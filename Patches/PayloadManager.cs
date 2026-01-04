using EasyPackageAPI.Core;
using HarmonyLib;

namespace EasyPackageAPI.Patches;

internal class PayloadManagerPatches
{
    [HarmonyPatch(typeof(PayloadManager), "Awake")]
    [HarmonyPostfix]
    private static void AwakePatch(PayloadManager __instance)
    {
        PayloadLoader.Load(__instance);
    }
}