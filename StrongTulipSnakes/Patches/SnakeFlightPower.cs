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
                __instance.flightPower = 40f;
                __instance.clingingToPlayer.enemiesOnPerson += 10;
            }

            if (!__instance.activatedFlight &&  boostedFlightPower)
            {
                boostedFlightPower = false;
                __instance.clingingToPlayer.enemiesOnPerson = 0;
            }

            if (__instance.clingingToPlayer.thisPlayerBody.position.y >= 65f)
            {
                __instance.flightPower = 0f;
                __instance.clingPosition = 0;
                __instance.StopClingingServerRpc((int)GameNetworkManager.Instance.localPlayerController.playerClientId);
            }
        }
    }
}
