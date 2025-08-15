using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace SameSpot
{
    // Token: 0x0200000D RID: 13
    [HarmonyPatch(typeof(JoyGiver_InteractBuildingInteractionCell), "TryGivePlayJob")]
    internal static class JoyGiver_InteractBuildingInteractionCell_TryGivePlayJob_Patch
    {
        // Token: 0x06000017 RID: 23 RVA: 0x00002704 File Offset: 0x00000904
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return Transpilers.MethodReplacer(Transpilers.MethodReplacer(instructions, AccessTools.Method(typeof(PawnDestinationReservationManager), "IsReserved", new Type[]
            {
                typeof(IntVec3)
            }, null), AccessTools.Method(typeof(Main), "CustomIsReserved", null, null)), AccessTools.Method(typeof(GenGrid), "Standable", null, null), AccessTools.Method(typeof(Main), "CustomStandable", null, null));
        }
    }
}
