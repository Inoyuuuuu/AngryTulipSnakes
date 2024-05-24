using AngryTulipSnakes.Configs;
using HarmonyLib;

namespace AngryTulipSnakes.Patches
{
    [HarmonyPatch(typeof(FlowerSnakeEnemy))]
    public class SnakeFlightPower
    {
        private static bool boostedFlightPower = false;

        [HarmonyPatch("MainSnakeActAsConductor")]
        [HarmonyPrefix]
        private static void PatchSnakeStrength(FlowerSnakeEnemy __instance)
        {

            if (__instance.activatedFlight && !boostedFlightPower)
            {
                boostedFlightPower = true;
                __instance.flightPower = 8 * ATSConfigs.Instance.YOINK_POWER_MULTIPLPLIER;
                __instance.clingingToPlayer.enemiesOnPerson +=  2 * ATSConfigs.Instance.YOINK_POWER_MULTIPLPLIER;
            }

            if (!__instance.activatedFlight &&  boostedFlightPower)
            {
                boostedFlightPower = false;
                __instance.clingingToPlayer.enemiesOnPerson = 0;
            }

            if (__instance.clingingToPlayer.thisPlayerBody.position.y >= ATSConfigs.Instance.DROP_HEIGHT)
            {
                __instance.flightPower = 0f;
                __instance.clingPosition = 0;
                __instance.StopClingingServerRpc((int)GameNetworkManager.Instance.localPlayerController.playerClientId);
            }
        }
    }
}
