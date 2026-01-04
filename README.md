# EasyPackageAPI

API for adding custom packages to easy delivery co.

This mod does not add any packages of its own

## How To Use

### Example

```csharp
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
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
    
    private void RegisterPackages()
    {
        // add a package to multiple shops
        PackageRegister.RegisterPackage(packageOne,
            [Shops.Pawn_Shop, Shops.Easy_Depot,
                Shops.Bar, Shops.EZ_Bakery, Shops.Easy_Flowers]);
        
        // add a package to one shop
        PackageRegister.RegisterPackage(packageTwo, Shops.Easy_Depot);
    }
}
```