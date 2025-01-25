using HarmonyLib;
using RimWorld;
using Verse;

namespace ArmoredFloors;

[HarmonyPatch(typeof(InfestationCellFinder), "GetScoreAt")]
internal class InfestationCellFinder_GetScoreAt
{
    public static void Postfix(IntVec3 cell, Map map, ref float __result)
    {
        if (__result > 0f && (map.terrainGrid.TerrainAt(cell).HasTag("InfestationBlocker") ||
                              map.terrainGrid.UnderTerrainAt(cell) != null &&
                              map.terrainGrid.UnderTerrainAt(cell).HasTag("InfestationBlocker")))
        {
            __result = 0f;
        }
    }
}