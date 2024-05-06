using UnityEngine;

namespace PinkMenu.Menu
{
    public class UI
    {
        public static int fontSize = 25;
        public static FontStyle fontStyle = FontStyle.Italic;
        public static Color textColor = Color.white;
        public static Font customFont;

        public static void DrawGUI()
        {
            GUI.skin.textField.font = customFont;
            //GUI.skin.textField.fontStyle = fontStyle; // custom font is not dynamic somehow so u cant edit it
            GUI.skin.textField.fontSize = fontSize;

            GUI.color = textColor;

            float textFieldWidth = 200;
            float textFieldHeight = 40;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float textFieldX = (screenWidth - textFieldWidth) / 2;
            float textFieldY = (screenHeight - textFieldHeight) / 2;

            string newText = GUI.TextField(new Rect(textFieldX, textFieldY, textFieldWidth, textFieldHeight), "Sigma Rizz");

            //Debug.Log("Entered text: " + newText);
        }
    }
}
