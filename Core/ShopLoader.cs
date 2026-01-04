using System.Linq;

namespace EasyPackageAPI.Core;
 
internal static class ShopLoader 
{ 
     public static void Load(ShopInfo shopInfo)
     {
         if (PackageRegister.Packages == null) return;

         foreach (Package p in PackageRegister.Packages)
         {
             if (shopInfo.payloads.Contains(p.GameObject)) return;
             
             foreach (string shop in p.Shops)
             {
                 if (shopInfo.name != shop) continue;
                 
                 // pretty sure the payloads array is actually unused, but we still add it for good practice
                 shopInfo.payloads = Util.AddElementToArray(shopInfo.payloads,  p.GameObject);
                 
                 // the value needs to be the position of the gameobject in the payloadmanager payload array
                 // i think if we want to increase the probability of the package to spawn we can add it multiple times
                 shopInfo.payloadIndexes = Util.AddElementToArray(shopInfo.payloadIndexes, p.PayloadIndex);
                     
                 Plugin.Log.LogInfo($"package added {shopInfo.name}: {p.GameObject.name} / {p.PayloadIndex}");
             }
         }
     }
}