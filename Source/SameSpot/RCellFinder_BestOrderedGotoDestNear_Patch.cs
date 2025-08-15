using HarmonyLib;
using RimWorld;
using Verse;

namespace SameSpot
{
    [HarmonyPatch(typeof(RCellFinder), "BestOrderedGotoDestNear")]
    public static class RCellFinder_BestOrderedGotoDestNear_Patch
    {
        public static bool Prefix(IntVec3 root, Pawn searcher, ref IntVec3 __result)
        {
            if (searcher.Drafted)
            {
                __result = root;
                return false;
            }
            return true;
        }
    }
}