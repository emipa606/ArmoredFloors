# GitHub Copilot Instructions for Armored Floors (Continued) Mod

## Mod Overview and Purpose

**Armored Floors (Continued)** is a mod for RimWorld offering gamers a realistic and challenging solution to combat insect infestations in their bases. This mod allows players to install armored floors composed of steel-plasteel composites, effectively preventing infestation events beneath overhead mountain tiles. By using this mod, players can avoid catastrophic infestations without removing the strategic importance and risk associated with overhead mountains. 

## Key Features and Systems

- **Infestation Prevention**: Armored floors are specifically designed to prevent infestation events on tiles with overhead mountains. The hives can still spawn if events occur nearby, maintaining the game's challenge.
- **Cost and Construction**: Each armored tile requires four steel and two plasteel, making it a strategic consideration for mid to late-game play due to the resource costs.
- **Mod Extension**: Other modders can extend the infestation-blocking properties to additional floor types by patching with the `InfestationBlocker` tag within floor definitions.

## Coding Patterns and Conventions

- **Namespace and Class Structure**:
  - `AFMod.cs`: The central hub for mod behavior. Contains static classes and methods that define setup and interactions.
  - `InfestationCellFinder_GetScoreAt.cs`: Contains internal classes that manage the scoring of tiles for infestation probabilities. Follow the internal naming conventions for classes and methods to ensure consistency.
- **Coding Conventions**: Follow C# conventions consistently, such as using PascalCase for class names and method names, and camelCase for variables and private members. Comment your code generously, especially around Harmony patches and interactions with the core game systems.

## XML Integration

- **Def-System Converts**: XML is used extensively to define the properties of floors and integrations into the game world. Modders integrating new floors should ensure their floor definitions include the `InfestationBlocker` tag to utilize the core functionality of Armored Floors.
- **Sample XML Snippets**:
  xml
  <ThingDef>
    <defName>ArmoredFloor</defName>
    <InfestationBlocker>true</InfestationBlocker>
  </ThingDef>
  

## Harmony Patching

- **Use of Harmony**: Harmony is used fundamentally in this mod to intercept and alter game behaviors related to infestation spawning. Create patches by using the `HarmonyPatch` attribute.
- **Example Usage**:
  csharp
  [HarmonyPatch(typeof(InfestationCellFinder), "GetScoreAt")]
  class InfestationCellFinder_GetScoreAt
  {
      static void Postfix(ref float __result, IntVec3 cell)
      {
          // Your patch logic that modifies the infestation score based on armored floor presence
      }
  }
  

## Suggestions for Copilot

- **Code Completion and Refactoring**: Use GitHub Copilot to draft initial code, exploiting its AI capabilities to propose efficient solutions for method implementations and refactoring existing code for optimization.
- **Documentation Assistance**: Encourage Copilot to generate XML templates and C# code documentation to maintain codebase readability and ease for new developers.
- **Testing and Debugging**: Leverage Copilot to suggest unit tests or debug approaches for commonly occurring issues associated with Harmony patches and game object definitions.

By maintaining this structure and utilizing these guidelines, mod developers can effectively expand and manage the Armored Floors (Continued) mod, ensuring a balanced and engaging experience for players.
