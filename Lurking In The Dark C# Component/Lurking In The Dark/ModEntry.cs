using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using HarmonyLib;

namespace LurkingInTheDark
{
    /// <summary>The mod entry point.</summary>
    internal sealed class ModEntry : Mod
    {
        internal static IMonitor ModMonitor { get; set; }
        /*********
        ** Public methods
        *********/

        public override void Entry(IModHelper helper)
        {
            var harmony = new Harmony(ModManifest.UniqueID);
            LitDQuests.ApplyPatch(harmony, Helper);
        }
    }
}