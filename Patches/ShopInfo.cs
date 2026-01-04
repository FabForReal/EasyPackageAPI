using EasyPackageAPI.Core;
using HarmonyLib;

namespace EasyPackageAPI.Patches;

internal class ShopInfoPatches
{
    [HarmonyPatch(typeof(ShopInfo), "Awake")]
    [HarmonyPostfix]
    private static void AwakePatch(ShopInfo __instance)
    {
        ShopLoader.Load(__instance);
    }
}