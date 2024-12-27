using Verse;
using RimWorld;
using UnityEngine;
using System.Collections.Generic;

namespace SameSpot
{
    public class Colonist
    {
        public Pawn pawn;
        public IntVec3 startPosition;
        public IntVec3 designation;

        public Colonist(Pawn pawn)
        {
            this.pawn = pawn;
            startPosition = pawn.Position;
            designation = IntVec3.Invalid;
        }

        public static void UpdateOrderPos(List<Colonist> colonists, IntVec3 pos)
        {
            // Set a common designation for the first colonist
            if (colonists.Count > 0)
            {
                colonists[0].designation = pos; // Set the designation to the target position
            }
        }

        public void DrawDesignation()
        {
            if (designation.IsValid)
            {
                var matrix = new Matrix4x4();
                matrix.SetTRS(designation.ToVector3() + new Vector3(0.5f, 0f, 0.5f), Quaternion.identity, Vector3.one);
                Graphics.DrawMesh(MeshPool.plane10, matrix, Main.markerMaterial, 0);
            }
        }
    }
}