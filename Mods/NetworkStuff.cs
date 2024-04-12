using GorillaNetworking;
using Oculus.Platform;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;

namespace PinkMenu.Mods
{
    internal class NetworkStuff
    {
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void Reconnect()
        {
            PhotonNetwork.Reconnect();
        }
        public static void JoinRandom()
        {
            PhotonNetwork.JoinRandomRoom();
        }
        public static void CreatePublic()
        {
            PhotonNetwork.CreateRoom("Run Im in your skin", null, null, null);
        }
        public static void Quitgame()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig POS in GorillaParent.instance.vrrigs)
                {
                    if (POS != GorillaTagger.Instance.offlineVRRig)
                    {

                        GameObject SuperQuit = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        SuperQuit.transform.position = POS.transform.position;
                        SuperQuit.transform.rotation = POS.transform.rotation;
                        POS.transform.localScale = new Vector3(5, 5, 5);
                        Shader SAD = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial = new Material(SAD);
                        SuperQuit.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);
                    }
                }
            }
        }
    }
}




