using System;
using System.Reflection;
using BepInEx;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;
using System.Diagnostics;








namespace VIVIDtemp
{
    [BepInPlugin("VIVID", "Gui", "1.0.0")]
    public class lilrift : BaseUnityPlugin
    {
        public static string Code;

        public static bool spazSodaType;

        bool Toggle1 = false;


        bool ToggleButton1 = false;

        bool ToggleButton2 = false;

        bool ToggleButton3 = false;

        bool ToggleButton4 = false;

        bool ToggleButton5 = false;

        bool ToggleButton6 = false;

        bool ToggleButton7 = false;

        bool ToggleButton8 = false;

        bool ToggleButton9 = false;

        bool ToggleButton10 = false;

        bool ToggleButton11 = false;

        bool ToggleButton12 = false;

        bool ToggleButton13 = false;

        bool ToggleButton14 = false;

        bool ToggleButton15 = false;

        bool ToggleButton16 = false;

        bool ToggleButton17 = false;

        bool ToggleButton18 = false;

        bool ToggleButton19 = false;

        bool ToggleButton20 = false;

        bool ToggleButtonm21 = false;

        bool ToggleButton22 = false;

        bool ToggleButton23 = false;

        bool ToggleButton24 = false;

        bool ToggleButton25 = false;

        public GameObject Box { get; private set; }

        public static float Delay = 0.2f;

        float delayTimer = 0f;
        bool delayCompleted = false;

        private Rect windowRect = new Rect(80, 20, 650, 400);



        public float rotationSpeed = 2.5f;
        private float rotationX = 0f;

        public int concurrentPings = 55;

        void OnGUI()
        {


            GUI.backgroundColor = new Color(0, 0, 0, 0f);

            // Begin the GUI window
            windowRect = GUI.Window(10000, windowRect, MainGUI, "");

        }

        void MainGUI(int windowID)
        {
            {
                {


                    Texture2D blackTexture = new Texture2D(1, 1);
                    blackTexture.SetPixel(0, 0, new Color32(0, 0, 0, 255));
                    blackTexture.Apply();


                    Texture2D greyTexture = new Texture2D(1, 1);
                    greyTexture.SetPixel(0, 0, Color.magenta);
                    greyTexture.Apply();

                    Texture2D magentaTexture = new Texture2D(1, 1);
                    magentaTexture.SetPixel(0, 0, Color.black);
                    magentaTexture.Apply();

                    Texture2D Custome1Texture = new Texture2D(1, 1);
                    Custome1Texture.SetPixel(0, 0, Color.magenta);
                    Custome1Texture.Apply();

                    Texture2D Custome2Texture = new Texture2D(1, 1);
                    Custome2Texture.SetPixel(0, 0, new Color32(25, 25, 25, 255));
                    Custome2Texture.Apply();

                    Texture2D Custome3Texture = new Texture2D(1, 1);
                    Custome3Texture.SetPixel(0, 0, Color.magenta);
                    Custome3Texture.Apply();

                    Texture2D Custome4Texture = new Texture2D(1, 1);
                    Custome4Texture.SetPixel(0, 0, new Color32(153, 153, 255, 255));
                    Custome4Texture.Apply();

                    Texture2D Custome5Texture = new Texture2D(1, 1);
                    Custome5Texture.SetPixel(0, 0, new Color32(255, 51, 153, 254));
                    Custome5Texture.Apply();



                    //background
                    GUI.Box(new Rect(80, 20, 650, 400), "", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome3Texture }, fontSize = 15 });



                    //left
                    GUI.Box(new Rect(90, 30, 100, 50), "", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 15 });

                    GUI.Box(new Rect(90, 90, 100, 300), "", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 15 });

                    //Right
                    GUI.Box(new Rect(595, 30, 50, 50), "", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 1 });

                    GUI.Box(new Rect(595, 90, 50, 300), "", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 1 });



                    //Top

                    GUI.Box(new Rect(200, 30, 390, 50), "", new GUIStyle { normal = new GUIStyleState { textColor = Color.black, background = Custome1Texture }, fontSize = 15 });

                    //text
                    GUI.Box(new Rect(280, 45, 100, 30), " Sigma Gui made by LilRift: Pink GUI", new GUIStyle { normal = new GUIStyleState { textColor = Color.black, background = Custome1Texture }, fontSize = 15 });

                    GUI.Box(new Rect(605, 45, 10, 10), "Name", new GUIStyle { normal = new GUIStyleState { textColor = new Color32(255, 51, 153, 255), background = Custome1Texture }, fontSize = 15 });

                    if (GUI.Button(new Rect(115, 45, 50, 20), "Discord", new GUIStyle { normal = new GUIStyleState { textColor = Color.black, background = Custome1Texture }, fontSize = 15 }))
                    {

                    }

                    //Boxes
                    GUI.Box(new Rect(200, 90, 190, 300), " Mods", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 15 });

                    GUI.Box(new Rect(400, 90, 190, 170), " Visual", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 15 });

                    GUI.Box(new Rect(400, 270, 190, 120), " Movement", new GUIStyle { normal = new GUIStyleState { textColor = Color.magenta, background = Custome1Texture }, fontSize = 15 });

                    //MODS
                    ToggleButton1 = GUI.Toggle(new Rect(205, 120, 15, 15), ToggleButton1, "      Autism<color=green> [W!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton1 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton1 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton1)
                    {
                        GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3((float)UnityEngine.Random.Range(10, 360), (float)UnityEngine.Random.Range(10, 180), (float)UnityEngine.Random.Range(0, 180));

                    }

                    ToggleButton2 = GUI.Toggle(new Rect(205, 150, 15, 15), ToggleButton2, "      mods<color=green> [W!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton2 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton2 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton2)
                    {
                    }


                    ToggleButton3 = GUI.Toggle(new Rect(205, 180, 15, 15), ToggleButton3, "       Crash<color=green> [W?]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton3 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton3 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton3)
                    {

                    }

                    ToggleButton4 = GUI.Toggle(new Rect(205, 210, 15, 15), ToggleButton4, "      mods<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton4 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton4 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton4)
                    {

                    }

                    ToggleButton5 = GUI.Toggle(new Rect(205, 240, 15, 15), ToggleButton5, "      mods<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton5 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton5 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton5)
                    {

                    }

                    ToggleButton6 = GUI.Toggle(new Rect(205, 270, 15, 15), ToggleButton6, "      mods<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton6 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton6 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton6)
                    {

                    }

                    ToggleButton7 = GUI.Toggle(new Rect(205, 300, 15, 15), ToggleButton7, "      mods<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton7 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton7 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton7)
                    {

                    }

                    ToggleButton8 = GUI.Toggle(new Rect(205, 330, 15, 15), ToggleButton8, "      mods<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton8 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton8 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton8)
                    {

                    }

                    ToggleButton9 = GUI.Toggle(new Rect(205, 360, 15, 15), ToggleButton9, "      mods<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton9 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton9 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton9)
                    {

                    }

                    //Visual
                    ToggleButton10 = GUI.Toggle(new Rect(405, 120, 15, 15), ToggleButton10, "      Visual<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton10 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton10 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton10)
                    {

                    }

                    ToggleButton11 = GUI.Toggle(new Rect(405, 150, 15, 15), ToggleButton11, "      Visual<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton11 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton11 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton11)
                    {

                    }

                    ToggleButton12 = GUI.Toggle(new Rect(405, 180, 15, 15), ToggleButton12, "      Visual<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton12 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton12 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton12)
                    {

                    }

                    ToggleButton13 = GUI.Toggle(new Rect(405, 210, 15, 15), ToggleButton13, "      Visual<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton13 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton13 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton13)
                    {

                    }

                    ToggleButton14 = GUI.Toggle(new Rect(405, 210, 15, 15), ToggleButton14, "      Visual<color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton14 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton14 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton14)
                    {

                    }

                    //Movement
                    ToggleButton15 = GUI.Toggle(new Rect(405, 300, 15, 15), ToggleButton15, "      WASD<color=green> [W!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton15 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton15 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton15)
                    {
                        bool key = UnityInput.Current.GetKey(KeyCode.W);
                        if (key)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 10f;
                        }
                        bool key2 = UnityInput.Current.GetKey(KeyCode.S);
                        if (key2)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * -10f;
                        }
                        bool key3 = UnityInput.Current.GetKey(KeyCode.D);
                        if (key3)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.right * Time.deltaTime * 10f;
                        }
                        bool key4 = UnityInput.Current.GetKey(KeyCode.A);
                        if (key4)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.right * Time.deltaTime * -10f;
                        }
                        bool key5 = UnityInput.Current.GetKey(KeyCode.Q);
                        if (key5)
                        {
                            GorillaLocomotion.Player.Instance.transform.Rotate(0f, -2f, 0f);
                        }
                        bool key6 = UnityInput.Current.GetKey(KeyCode.E);
                        if (key6)
                        {
                            GorillaLocomotion.Player.Instance.transform.Rotate(0f, 2f, 0f);
                        }
                        bool key7 = UnityInput.Current.GetKey(KeyCode.LeftControl);
                        if (key7)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.up * Time.deltaTime * -10f;
                        }
                        bool key8 = UnityInput.Current.GetKey(KeyCode.Space);
                        if (key8)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.up * Time.deltaTime * 10f;
                        }
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }


                    ToggleButton16 = GUI.Toggle(new Rect(405, 330, 15, 15), ToggleButton16, "      Fast WASD <color=green> [D!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton16 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton16 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton16)
                    {
                        bool key = UnityInput.Current.GetKey(KeyCode.W);
                        if (key)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 18f;
                        }
                        bool key2 = UnityInput.Current.GetKey(KeyCode.S);
                        if (key2)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * -18f;
                        }
                        bool key3 = UnityInput.Current.GetKey(KeyCode.D);
                        if (key3)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.right * Time.deltaTime * 18f;
                        }
                        bool key4 = UnityInput.Current.GetKey(KeyCode.A);
                        if (key4)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.right * Time.deltaTime * -18f;
                        }
                        bool key5 = UnityInput.Current.GetKey(KeyCode.Q);
                        if (key5)
                        {
                            GorillaLocomotion.Player.Instance.transform.Rotate(0f, -3f, 0f);
                        }
                        bool key6 = UnityInput.Current.GetKey(KeyCode.E);
                        if (key6)
                        {
                            GorillaLocomotion.Player.Instance.transform.Rotate(0f, 3f, 0f);
                        }
                        bool key7 = UnityInput.Current.GetKey(KeyCode.LeftControl);
                        if (key7)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.up * Time.deltaTime * -18f;
                        }
                        bool key8 = UnityInput.Current.GetKey(KeyCode.Space);
                        if (key8)
                        {
                            GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.up * Time.deltaTime * 18f;
                        }
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }


                    ToggleButton17 = GUI.Toggle(new Rect(405, 360, 15, 15), ToggleButton17, "      Movement <color=green> [NA!]</color>", new GUIStyle { normal = new GUIStyleState { textColor = ToggleButton17 ? new Color32(255, 51, 153, 254) : new Color32(25, 25, 25, 255), background = ToggleButton17 ? Custome5Texture : Custome2Texture }, fontSize = 15 });

                    if (ToggleButton17)
                    {

                    }





                    //Other
                    Code = GUI.TextArea(new Rect(100, 100, 80, 25), Code, new GUIStyle { normal = new GUIStyleState { textColor = new Color32(16, 16, 16, 255), background = Custome2Texture }, fontSize = 15 });
                    if (GUI.Button(new Rect(100, 130, 80, 25), "      Join", new GUIStyle { normal = new GUIStyleState { textColor = new Color32(16, 16, 16, 255), background = Custome2Texture }, fontSize = 15 }))
                    {
                        PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(Code);
                    }

                    if (GUI.Button(new Rect(100, 160, 80, 25), "     Name", new GUIStyle { normal = new GUIStyleState { textColor = new Color32(16, 16, 16, 255), background = Custome2Texture }, fontSize = 15 }))
                    {
                        PhotonNetwork.LocalPlayer.NickName = (Code);
                    }

                    if (GUI.Button(new Rect(100, 190, 80, 25), "Disconnect", new GUIStyle { normal = new GUIStyleState { textColor = new Color32(16, 16, 16, 255), background = Custome2Texture }, fontSize = 15 }))
                    {
                        PhotonNetwork.Disconnect();
                    }

                    ToggleButton18 = GUI.Toggle(new Rect(100, 220, 80, 25), ToggleButton18, "    Master [D!]", new GUIStyle { normal = new GUIStyleState { textColor = new Color32(16, 16, 16, 255), background = ToggleButton18 ? Custome5Texture : Custome2Texture }, fontSize = 15 });
                    if (ToggleButton18)
                    {

                    }

                    ToggleButton19 = GUI.Toggle(new Rect(100, 250, 80, 25), ToggleButton19, "    Anything", new GUIStyle { normal = new GUIStyleState { textColor = new Color32(16, 16, 16, 255), background = ToggleButton19 ? Custome5Texture : Custome2Texture }, fontSize = 15 });
                    if (ToggleButton19)
                    {

                    }

                }
            }
            GUI.DragWindow();

        }

    }
}
