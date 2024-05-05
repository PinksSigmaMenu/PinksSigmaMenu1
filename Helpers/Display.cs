using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using PinkMenu.Helpers;

namespace StupidTemplate.Helpers
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
                    GameObject.Find("screen").GetComponent<Renderer>().material.color = SigmaColors.hotPink;
                }
            }
        }

        public static void ConductNameChanger()
        {
            GameObject conductObject = GameObject.Find("CodeOfConduct");
            Transform textTransform = conductObject.transform.Find("Text.text");
            Text textComponent = textTransform.GetComponent<Text>();
            textComponent.text = "Pinks Conduct IDS";
            textComponent.color = SigmaColors.hotPink;
        }

        public static void UpdateConductName()
        {
            GameObject conductObject = GameObject.Find("CodeOfConduct");
            Text motdText = conductObject.GetComponent<Text>();
            float lerp = Mathf.PingPong(Time.time, 1) / 1;
            Color color = Color.Lerp(SigmaColors.deepPink, SigmaColors.hotPink, lerp);
            motdText.color = color;
            motdText.text = "Pinks Conduct IDS";
        }

        public static void MOTDTXT()
        {
            GameObject motdObject = GameObject.Find("motdtext");
            Text motdText = motdObject.GetComponent<Text>();
            float lerp = Mathf.PingPong(Time.time, 1) / 1;
            Color color = Color.Lerp(SigmaColors.deepPink, SigmaColors.hotPink, lerp);
            motdText.color = color;
            motdText.text = "HELLO FELLOW SIGMA WELCOME TO PINKS SIGMA MENU I HOPE YOU ENJOY AND MAKE SURE TO RIZZ UP ALL OF THEM LEVEL 10s";
        }

        public static void UpdateColor()
        {
            GameObject screenObject = GameObject.Find("scoreboard");
            Renderer renderer = screenObject.GetComponent<Renderer>();
            renderer.material.color = SigmaColors.lightPink;
        }
    }
}
public class GameManager : MonoBehaviour
{
    void Start()
    {
        StupidTemplate.Helpers.Display22.ConductIDS();
        StupidTemplate.Helpers.Display22.ConductNameChanger();
        StupidTemplate.Helpers.Display22.UpdateConductName();
        StupidTemplate.Helpers.Display22.MOTDTXT();
        StupidTemplate.Helpers.Display22.UpdateColor();
    }
}
