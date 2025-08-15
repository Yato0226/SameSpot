using HarmonyLib;
using Verse.AI;

namespace SameSpot
{
    // Token: 0x0200000A RID: 10
    [HarmonyPatch(typeof(JobDriver_Goto), "TryMakePreToilReservations")]
    internal static class JobDriver_Goto_TryMakePreToilReservations_Patch
    {
        // Token: 0x06000013 RID: 19 RVA: 0x000024D0 File Offset: 0x000006D0
        public static bool Prefix(JobDriver_Goto __instance, ref bool __result)
        {
            bool flag = SameSpotMod.Settings.colonistsPerCell == 0 && (__instance.pawn.IsColonist || __instance.pawn.IsColonyMech || SameSpotMod.Settings.hardcoreMode);
            bool result;
            if (flag)
            {
                __result = true;
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
    }
}
