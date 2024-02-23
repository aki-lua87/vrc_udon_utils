
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace aki_lua87.UdonScripts.utils
{
    // インタラクトすると他の人全員を指定した場所にテレポートさせる
    public class TeleportAllPlayer : UdonSharpBehaviour
    {
        [SerializeField] private Transform targetPosition;

        public override void Interact()
        {
            TeleportAllPlayerToTarget();
        }

        public void TeleportAllPlayerToTarget()
        {
            VRCPlayerApi[] players = new VRCPlayerApi[80];
            VRCPlayerApi.GetPlayers(players);
            foreach (var player in players)
            {
                if (player == null) continue;
                if (player == Networking.LocalPlayer) continue;
                player.TeleportTo(targetPosition.position, targetPosition.rotation);
            }
        }
    }
}
