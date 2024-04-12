using Photon.Pun;
using StupidTemplate.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PinkMenu.Mods
{
    internal class AntiCheat
    {
        public static List<GorillaPlayerLineButton> ReportButtons = new List<GorillaPlayerLineButton>();
        public static int ButtonCount = 10000;
        public static void onReported()
        {
            PhotonNetwork.Disconnect();
            Main.RPCProtection();
        }
        public static void AntiReport()
        {
            if (ReportButtons.Count < ButtonCount)
            {
                GorillaPlayerLineButton[] gameObjects = GameObject.FindObjectsOfType<GorillaPlayerLineButton>();
                foreach (GorillaPlayerLineButton button in gameObjects)
                {
                    if (button.gameObject.name == "ReportButton")
                    {
                        ReportButtons.Add(button);
                    }
                }
                ButtonCount = ReportButtons.Count;
            }
            float maxDistance = 0.35f;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                foreach (GorillaPlayerLineButton button in ReportButtons)
                {
                    if (vrrig != GorillaTagger.Instance.offlineVRRig)
                    {
                        if (Vector3.Distance(vrrig.rightHandTransform.position, button.transform.position) < maxDistance)
                        {
                            onReported();
                        }
                        else if (Vector3.Distance(vrrig.leftHandTransform.position, button.transform.position) < maxDistance)
                        {
                            onReported();
                        }
                    }
                }
            }
        }
    }
}
