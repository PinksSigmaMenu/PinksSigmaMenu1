using PinkMenu.Helpers;
using StupidTemplate.Classes;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate
{
    internal class Config
    {
        public static ExtGradient backgroundColor = new ExtGradient {isRainbow = false};

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient{colors = GetSolidGradient(SigmaColors.hotPink)}, // Disabled
            new ExtGradient{colors = GetSolidGradient(SigmaColors.deepPink)} // Enabled
        };
        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.green // Enabled
        };

        

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 0.95f, 1.05f); // Depth, Width, Height
        public static Vector3 menuSize2 = new Vector3(0.1f, 1f, 1.10f);
        public static Vector3 menuSize3 = new Vector3(0.1f, 0.75f, 0.60f);// Depth, Width, Height
        public static int buttonsPerPage = 8;
    }
}
