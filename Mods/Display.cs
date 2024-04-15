using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace PinkMenu.Mods
{
    internal class Display22
    {
        public static void ConductIDS()
        {
            GameObject codeOfConductObject = GameObject.Find("CodeOfConduct");
            GameObject cocTextObject = codeOfConductObject.transform.Find("COC Text").gameObject;
            Text codeOfConductText = cocTextObject.GetComponent<Text>();

            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                codeOfConductText.text = "";

                foreach (Player player in PhotonNetwork.PlayerListOthers)
                {
                    string id = $"<color=#FF69B4><b>{player.NickName}</b></color> {player.UserId}";

                    codeOfConductText.text += id + "\n";

                    GameObject.Find("motdscreen").GetComponent<Renderer>().material.color = Color.red;
                    GameObject.Find("screen").GetComponent<Renderer>().material.color = Color.magenta;
                    
                }
            }
        }
        public static void MOTDTXT()
        {
            GameObject motdObject = GameObject.Find("motdtext");

            if (motdObject != null)
            {
                Text motdText = motdObject.GetComponent<Text>();

                if (motdText != null)
                {
                    Text motd = motdObject.GetComponent<Text>();
                    float lerp = Mathf.PingPong(Time.time, 1) / 1;
                    Color color = Color.Lerp(Color.magenta, Color.black, lerp);
                    motdText.color = color;

                    motdText.text = "HELLO FELLOW SIGMA WELCOME TO PINKS SIGMA MENU I HOPE YOU ENJOY AND MAKE SURE TO RIZZ UP ALL OF THEM LEVEL 10s";


                }
            }
        }

    }
}
