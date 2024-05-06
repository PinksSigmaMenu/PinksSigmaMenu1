using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using PinkMenu.Helpers;
using UnityEngine.Device;

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

                }
            }
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
            motdText.text = "HELLO EVERYONE WELCOME TO THE PINK MENU THIS MENU IS CURRENTLY IN IN BETA SO BARE WITH ME ON WHATS IN THE MENU LOL YOU CAN JOIN MY DISCORD AT <color=#FFB6F9><b>https://discord.gg/MNjwNcvUgu</b></color> IF YOU'D LIKE THIS MENU CURRENTLY HAS <color=#FFB6F9><b>78</b></color> MODS IN THE MENU";
        }

        public static void UpdateColors()
        {
            Text codeOfConductText = GameObject.Find("CodeOfConduct").GetComponent<Text>();
            codeOfConductText.text = "<color=#FF69B4><b>Pink</b></color> <color=#FF6BF3><b>Conduct</b></color> <color=#FF2CEE><b>IDS</b></color>";

            Text motdText = GameObject.Find("motd").GetComponent<Text>();
            motdText.text = "<color=#FF69B4><b>Pink</b></color> <color=#FF6BF3><b>Menu</b></color> <color=#FF2CEE><b>MOTD</b></color>";

           
            UpdateObjectColor("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest");
            UpdateObjectColor("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave");
            UpdateObjectColor("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle");
            UpdateObjectColor("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics");
            UpdateObjectColor("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon");
        }

        static void UpdateObjectColor(string objectName)
        {
            GameObject obj = GameObject.Find(objectName);
            if (obj)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer)
                {
                    renderer.material.color = SigmaColors.deepPink;
                }
            }
        }
    }

    public class GameManager : MonoBehaviour
    {
        void Start()
        {
            StupidTemplate.Helpers.Display22.ConductIDS();
            StupidTemplate.Helpers.Display22.UpdateConductName();
            StupidTemplate.Helpers.Display22.MOTDTXT();
            StupidTemplate.Helpers.Display22.UpdateColors();
        }
    }
}
