using System.Reflection;
using HarmonyLib;
using Verse;

namespace ArmoredFloors;

[StaticConstructorOnStartup]
public static class AFMod
{
    static AFMod()
    {
        new Harmony("the_codewarrior.rimworld.ArmoredFloors.main").PatchAll(Assembly.GetExecutingAssembly());
    }
}