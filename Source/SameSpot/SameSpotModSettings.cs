using UnityEngine;
using Verse;

namespace SameSpot
{
    public class SameSpotModSettings : ModSettings
    {
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref this.enableDragDrop, "enableDragDrop", true, false);
            Scribe_Values.Look<bool>(ref this.hardcoreMode, "hardcoreMode", false, false);
            Scribe_Values.Look<bool>(ref this.walkableMode, "walkableMode", false, false);
            Scribe_Values.Look<int>(ref this.colonistsPerCell, "colonistsPerCell", 0, false);
        }

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard list = new Listing_Standard
            {
                ColumnWidth = inRect.width / 2f
            };
            list.Begin(inRect);
            list.Gap(12f);

            list.CheckboxLabeled("Enable Drag'n Drop", ref this.enableDragDrop, null, 0f, 1f);
            list.CheckboxLabeled("SameSpot also for enemies", ref this.hardcoreMode, null, 0f, 1f);
            list.CheckboxLabeled("Make walkable also standable", ref this.walkableMode, null, 0f, 1f);
            list.Label($"Maximum colonists per cell: {(this.colonistsPerCell == 0 ? "unlimited" : this.colonistsPerCell.ToString())}",-1f,(TipSignal?)null
);
            this.colonistsPerCell = (int)Mathf.Min(20f, list.Slider((float)this.colonistsPerCell + 0.5f, 0f, 21f));

            list.End();
        }

        public bool enableDragDrop = true;

        public bool hardcoreMode = false;

        public bool walkableMode = false;

        public int colonistsPerCell = 0;
    }
}
