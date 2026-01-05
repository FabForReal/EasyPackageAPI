# EasyPackageAPI

API for easily adding custom packages to easy delivery co.

This mod does not add any packages of its own.

## How To Use

### Preamble

The registering of a custom package with the API is extremely easy, however the setup for the creation
of prefabs is a quite tedious process.

I'm not going into details for this rn, but basically you would need to do these things:
1. Extract the assets using a tool from the game
2. Create a Unity project and import the required assets for a package
3. Use an existing prefab as a template and modify it however you want
(makes it easier than recreating one from scratch)
4. Export your package(s) as a Asset Bundle

### Loading And Registering

#### Example Plugin.cs
```csharp
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(EasyPackageAPI.MyPluginInfo.PLUGIN_GUID)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log;
    
    private static AssetBundle myAssetBundle;
        
    private static GameObject packageOne;
    private static GameObject packageTwo;
        
    private void Awake()
    {
        Log = Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} loaded!");
        
        LoadAssets()
        RegisterPackages()
    }
    
    // for loading your asset bundle. you can do this however you want
    private void LoadAssets()
    {
        // ideally put your assets in a assets sub directory but it can be anywhere
        string assetFolder = Path.Combine(Path.GetDirectoryName
            (Assembly.GetExecutingAssembly().Location)!, "Assets");
        
        // the string has to match the file name of your asset bundle
        myAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetFolder, "AssetBundle"));
        
        // the string has to match the name of your gameobject
        packageOne = myAssetBundle.LoadAsset<GameObject>("Package One");
        packageTwo = myAssetBundle.LoadAsset<GameObject>("Package Two");
    }
    
    // registering your packages
    private void RegisterPackages()
    {
        // add a package to multiple shops
        PackageRegistry.Register(packageOne,
            [Shops.Pawn_Shop, Shops.Easy_Depot,
                Shops.Bar, Shops.EZ_Bakery, Shops.Easy_Flowers]);
        
        // add a package to one shop
        PackageRegistry.Register(packageTwo, Shops.Easy_Depot);
    }
}
```
