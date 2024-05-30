using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using PinkMenu.Helpers;
using UnityEngine.Device;

namespace PinkMenu.Helpers
{
    internal class Display22
    {
        public static void MOTDTXT()
        {

            {
                GameObject motdObject = GameObject.Find("motdtext");
                Text motdText = motdObject.GetComponent<Text>();
                float lerp = Mathf.PingPong(Time.time, 1) / 1;
                Color color = Color.Lerp(SigmaColors.deepPink, SigmaColors.hotPink, lerp);
                motdText.color = color;
                motdText.text = "Hello everyone,\r\n\r\nWelcome to the Pink Menu! 🎉\r\n\r\nThis menu is currently in beta, so please bear with me on what's available. 😊\r\n\r\nJoin our Discord community at:\r\n<color=#FFB6F9><b>https://discord.gg/MNjwNcvUgu</b></color>\r\n\r\nCurrently, the menu includes <color=#FFB6F9><b>78</b></color> mods.";
            }
        }

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

        private static void ApplyMaterialRecursively(Transform parent, Material material)
        {
            foreach (Transform child in parent)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = material;
                }
                ApplyMaterialRecursively(child, material); // Recursively apply to children
            }
        }


        public class GameManager : MonoBehaviour
        {
            void Start()
            {
                PinkMenu.Helpers.Display22.MOTDTXT();
                PinkMenu.Helpers.Display22.ConductIDS();
            }
        }
    }
}
