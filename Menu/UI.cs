using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public int fontSize = 25;
    public FontStyle fontStyle = FontStyle.Italic;
    public Color textColor = Color.white;
    public Font customFont;

    void OnGUI()
    {
        GUI.skin.textField.font = customFont;
        GUI.skin.textField.fontStyle = fontStyle;
        GUI.skin.textField.fontSize = fontSize;

        GUI.color = textColor;

        float textFieldWidth = 200;
        float textFieldHeight = 20;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float textFieldX = (screenWidth - textFieldWidth) / 2;
        float textFieldY = (screenHeight - textFieldHeight) / 2;

        string newText = GUI.TextField(new Rect(textFieldX, textFieldY, textFieldWidth, textFieldHeight), "Sigma Rizz");

        Debug.Log("Entered text: " + newText);
    }
}
