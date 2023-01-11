using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using HarmonyLib;

namespace LurkingInTheDark
{
    internal static class LitDQuests
    {
        private static IModHelper Helper { get; set; }
        public static void ApplyPatch(Harmony harmony, IModHelper helper)
        {
            Helper = helper;

            Helper.Events.GameLoop.DayEnding += OnDayEnd;

            harmony.Patch(
                original: AccessTools.Method(typeof(SpecialOrder), nameof(SpecialOrder.IsTimedQuest)),
                postfix: new HarmonyMethod(typeof(LitDQuests), nameof(SpecialOrders_IsTimed_postfix))
            );
        }
        private static void SpecialOrders_IsTimed_postfix(SpecialOrder __instance, ref bool __result)
        {
            if (__instance.questKey.Value == "LitD.SpecialOrders.SeedQuest")
            {
                __result = false;
            }
        }
        public static void OnDayEnd(object? sender, DayEndingEventArgs e)
        {
            if (!Context.IsMainPlayer)
                return;

            foreach (SpecialOrder o in Game1.player.team.specialOrders)
            {
                if (o.questKey.Value.StartsWith("LitD.SpecialOrders.SeedQuest"))
                {
                    o.dueDate.Value = Game1.Date.TotalDays + 100;
                }

            }
        }
    }
}
