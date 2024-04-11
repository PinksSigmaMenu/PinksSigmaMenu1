using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;

namespace StupidTemplate.Mods.Stuff
{
    internal class ConductIDSS
    {
        private static TMP_Text codeOfConductText;
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
    }
}











