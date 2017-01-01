using RimWorld;
using Verse;

namespace FloorBeautyRebalance
{
    public class Initialiser : Def
    {
        public override void ResolveReferences()
        {
            ModifyDefs.doStoneFloors();
            ModifyDefs.doWoodFloors();
        }
    }
}