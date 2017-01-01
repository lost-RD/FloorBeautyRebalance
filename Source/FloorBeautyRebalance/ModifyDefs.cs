using RimWorld;
using Verse;
using System.Linq;
using System.Collections.Generic;

namespace FloorBeautyRebalance
{
    public static class ModifyDefs
    {
        public static bool loadedWood = false;
        public static bool loadedStone = false;

        public static void doWoodFloors()
        {
            if (!loadedWood)
            {
                TerrainDef woodPlank = DefDatabase<TerrainDef>.GetNamed("WoodPlankFloor", true);
                TerrainDef woodSmooth = DefDatabase<TerrainDef>.GetNamed("WoodPlankFloorSmooth", true);
                TerrainDef woodPolished = DefDatabase<TerrainDef>.GetNamed("WoodPlankFloorPolished", true);

                woodPlank.smoothedTerrain = woodSmooth;
                woodSmooth.smoothedTerrain = woodPolished;

                loadedWood = true;
            }
        }

        public static void doStoneFloors()
        {
            if (!loadedStone)
            {
                float beautySmooth = 0f;
                float beautyPolished = 1f;
                foreach (ThingDef rock in DefDatabase<ThingDef>.AllDefs.Where(def => def.building != null && def.building.isNaturalRock && !def.building.isResourceRock))
                {
                    TerrainDef terrainPolished = new TerrainDef();
                    TerrainDef terrainSmooth = DefDatabase<TerrainDef>.GetNamed(rock.defName + "_Smooth", true);
                    terrainSmooth.SetStatBaseValue(StatDefOf.Beauty, beautySmooth);
                    terrainSmooth.smoothedTerrain = terrainPolished;
                    terrainSmooth.affordances.Add(TerrainAffordance.SmoothableStone);
                    terrainPolished.texturePath = "Terrain/Surfaces/PolishedStone";
                    terrainPolished.edgeType = TerrainDef.TerrainEdgeType.FadeRough;
                    terrainPolished.pathCost = 0;
                    StatUtility.SetStatValueInList(ref terrainPolished.statBases, StatDefOf.Beauty, beautyPolished);
                    terrainPolished.scatterType = "Rocky";
                    terrainPolished.affordances = new List<TerrainAffordance>()
                    {
                        TerrainAffordance.Light,
                        TerrainAffordance.Heavy,
                        TerrainAffordance.SmoothHard
                    };
                    terrainPolished.fertility = 0f;
                    terrainPolished.renderPrecedence = 165;
                    terrainPolished.defName = rock.defName + "_Polished";
                    terrainPolished.label = "FloorBeautyRebalance.PolishedStoneTerrainLabel".Translate(new object[]
                    {
                    rock.label
                    });
                    terrainPolished.description = "FloorBeautyRebalance.PolishedStoneTerrainDesc".Translate(new object[]
                    {
                    rock.label
                    });
                    terrainPolished.color = rock.graphicData.color;

                    terrainPolished.PostLoad();
                    DefDatabase<TerrainDef>.Add(terrainPolished);
                }
                loadedStone = true;
            }
        }
    }
}
