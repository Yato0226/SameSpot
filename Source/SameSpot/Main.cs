using System.Collections.Generic;
using System.Linq;
using System.Reflection;    
using System.Runtime.CompilerServices;
using RimWorld;
using UnityEngine;
using Verse;

namespace SameSpot
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        private static readonly FieldInfo PawnDestinationReservationManager_reservedDestinations_FieldInfo;

        static Main()
        {
            PawnDestinationReservationManager_reservedDestinations_FieldInfo =
                typeof(PawnDestinationReservationManager).GetField("reservedDestinations", BindingFlags.NonPublic | BindingFlags.Instance);

            if (PawnDestinationReservationManager_reservedDestinations_FieldInfo == null)
            {
                Log.Error("SameSpot Mod: Could not find the private field 'reservedDestinations' in PawnDestinationReservationManager. The mod may not work correctly.");
            }
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool CustomStandable(this IntVec3 c, Map map)
        {
            bool walkableMode = SameSpotMod.Settings.walkableMode;
            bool result;
            if (walkableMode)
            {
                result = GenGrid.Walkable(c, map);
            }
            else
            {
                Building edifice = GridsUtility.GetEdifice(c, map);
                result = (edifice == null || edifice is Building_Door);
            }
            return result;
        }

        public static bool CustomIsReserved(this PawnDestinationReservationManager instance, IntVec3 loc)
        {
            if (SameSpotMod.Settings.colonistsPerCell == 0)
            {
                return false;
            }

            if (PawnDestinationReservationManager_reservedDestinations_FieldInfo == null)
            {
                return false;
            }

            var reservedDestinations = (Dictionary<Faction, PawnDestinationReservationManager.PawnDestinationSet>)PawnDestinationReservationManager_reservedDestinations_FieldInfo.GetValue(instance);

            int count = reservedDestinations.SelectMany((KeyValuePair<Faction, PawnDestinationReservationManager.PawnDestinationSet> pair) => pair.Value.list).Count((PawnDestinationReservationManager.PawnDestinationReservation res) => !res.obsolete && res.target == loc);
            return (count >= SameSpotMod.Settings.colonistsPerCell);
        }

        public static bool CustomCanReserve(this PawnDestinationReservationManager instance, IntVec3 c, Pawn searcher, bool draftedOnly)
        {
            if (SameSpotMod.Settings.colonistsPerCell == 0)
            {
                return true;
            }

            if (PawnDestinationReservationManager_reservedDestinations_FieldInfo == null)
            {
                return true;
            }

            var reservedDestinations = (Dictionary<Faction, PawnDestinationReservationManager.PawnDestinationSet>)PawnDestinationReservationManager_reservedDestinations_FieldInfo.GetValue(instance);

            int count = reservedDestinations.SelectMany((KeyValuePair<Faction, PawnDestinationReservationManager.PawnDestinationSet> pair) => pair.Value.list).Count((PawnDestinationReservationManager.PawnDestinationReservation res) => !res.obsolete && res.claimant != searcher && res.target == c);
            return (count < SameSpotMod.Settings.colonistsPerCell);
        }

        public static List<Thing> GetThingList(this IntVec3 c, Map map)
        {
            return new List<Thing>();
        }

        public static void HandleRightClick(List<Colonist> selectedColonists, IntVec3 targetPosition)
        {
            bool isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            if (isShiftPressed)
            {
                Colonist.UpdateOrderPos(selectedColonists, targetPosition);
            }
        }

        public static IntVec3 lastCell = IntVec3.Invalid;

        public static IntVec3 dragStart = IntVec3.Invalid;

        public static List<Colonist> draggedColonists = new List<Colonist>();

        public static readonly Material markerMaterial = MaterialPool.MatFrom("SameSpotMarker");
    }
}