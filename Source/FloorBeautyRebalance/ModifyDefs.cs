using RimWorld;
using Verse;

namespace FloorBeautyRebalance
{
    [StaticConstructorOnStartup]
    public class ModifyDefs
    {

        public static void ModifyWoodPlanks()
        {
            float beauty = 2f;
            DefDatabase<TerrainDef>.GetNamed("WoodPlankFloor", true).SetStatBaseValue(StatDefOf.Beauty, beauty);
        }

        public static void ModifySmoothedStone()
        {
            float beauty = 1f;
            DefDatabase<TerrainDef>.GetNamed("Sandstone_Smooth", true).SetStatBaseValue(StatDefOf.Beauty, beauty);
            DefDatabase<TerrainDef>.GetNamed("Limestone_Smooth", true).SetStatBaseValue(StatDefOf.Beauty, beauty);
            DefDatabase<TerrainDef>.GetNamed("Granite_Smooth", true).SetStatBaseValue(StatDefOf.Beauty, beauty);
            DefDatabase<TerrainDef>.GetNamed("Marble_Smooth", true).SetStatBaseValue(StatDefOf.Beauty, beauty);
            DefDatabase<TerrainDef>.GetNamed("Slate_Smooth", true).SetStatBaseValue(StatDefOf.Beauty, beauty);
        }

        static ModifyDefs()
        {
            ModifyWoodPlanks();
            ModifySmoothedStone();
        }
    }
}
