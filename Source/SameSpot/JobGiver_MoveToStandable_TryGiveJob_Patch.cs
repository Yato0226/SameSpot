using System.Collections.Generic;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace SameSpot
{
    [HarmonyPatch(typeof(JobGiver_MoveToStandable), "TryGiveJob")]
    internal static class JobGiver_MoveToStandable_TryGiveJob_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            return Transpilers.MethodReplacer(instructions, AccessTools.Method(typeof(GridsUtility), "GetThingList", null, null), AccessTools.Method(typeof(Main), "GetThingList", null, null));
        }
    }
}
