using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace SameSpot
{
    [StaticConstructorOnStartup]
    internal static class ModCompatibility
    {
        static ModCompatibility()
        {
            LongEventHandler.QueueLongEvent(ApplyCompatibilityPatches, "SameSpot: Applying Compatibility Patches", false, null);
        }

        private static void ApplyCompatibilityPatches()
        {
            MethodInfo originalStandableMethod = AccessTools.Method(typeof(GenGrid), "Standable", new Type[] { typeof(IntVec3), typeof(Map) });

            MethodInfo customStandableMethod = AccessTools.Method(typeof(Main), "CustomStandable", new Type[] { typeof(IntVec3), typeof(Map) });

            if (originalStandableMethod == null)
            {
                Log.Error("SameSpot Mod: Could not find method GenGrid.Standable to apply compatibility patches.");
                return;
            }
            if (customStandableMethod == null)
            {
                Log.Error("SameSpot Mod: Could not find method Main.CustomStandable to apply compatibility patches.");
                return;
            }

            Patches appliedPatches = Harmony.GetPatchInfo(originalStandableMethod);
            if (appliedPatches == null)
            {
                return;
            }

            foreach (Patch patch in appliedPatches.Prefixes)
            {
                if (patch.owner == SameSpotMod.harmony.Id) continue;

                Log.Message($"SameSpot: Applying compatibility Prefix from {patch.owner} to {customStandableMethod.Name}");
                SameSpotMod.harmony.Patch(customStandableMethod, new HarmonyMethod(patch.PatchMethod, patch.priority));
            }

            foreach (Patch patch in appliedPatches.Postfixes)
            {
                if (patch.owner == SameSpotMod.harmony.Id) continue;

                Log.Message($"SameSpot: Applying compatibility Postfix from {patch.owner} to {customStandableMethod.Name}");
                SameSpotMod.harmony.Patch(customStandableMethod, null, new HarmonyMethod(patch.PatchMethod, patch.priority));
            }
        }
    }
}