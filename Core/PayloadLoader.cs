using System.Linq;

namespace EasyPackageAPI.Core;

internal static class PayloadLoader
{
    public static void Load(PayloadManager payloadManager)
    {
        if (PackageRegister.Packages == null) return;

        foreach (Package p in PackageRegister.Packages)
        {
            if (payloadManager.payloads.Contains(p.GameObject)) return;
            
            payloadManager.payloads = Util.AddElementToArray(payloadManager.payloads, p.GameObject);
        }
    }
}