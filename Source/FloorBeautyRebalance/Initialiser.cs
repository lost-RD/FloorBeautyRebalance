using RimWorld;
using Verse;

namespace FloorBeautyRebalance
{
    public class Initialiser : ThingDef
    {
        public override void ResolveReferences()
        {
            ModifyDefs.doStoneFloors();
            ModifyDefs.doWoodFloors();
        }
    }
}