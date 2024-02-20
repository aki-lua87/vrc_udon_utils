﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace aki_lua87.UdonScripts.utils
{
    public class CrossUdonBehaviourCommunication : UdonSharpBehaviour
    {
        [SerializeField] private UdonSharpBehaviour targetUdonBehaviour;
        [SerializeField] private string callMethodName = "FunctionA";

        [SerializeField] private bool isSync = false;

        public override void Interact()
        {
            // オーナー変更
            if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject)) Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
            if (isSync)
            {
                SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "SendMethodCall");
            }
            else
            {
                SendMethodCall();
            }

        }

        public void SendMethodCall()
        {
            targetUdonBehaviour.SendCustomEvent(callMethodName);
        }
    }
}