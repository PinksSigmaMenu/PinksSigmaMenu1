using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using PinkMenu.Mods;  

namespace PinkMenu.Menu
{
    public class UI : MonoBehaviour
    {
        private void OnGUI()
        {
            DrawGUI();
        }

        public static void DrawGUI()
        {
            float padding = 50f;
            float textHeight = 50f;
            float textWidth = 150f;
            float offsetY = 15f;

            GUIStyle pinkMenuStyle = new GUIStyle(GUI.skin.label);
            pinkMenuStyle.fontStyle = FontStyle.Bold;
            pinkMenuStyle.normal.textColor = Color.magenta;

            Rect pinkMenuRect = new Rect(padding, Screen.height - textHeight - padding - offsetY, textWidth, textHeight);
            GUI.Label(pinkMenuRect, "The Pink Menu", pinkMenuStyle);

            float secondLabelOffsetY = padding + textHeight + offsetY + 20f;
            Rect timeRect = new Rect(padding, Screen.height - 2 * textHeight - padding - offsetY - 20f, textWidth, textHeight);
            GUI.Label(timeRect, "Est. Time: " + FormatTime(Time.timeSinceLevelLoad), pinkMenuStyle);

            bool isConnected = PhotonNetwork.IsConnected;
            string connectionStatus = isConnected ? "Connected to Room" : "Not Connected";
            Color connectionColor = isConnected ? Color.green : Color.red;
            GUIStyle connectionStyle = new GUIStyle(GUI.skin.label);
            connectionStyle.fontStyle = FontStyle.Bold;
            connectionStyle.normal.textColor = connectionColor;

            Rect connectionRect = new Rect(Screen.width - textWidth - padding, padding, textWidth, textHeight);
            GUI.Label(connectionRect, connectionStatus, connectionStyle);

            string boostStatus = $"Jump Speed: {CustomBoost.CurrentMaxJumpSpeed:F2}\nJump Multiplier: {CustomBoost.CurrentJumpMultiplier:F2}";
            GUIStyle boostStyle = new GUIStyle(GUI.skin.label);
            boostStyle.fontStyle = FontStyle.Bold;
            boostStyle.normal.textColor = Color.white;

            Rect boostRect = new Rect(Screen.width - textWidth - padding, Screen.height - 3 * textHeight - padding - offsetY - 40f, textWidth, 2 * textHeight);
            GUI.Label(boostRect, boostStatus, boostStyle);

            if (PhotonNetwork.InRoom)
            {
                string roomCode = "Room Code: " + PhotonNetwork.CurrentRoom.Name;
                GUIStyle roomCodeStyle = new GUIStyle(GUI.skin.label);
                roomCodeStyle.fontStyle = FontStyle.Bold;
                roomCodeStyle.normal.textColor = Color.white;

                Rect roomCodeRect = new Rect(Screen.width - textWidth - padding, padding + textHeight + 10f, textWidth, textHeight);
                GUI.Label(roomCodeRect, roomCode, roomCodeStyle);

                bool isModdedLobby = CheckIfModdedLobby();
                string moddedLobbyStatus = isModdedLobby ? "Modded Lobby" : "Standard Lobby";
                Color moddedLobbyColor = isModdedLobby ? Color.yellow : Color.cyan;
                GUIStyle moddedLobbyStyle = new GUIStyle(GUI.skin.label);
                moddedLobbyStyle.fontStyle = FontStyle.Bold;
                moddedLobbyStyle.normal.textColor = moddedLobbyColor;

                Rect moddedLobbyRect = new Rect(Screen.width - textWidth - padding, padding + 2 * textHeight + 20f, textWidth, textHeight);
                GUI.Label(moddedLobbyRect, moddedLobbyStatus, moddedLobbyStyle);
            }
        }

        private static bool CheckIfModdedLobby()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("gameMode"))
            {
                string gameMode = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString();
                if (gameMode.Contains("MODDED"))
                {
                    return true;
                }
            }

            return false;
        }

        private static string FormatTime(float seconds)
        {
            int minutes = Mathf.FloorToInt(seconds / 60f);
            int remainingSeconds = Mathf.FloorToInt(seconds % 60f);
            return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
        }
    }
}
