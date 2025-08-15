using HarmonyLib;
using Verse;

namespace SameSpot
{
    // Token: 0x02000006 RID: 6
    [HarmonyPatch(typeof(GenGrid), "Standable")]
    internal static class GenGrid_Standable_Patch
    {
        // Token: 0x0600000E RID: 14 RVA: 0x00002354 File Offset: 0x00000554
        [HarmonyPriority(-10000)]
        public static void Postfix(IntVec3 c, Map map, ref bool __result)
        {
            bool flag = __result;
            if (!flag)
            {
                bool walkableMode = SameSpotMod.Settings.walkableMode;
                if (walkableMode)
                {
                    __result = GenGrid.Walkable(c, map);
                }
            }
        }
    }
}
