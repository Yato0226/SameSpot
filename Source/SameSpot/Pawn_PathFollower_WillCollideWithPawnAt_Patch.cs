using HarmonyLib;
using Verse;
using Verse.AI;

namespace SameSpot
{
    // Token: 0x02000008 RID: 8
    [HarmonyPatch(typeof(Pawn_PathFollower), "WillCollideWithPawnAt")]
    internal static class Pawn_PathFollower_WillCollideWithPawnAt_Patch
    {
        // Token: 0x06000011 RID: 17 RVA: 0x00002448 File Offset: 0x00000648
        public static bool Prefix(Pawn ___pawn, ref bool __result)
        {
            bool flag = ___pawn.IsColonist || ___pawn.IsColonyMech || SameSpotMod.Settings.hardcoreMode;
            bool result;
            if (flag)
            {
                __result = false;
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
