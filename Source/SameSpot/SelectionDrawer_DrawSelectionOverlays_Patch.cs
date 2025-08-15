 using HarmonyLib;
using RimWorld;

namespace SameSpot
{
    // Token: 0x0200000E RID: 14
    [HarmonyPatch(typeof(SelectionDrawer))]
    [HarmonyPatch("DrawSelectionOverlays")]
    internal static class SelectionDrawer_DrawSelectionOverlays_Patch
    {
        // Token: 0x06000018 RID: 24 RVA: 0x0000278C File Offset: 0x0000098C
        public static void Postfix()
        {
            bool enableDragDrop = SameSpotMod.Settings.enableDragDrop;
            if (enableDragDrop)
            {
                bool isValid = Main.dragStart.IsValid;
                if (isValid)
                {
                    CollectionExtensions.Do<Colonist>(Main.draggedColonists, delegate (Colonist colonist)
                    {
                        colonist.DrawDesignation();
                    });
                }
            }
        }
    }
}
