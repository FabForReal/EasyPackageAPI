using System.Collections.Generic;
using UnityEngine;

namespace EasyPackageAPI.Core;

public static class PackageRegister
{
    public static List<Package> Packages = [];

    // this is not really ideal imo and will break if an update adds new packages or another mod modifies the payloads array
    private const int baseIndex = 17; // current (1.12c) vanilla payloadmanager payload array length - 1
    private static int currentIndexCount = -1;

    public static void RegisterPackage(GameObject package, string[] shops)
    {
        Packages.Add(new Package(package, shops, AddIndex()));
    }
    
    public static void RegisterPackage(GameObject package, string shop)
    {
        Packages.Add(new Package(package, [shop] , AddIndex()));
    }

    private static int AddIndex()
    {
        if (currentIndexCount == -1)
        {
            currentIndexCount = baseIndex;
        }
        currentIndexCount++;
        return currentIndexCount;
    }
}

public class Package(GameObject gameObject, string[] shops, int index)
{
    public GameObject GameObject {get; private set;} = gameObject;
    public string[] Shops { get; private set; } = shops;
    
    public int PayloadIndex { get; private set; } = index;
}