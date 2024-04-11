using Photon.Pun;
using StupidTemplate.Menu;
using StupidTemplate.Patches;
using UnityEngine;
using UnityEngine.UI;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods.Stuff
{
    //ALL CREDITS GOTO F3 FOR MAKING THIS https://discord.gg/d5PP2utv JOIN HIS DISCORD HERE
    internal class istolefromf3
    {
        public static void Antipoop()
        {
            try
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GorillaUI");
                Transform transform = gameObject.transform;
                for (int i = 0; i < transform.childCount; i++)
                {
                    Transform transform2 = transform.GetChild(i);
                    bool flag = transform2.gameObject.name.Contains("Anchor") && transform2.gameObject.activeSelf;
                    if (flag)
                    {
                        string name = transform2.gameObject.name;
                        transform2 = transform2.Find("GorillaScoreBoard/LineParent");
                        for (int j = 0; j < transform2.childCount; j++)
                        {
                            Transform child = transform2.GetChild(j);
                            bool flag2 = child.name.Contains("GorillaPlayerScoreboardLine");
                            if (flag2)
                            {
                                Text component = child.Find("Player Name").GetComponent<Text>();
                                Transform transform3 = child.Find("ReportButton");
                                bool flag3 = !transform3.gameObject.activeSelf;
                                if (flag3)
                                {
                                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                                    {
                                        bool flag4 = vrrig != GorillaTagger.Instance.offlineVRRig;
                                        if (flag4)
                                        {
                                            float num = Vector3.Distance(vrrig.rightHandTransform.position, transform3.position);
                                            float num2 = Vector3.Distance(vrrig.leftHandTransform.position, transform3.position);
                                            float num3 = 0.35f;
                                            bool flag5 = num < num3 || num2 < num3;
                                            if (flag5)
                                            {
                                                PhotonNetwork.Disconnect();
                                                Main.RPCProtection1();
                                                //NotifiLib.SendNotification("<color=grey>[</color><color=purple>ANTI-REPORT</color><color=grey>]</color> <color=white>Someone attempted to report you, you have been disconnected.</color>");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}







