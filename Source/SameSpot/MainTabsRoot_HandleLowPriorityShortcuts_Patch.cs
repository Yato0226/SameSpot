using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace SameSpot
{
    [HarmonyPatch(typeof(MainTabsRoot))]
    [HarmonyPatch("HandleLowPriorityShortcuts")]
    internal static class MainTabsRoot_HandleLowPriorityShortcuts_Patch
    {
        [HarmonyPriority(800)]
        public static void Prefix()
        {
            bool enableDragDrop = SameSpotMod.Settings.enableDragDrop;
            if (enableDragDrop)
            {
                bool flag = Event.current.button == 0;
                if (flag)
                {
                    bool flag2 = Event.current.type == 0;
                    if (flag2)
                    {
                        bool flag3 = Event.current.clickCount == 1;
                        if (flag3)
                        {
                            MainTabsRoot_HandleLowPriorityShortcuts_Patch.MouseDown();
                        }
                    }
                }
            }
        }

        [HarmonyPriority(-10000)]
        public static void Postfix()
        {
            if (!SameSpotMod.Settings.enableDragDrop)
            {
                return;
            }

            Event currentEvent = Event.current;

            if (currentEvent.button == 0)
            {
                if (currentEvent.type == EventType.MouseDrag)
                {
                    MainTabsRoot_HandleLowPriorityShortcuts_Patch.MouseDrag();
                }
                else if (currentEvent.type == EventType.MouseUp)
                {
                    MainTabsRoot_HandleLowPriorityShortcuts_Patch.MouseUp();
                }
            }
        }

        private static bool UsefulColonist(Pawn pawn)
        {
            return pawn.drafter != null && pawn.jobs != null && ((pawn.IsColonist && pawn.IsColonistPlayerControlled) || (pawn.IsColonyMech && pawn.IsColonyMechPlayerControlled)) && !pawn.Downed && pawn.drafter.Drafted && pawn.jobs.IsCurrentJobPlayerInterruptible();
        }

        private static List<Colonist> SelectedColonists()
        {
            return (from colonist in Find.Selector.SelectedObjects.OfType<Pawn>().Where(new Func<Pawn, bool>(MainTabsRoot_HandleLowPriorityShortcuts_Patch.UsefulColonist))
                    select new Colonist(colonist)).ToList<Colonist>();
        }

        private static IEnumerable<Pawn> ColonistsAt(Map map, IntVec3 cell)
        {
            bool flag = !GenGrid.InBounds(cell, map);
            IEnumerable<Pawn> result;
            if (flag)
            {
                result = new List<Pawn>();
            }
            else
            {
                List<Thing> things = map.thingGrid.ThingsListAtFast(cell);
                bool flag2 = things == null;
                if (flag2)
                {
                    result = new List<Pawn>();
                }
                else
                {
                    result = things.OfType<Pawn>().Where(new Func<Pawn, bool>(MainTabsRoot_HandleLowPriorityShortcuts_Patch.UsefulColonist));
                }
            }
            return result;
        }

        private static readonly MethodInfo Selector_SelectUnderMouse_MethodInfo;

        static MainTabsRoot_HandleLowPriorityShortcuts_Patch()
        {
            Selector_SelectUnderMouse_MethodInfo =
                typeof(Selector).GetMethod("SelectUnderMouse", BindingFlags.NonPublic | BindingFlags.Instance);

            if (Selector_SelectUnderMouse_MethodInfo == null)
            {
                Log.Error("SameSpot Mod: Reflection failed to find private method 'SelectUnderMouse' in Verse.Selector.");
            }
        }


        private static void MouseDown()
        {
            if (Selector_SelectUnderMouse_MethodInfo == null) return;

            if (Main.dragStart.IsValid) return;

            Map map = Find.CurrentMap;
            if (map == null) return;

            IntVec3 mouseCell = UI.MouseCell();
            IEnumerable<Pawn> colonistsUnderMouse = MainTabsRoot_HandleLowPriorityShortcuts_Patch.ColonistsAt(map, mouseCell);

            if (!colonistsUnderMouse.Any()) return;

            Main.dragStart = mouseCell;
            Main.lastCell = mouseCell;

            Selector selector = Find.Selector;
            selector.dragBox.active = false;

            if (!colonistsUnderMouse.Any((Pawn colonist) => selector.IsSelected(colonist)))
            {
                Selector_SelectUnderMouse_MethodInfo.Invoke(selector, null);
            }
            Event.current.Use();
        }


        private static void MouseDrag()
        {
            bool flag = !Main.dragStart.IsValid;
            if (!flag)
            {
                IntVec3 mouseCell = UI.MouseCell();
                bool flag2 = mouseCell == Main.lastCell;
                if (!flag2)
                {
                    bool flag3 = Main.draggedColonists.Count == 0;
                    if (flag3)
                    {
                        Main.draggedColonists = MainTabsRoot_HandleLowPriorityShortcuts_Patch.SelectedColonists();
                    }
                    bool flag4 = Main.draggedColonists.Count > 0;
                    if (flag4)
                    {
                        CollectionExtensions.Do<Colonist>(Main.draggedColonists, delegate (Colonist colonist)
                        {
                            IntVec3 newPosition = colonist.startPosition + mouseCell - Main.dragStart;
                            colonist.designation = newPosition;
                        });
                        Main.lastCell = mouseCell;
                    }
                    Event.current.Use();
                }
            }
        }

        private static void MouseUp()
        {
            bool flag = !Main.dragStart.IsValid;
            if (!flag)
            {
                CollectionExtensions.Do<Colonist>(Main.draggedColonists, delegate (Colonist colonist)
                {
                    bool flag2 = GenGrid.Walkable(colonist.designation, colonist.pawn.Map);
                    if (flag2)
                    {
                        bool flag3 = colonist.startPosition != colonist.designation;
                        if (flag3)
                        {
                            Job job = JobMaker.MakeJob(JobDefOf.Goto, colonist.designation);
                            bool flag4 = colonist.pawn.jobs.IsCurrentJobPlayerInterruptible();
                            if (flag4)
                            {
                                colonist.pawn.jobs.TryTakeOrderedJob(job, new JobTag?(0), false);
                            }
                        }
                    }
                });
                Main.dragStart = IntVec3.Invalid;
                Main.lastCell = IntVec3.Invalid;
                Main.draggedColonists = new List<Colonist>();
                Event.current.Use();
            }
        }
    }
}
