# GitHub Copilot Instructions for Armored Floors (Continued) Mod

## Mod Overview and Purpose

Armored Floors (Continued) is a RimWorld mod that provides armored floors and foundations to protect your base from infestations caused by burrowing bugs and overhead mountains. It is an updated version of The Codewarrior's original mod, with enhancements and additional features. The mod allows players to add armored plating to their floors, making them infestation-proof. Additionally, if the Anomaly mod is installed, it will block the Pit Gate.

## Key Features and Systems

- **Armored Floors**: Players can add armor plating to floors to prevent infestations. These armored floors are moderately expensive, requiring four steel and two plasteel per tile.
- **Armored Foundations**: A new feature that allows players to have armored floor effects for all floors, making them infestation-proof.
- **Infestation Blocking**: Armored floors prevent infestations on tiles with overhead mountains. However, hives can still spawn nearby if an infestation event occurs.
- **Compatibility with Anomaly Mod**: If the Anomaly mod is installed, armored floors will block the Pit Gate.

## Coding Patterns and Conventions

- **Modding Framework**: The mod is built using the RimWorld modding framework, which requires familiarity with C# and XML for definition files.
- **Harmony Patching**: The mod uses Harmony patching to modify existing game mechanics and add new functionality. Harmony is a popular library for modding RimWorld.
- **XML Integration**: Definition files are written in XML format to define new terrain types, designator dropdown groups, and other game elements.
- **C# Code**: The mod includes C# code for handling specific game events, such as modifying infestation cell scoring and large building cell finding.

## XML Integration

The mod includes several XML definition files that define new terrain types and modify existing ones. These files are located in the `Defs` directory and include:

- `Terrain_Floors.xml`: Defines armored floor terrain types.
- `Armoredfoundation.xml`: Defines the armored foundation terrain type.
- `Biomes_Islands.xml` and `MoreFurniture.xml`: Modify existing terrain types to include armored properties.

## Harmony Patching

The mod uses Harmony patching to modify game behavior. The following patches are included:

- **InfestationCellFinder_GetScoreAt.cs**: Contains a postfix patch to modify the score calculation for infestation cells, taking into account armored floors.
- **LargeBuildingCellFinder_TryFindCell.cs**: Contains a prefix patch to modify the logic for finding large building cells, ensuring that armored floors are considered.

## Suggestions for Copilot

### General Suggestions

- **Explore Harmony Patching**: Copilot can help with understanding and implementing Harmony patches to modify game mechanics.
- **XML Definition Files**: Copilot can assist in generating and modifying XML definition files for new terrain types and game elements.
- **Debugging and Error Handling**: Copilot can provide assistance in debugging and handling errors, especially when dealing with Harmony patches and XML files.

### Specific Examples

- **Mod Setup**: Provide examples of setting up a new mod project, including creating the necessary directories and files.
- **Harmony Patch Implementation**: Provide examples of implementing Harmony patches, including creating postfix and prefix patches.
- **XML Definition File Structure**: Provide examples of the structure and content of XML definition files, including terrain types and designator dropdown groups.

### Code Snippets

- **Harmony Patch Example**:
  csharp
  [HarmonyPatch(typeof(InfestationCellFinder), "GetScoreAt")]
  public static class InfestationCellFinder_GetScoreAt
  {
      public static void Postfix(IntVec3 c, Map map, ref float __result)
      {
          if (map.terrainGrid.TerrainAt(c) is TerrainDef armoredFloor && armoredFloor.HasModExtension<InfestationBlocker>())
          {
              __result -= 100f; // Lower the score to discourage infestations on armored floors
          }
      }
  }
  

- **XML Definition Example**:
  xml
  <TerrainDef>
      <defName>ArmoredFloor</defName>
      <label>Armored Floor</label>
      <description>A floor with armor plating to prevent infestations.</description>
      <affordances>
          <li>Walkable</li>
          <li>Buildable</li>
      </affordances>
      <extensions>
          <li Class="InfestationBlocker" />
      </extensions>
  </TerrainDef>
  

## Conclusion

Armored Floors (Continued) is a comprehensive mod that adds armored floors and foundations to RimWorld, enhancing base protection against infestations. By following the coding patterns and conventions outlined above, along with utilizing the suggestions for Copilot, you can effectively develop and maintain this mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

