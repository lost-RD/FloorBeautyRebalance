using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace FloorBeautyRebalance
{
    public class Designator_SmoothFloor : Designator
    {
        public override bool DragDrawMeasurements
        {
            get
            {
                return true;
            }
        }

        public override int DraggableDimensions
        {
            get
            {
                return 2;
            }
        }

        public Designator_SmoothFloor()
        {
            this.defaultLabel = "FloorBeautyRebalance.DesignatorSmoothFloor".Translate();
            this.defaultDesc = "FloorBeautyRebalance.DesignatorSmoothFloorDesc".Translate();
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/SmoothFloor", true);
            this.useMouseIcon = true;
            this.soundDragSustain = SoundDefOf.DesignateDragStandard;
            this.soundDragChanged = SoundDefOf.DesignateDragStandardChanged;
            this.soundSucceeded = SoundDefOf.DesignateSmoothFloor;
            this.hotKey = KeyBindingDefOf.Misc1;
        }

        public override AcceptanceReport CanDesignateCell(IntVec3 c)
        {
            if (!c.InBounds(base.Map))
            {
                return false;
            }
            if (c.Fogged(base.Map))
            {
                return false;
            }
            if (base.Map.designationManager.DesignationAt(c, DesignationDefOf.SmoothFloor) != null)
            {
                return "TerrainBeingSmoothed".Translate();
            }
            if (c.InNoBuildEdgeArea(base.Map))
            {
                return "TooCloseToMapEdge".Translate();
            }
            Building edifice = c.GetEdifice(base.Map);
            if (edifice != null && edifice.def.Fillage == FillCategory.Full && edifice.def.passability == Traversability.Impassable)
            {
                return false;
            }
            if (c.GetTerrain(base.Map).affordances.Contains(TerrainAffordance.SmoothableStone))
            {
                return AcceptanceReport.WasAccepted;
            }
            return "FloorBeautyRebalance.MessageMustDesignateSmoothableFloor".Translate();
        }

        public override void DesignateSingleCell(IntVec3 c)
        {
            base.Map.designationManager.AddDesignation(new Designation(c, DesignationDefOf.SmoothFloor));
        }

        public override void SelectedUpdate()
        {
            GenUI.RenderMouseoverBracket();
        }
    }
}