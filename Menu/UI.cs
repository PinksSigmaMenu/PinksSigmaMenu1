using PinkMenu.Helpers;
using UnityEngine;
using ExitGames.Client.Photon.StructWrapping;
using GorillaLocomotion;
using Oculus.Interaction;
using Photon.Pun;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using iiMenu.Mods.Spammers;
using Oculus.Interaction.Input;
using static Mono.Math.BigInteger;
using static PinkMenu.Managers.RigManager;
using static PinkMenu.Menu.Main;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using PinkMenu.Managers;

namespace PinkMenu.Menu
{
    public class UI
    {
        public static int fontSize = 25;
        public static FontStyle fontStyle = FontStyle.Italic;
        public static Color textColor = Color.white;
        public static Font customFont;

        private static Rect draggableWindowRect = new Rect(20, 20, 300, 200); // Increased size
        private static Rect modInfoWindowRect = new Rect(20, 20, 300, 200); // Mod info window
        private static float fpsUpdateInterval = 0.5f;
        private static float fpsAccum = 0;
        private static int fpsFrames = 0;
        private static float fpsTimeLeft;

        private static bool button1State = false;
        private static bool button2State = false;

        private static bool showModInfo = false;
        private static bool showModInfoWindow = false; 

        public static void DrawGUI()
        {
            GUI.backgroundColor = SigmaColors.hotPink;

        
            draggableWindowRect = GUI.Window(0, draggableWindowRect, DrawDraggableWindow, GUIContent.none);

            GUI.skin.textField.font = customFont;
            //GUI.skin.textField.fontStyle = fontStyle; // custom font is not dynamic somehow so u cant edit it
            GUI.skin.textField.fontSize = fontSize;

            GUI.color = textColor;

            
        }

        private static void DrawDraggableWindow(int windowID)
        {
            float fps = CalculateFPS();
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(draggableWindowRect.width - 130, 16, 100, 15), "FPS: " + Mathf.RoundToInt(fps));

            button1State = GUI.Toggle(new Rect(200, 60, 80, 10), button1State, "Capsule ESP");
            if (button1State)
            {
                if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
                {
                    foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                    {
                        if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                        {
                            GameObject PinksPen = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                            PinksPen.transform.position = FullPlayers.transform.position;
                            PinksPen.transform.rotation = FullPlayers.transform.rotation;
                            PinksPen.transform.localScale = new Vector3(0.40f, 0.45f, 0.40f);
                            Shader ESPShader = Shader.Find("GUI/Text Shader");
                            Material sphereMaterial = new Material(ESPShader);
                            PinksPen.GetComponent<Renderer>().material = sphereMaterial;
                            float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                            Color transparentMagenta = new Color(SigmaColors.hotPink.r, SigmaColors.hotPink.g, SigmaColors.hotPink.b, 0.5f);
                            Color transparentBlack = new Color(SigmaColors.deepPink.r, SigmaColors.deepPink.g, SigmaColors.deepPink.b, 0.5f);
                            Color lerpedColor = Color.Lerp(transparentMagenta, transparentBlack, pingPongValue);
                            sphereMaterial.color = lerpedColor;
                            UnityEngine.Object.Destroy(PinksPen, Time.deltaTime);
                            Collider collider = PinksPen.GetComponent<Collider>();
                            if (collider != null)
                            {
                                UnityEngine.Object.Destroy(collider);
                            }
                        }
                    }
                }
            }
            button2State = GUI.Toggle(new Rect(200, 100, 80, 10), button2State, "Snake ESP");
            if (button2State)
            {
                if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
                {
                    foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                    {
                        if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                        {

                            GameObject PinksOBJ = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            PinksOBJ.transform.localScale = new Vector3(0.095f, 0.095f, 0.095f);
                            PinksOBJ.transform.position = FullPlayers.transform.position;
                            PinksOBJ.transform.rotation = FullPlayers.transform.rotation;

                            Collider collider = PinksOBJ.GetComponent<Collider>();
                            if (collider != null)
                            {
                                UnityEngine.Object.Destroy(collider);
                            }
                            Shader ESPShader = Shader.Find("GUI/Text Shader");
                            Material sphereMaterial = new Material(ESPShader);
                            PinksOBJ.GetComponent<Renderer>().material = sphereMaterial;
                            float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                            sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
                            UnityEngine.Object.Destroy(PinksOBJ, 0.50f);
                        }
                    }
                }
            }
            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.I)
            {
                showModInfoWindow = !showModInfoWindow;
            }

            if (GUI.Button(new Rect(10, 70, 100, 30), "Mod Info"))
            {
                showModInfoWindow = !showModInfoWindow;
            }

            GUI.DragWindow();
        }
        private static float CalculateFPS()
        {
            fpsTimeLeft -= Time.deltaTime;
            fpsAccum += Time.timeScale / Time.deltaTime;
            fpsFrames++;

            if (fpsTimeLeft <= 0.0f)
            {
                float fps = fpsAccum / fpsFrames;
                fpsTimeLeft = fpsUpdateInterval;
                fpsAccum = 0.0f;
                fpsFrames = 0;
                return fps;
            }
            return 0;
        }

        private static void ChangeTextureColor(Texture2D texture, Color newColor)
        {
            Color[] pixels = texture.GetPixels();
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = newColor;
            }
            texture.SetPixels(pixels);
            texture.Apply();
        }
    }
}
