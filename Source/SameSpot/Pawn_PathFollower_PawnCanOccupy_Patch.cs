using HarmonyLib;
using Verse;
using Verse.AI;

namespace SameSpot
{
    // Token: 0x02000009 RID: 9
    [HarmonyPatch(typeof(Pawn_PathFollower), "PawnCanOccupy")]
    internal static class Pawn_PathFollower_PawnCanOccupy_Patch
    {
        // Token: 0x06000012 RID: 18 RVA: 0x00002484 File Offset: 0x00000684
        [HarmonyPriority(-10000)]
        public static void Postfix(Pawn ___pawn, IntVec3 c, ref bool __result)
        {
            bool flag = __result;
            if (!flag)
            {
                bool flag2 = ___pawn.IsColonist || ___pawn.IsColonyMech || SameSpotMod.Settings.hardcoreMode;
                if (flag2)
                {
                    bool flag3 = c.CustomStandable(___pawn.Map);
                    if (flag3)
                    {
                        __result = true;
                    }
                }
            }
        }
    }
}
