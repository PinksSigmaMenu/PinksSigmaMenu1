using PinkMenu.Helpers;
using PinkMenu.Classes;
using UnityEngine;
using static PinkMenu.Menu.Main;

namespace PinkMenu
{
    internal class Config
    {
        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.2f, 0.93f, 1.05f); // Depth, Width, Height
        public static Vector3 menuSize2 = new Vector3(0.1f, 0.98f, 1.10f);// Depth, Width, Height
        public static Vector3 menuSize3 = new Vector3(0.1f, 0.75f, 0.60f);// Depth, Width, Height
        public static int buttonsPerPage = 8;
    }
}
