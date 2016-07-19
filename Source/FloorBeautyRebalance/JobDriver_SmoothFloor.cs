using RimWorld;
using Verse;

namespace FloorBeautyRebalance
{
	public class JobDriver_SmoothFloor : JobDriver_AffectFloor
	{
		protected override int BaseWorkAmount
		{
			get
			{
				return 400;
			}
		}

		protected override DesignationDef DesDef
		{
			get
			{
				return DesignationDefOf.SmoothFloor;
			}
		}

		protected override StatDef SpeedStat
		{
			get
			{
				return StatDefOf.SmoothingSpeed;
			}
		}

		public JobDriver_SmoothFloor()
		{
			this.clearSnow = true;
		}

		protected override void DoEffect(IntVec3 c)
		{
			TerrainDef smoothedTerrain = base.TargetLocA.GetTerrain().smoothedTerrain;
			Find.TerrainGrid.SetTerrain(base.TargetLocA, smoothedTerrain);
		}
	}
}