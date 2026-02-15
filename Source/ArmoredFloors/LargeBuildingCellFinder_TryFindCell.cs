using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ArmoredFloors;

[HarmonyPatch(typeof(LargeBuildingCellFinder), nameof(LargeBuildingCellFinder.TryFindCell))]
internal class LargeBuildingCellFinder_TryFindCell
{
    public static void Prefix(Map map, LargeBuildingSpawnParms parms, ref Predicate<IntVec3> extraValidator)
    {
        if (parms.thingDef != ThingDefOf.PitGate)
        {
            return;
        }

        extraValidator = c => !map.terrainGrid.TerrainAt(c).HasTag("InfestationBlocker") &&
                              (map.terrainGrid.UnderTerrainAt(c) == null ||
                               !map.terrainGrid.UnderTerrainAt(c).HasTag("InfestationBlocker"));
    }
}