using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace SameSpot
{
    public class Colonist
    {
        public Colonist(Pawn pawn)
        {
            this.pawn = pawn;
            this.startPosition = pawn.Position;
            this.designation = IntVec3.Invalid;
        }

        public static void UpdateOrderPos(List<Colonist> colonists, IntVec3 pos)
        {
            bool flag = colonists.Count > 0;
            if (flag)
            {
                colonists[0].designation = pos;
            }
        }

        public void DrawDesignation()
        {
            bool isValid = this.designation.IsValid;
            if (isValid)
            {
                Matrix4x4 matrix = default(Matrix4x4);
                matrix.SetTRS(this.designation.ToVector3() + new Vector3(0.5f, 0f, 0.5f), Quaternion.identity, Vector3.one);
                Graphics.DrawMesh(MeshPool.plane10, matrix, Main.markerMaterial, 0);
            }
        }

        public Pawn pawn;

        public IntVec3 startPosition;

        public IntVec3 designation;
    }
}
