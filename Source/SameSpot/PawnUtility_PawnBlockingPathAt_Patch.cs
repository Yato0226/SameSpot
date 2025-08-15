using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace SameSpot
{
    [HarmonyPatch(typeof(PawnUtility), "PawnBlockingPathAt")]
    internal static class PawnUtility_PawnBlockingPathAt_Patch
    {
        public static bool Prefix(ref Pawn __result, Pawn forPawn)
        {
            bool flag = forPawn.IsColonist || forPawn.IsColonyMech || SameSpotMod.Settings.hardcoreMode;
            bool result;
            if (flag)
            {
                __result = null;
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public static void Postfix(ref Pawn __result, IntVec3 c, Pawn forPawn)
        {
            bool flag = __result != null || SameSpotMod.Settings.colonistsPerCell == 0;
            if (!flag)
            {
                Map map = forPawn.Map;
                IEnumerable<Pawn> otherPawns = from pawn in map.thingGrid.ThingsListAtFast(c).OfType<Pawn>()
                                               where pawn != forPawn && (pawn.IsColonist || pawn.IsColonyMech || SameSpotMod.Settings.hardcoreMode)
                                               select pawn;
                bool flag2 = otherPawns.Count<Pawn>() >= SameSpotMod.Settings.colonistsPerCell;
                if (flag2)
                {
                    __result = otherPawns.First<Pawn>();
                }
            }
        }
    }
}
