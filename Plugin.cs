using BepInEx;
using BepInEx.Logging;
using EasyPackageAPI.Patches;
using HarmonyLib;

namespace EasyPackageAPI;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log;
    
    private void Awake()
    {
        Log = Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} loaded!");
        
        Harmony harmony = new(MyPluginInfo.PLUGIN_NAME);
        harmony.PatchAll(typeof(PayloadManagerPatches));
        harmony.PatchAll(typeof(ShopInfoPatches));
    }
}