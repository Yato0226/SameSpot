using Brrainz;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace SameSpot
{
    // Token: 0x02000003 RID: 3
    internal class SameSpotMod : Mod
    {
        // Token: 0x06000004 RID: 4 RVA: 0x0000210B File Offset: 0x0000030B
        public SameSpotMod(ModContentPack content) : base(content)
        {
            SameSpotMod.Settings = base.GetSettings<SameSpotModSettings>();
            SameSpotMod.harmony = new Harmony("net.pardeike.rimworld.mod.samespot");
            SameSpotMod.harmony.PatchAll();
            CrossPromotion.Install(76561197973010050UL);
        }

        // Token: 0x06000005 RID: 5 RVA: 0x0000214A File Offset: 0x0000034A
        public override void DoSettingsWindowContents(Rect inRect)
        {
            SameSpotMod.Settings.DoWindowContents(inRect);
        }

        // Token: 0x06000006 RID: 6 RVA: 0x0000215C File Offset: 0x0000035C
        public override string SettingsCategory()
        {
            return "SameSpot";
        }

        // Token: 0x04000004 RID: 4
        public static SameSpotModSettings Settings;

        // Token: 0x04000005 RID: 5
        public static Harmony harmony;
    }
}
