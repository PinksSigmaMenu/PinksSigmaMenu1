using BepInEx;
using ExitGames.Client.Photon;
using HarmonyLib;
using iiMenu.Mods.Spammers;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Classes;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Config;

namespace StupidTemplate.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        // Constant
        public static void Prefix()
        {
            // Initialize Menu
                try
                {
                    bool toOpen = (!rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton) || (rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton);
                    bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                    if (menu == null)
                    {
                        if (toOpen || keyboardOpen)
                        {
                            CreateMenu();
                            RecenterMenu(rightHanded, keyboardOpen);
                            if (reference == null)
                            {
                                CreateReference(rightHanded);
                            }
                        }
                    }
                    else
                    {
                        if ((toOpen || keyboardOpen))
                        {
                            RecenterMenu(rightHanded, keyboardOpen);
                        }
                        else
                        {
                            Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                            if (rightHanded)
                            {
                                comp.velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }
                            else
                            {
                                comp.velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                            }

                            UnityEngine.Object.Destroy(menu, 2);
                            menu = null;

                            UnityEngine.Object.Destroy(reference);
                            reference = null;
                        }
                    }
                }
                catch (Exception exc)
                {
                    UnityEngine.Debug.LogError(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }

            // Constant
                try
                {
                    // Pre-Execution
                        if (fpsObject != null)
                        {
                            fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                        }

                    // Execute Enabled mods
                        foreach (ButtonInfo[] buttonlist in buttons)
                        {
                            foreach (ButtonInfo v in buttonlist)
                            {
                                if (v.enabled)
                                {
                                    if (v.method != null)
                                    {
                                        try
                                        {
                                            v.method.Invoke();
                                        }
                                        catch (Exception exc)
                                        {
                                            UnityEngine.Debug.LogError(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                        }
                                    }
                                }
                            }
                        }
                } catch (Exception exc)
                {
                    UnityEngine.Debug.LogError(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
                }
        }



        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
                menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
                menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
                menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(menuBackground.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(menuBackground.GetComponent<BoxCollider>());
                menuBackground.transform.parent = menu.transform;
                menuBackground.transform.rotation = Quaternion.identity;
                menuBackground.transform.localScale = menuSize;
                menuBackground.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
                menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);

                ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
                colorChanger.colorInfo = backgroundColor;
                colorChanger.Start();






            // Canvas
                canvasObject = new GameObject();
                canvasObject.transform.parent = menu.transform;
                Canvas canvas = canvasObject.AddComponent<Canvas>();
                CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
                canvasObject.AddComponent<GraphicRaycaster>();
                canvas.renderMode = RenderMode.WorldSpace;
                canvasScaler.dynamicPixelsPerUnit = 1000f;

            // Title and FPS
                Text text = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                text.font = currentFont;
                text.text = PluginInfo.Name + " <color=grey>[</color><color=white>" + (pageNumber + 1).ToString() + "</color><color=grey>]</color>";
                text.fontSize = 1;
                text.color = textColors[0];
                text.supportRichText = true;
                text.fontStyle = FontStyle.Italic;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                text.resizeTextMinSize = 0;
                RectTransform component = text.GetComponent<RectTransform>();
                component.localPosition = Vector3.zero;
                component.sizeDelta = new Vector2(0.28f, 0.05f);
                component.position = new Vector3(0.06f, 0f, 0.165f);
                component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                if (fpsCounter)
                {
                    fpsObject = new GameObject
                    {
                        transform =
                    {
                        parent = canvasObject.transform
                    }
                    }.AddComponent<Text>();
                    fpsObject.font = currentFont;
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString();
                    fpsObject.color = textColors[0];
                    fpsObject.fontSize = 1;
                    fpsObject.supportRichText = true;
                    fpsObject.fontStyle = FontStyle.Italic;
                    fpsObject.alignment = TextAnchor.MiddleCenter;
                    fpsObject.horizontalOverflow = UnityEngine.HorizontalWrapMode.Overflow;
                    fpsObject.resizeTextForBestFit = true;
                    fpsObject.resizeTextMinSize = 0;
                    RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                    component2.localPosition = Vector3.zero;
                    component2.sizeDelta = new Vector2(0.28f, 0.02f);
                    component2.position = new Vector3(0.06f, 0f, 0.135f);
                    component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                }

            // Buttons
                // Disconnect
                    if (disconnectButton)
                    {
                        GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        if (!UnityInput.Current.GetKey(KeyCode.Q))
                        {
                            disconnectbutton.layer = 2;
                        }
                        UnityEngine.Object.Destroy(disconnectbutton.GetComponent<Rigidbody>());
                        disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                        disconnectbutton.transform.parent = menu.transform;
                        disconnectbutton.transform.rotation = Quaternion.identity;
                        disconnectbutton.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
                        disconnectbutton.transform.localPosition = new Vector3(0.56f, 0f, 0.6f);
                        disconnectbutton.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                        disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";

                        colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                        colorChanger.colorInfo = buttonColors[0];
                        colorChanger.Start();

                        Text discontext = new GameObject
                        {
                            transform =
                            {
                                parent = canvasObject.transform
                            }
                        }.AddComponent<Text>();
                        discontext.text = "Disconnect";
                        discontext.font = currentFont;
                        discontext.fontSize = 1;
                        discontext.color = textColors[0];
                        discontext.alignment = TextAnchor.MiddleCenter;
                        discontext.resizeTextForBestFit = true;
                        discontext.resizeTextMinSize = 0;

                        RectTransform rectt = discontext.GetComponent<RectTransform>();
                        rectt.localPosition = Vector3.zero;
                        rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                        rectt.localPosition = new Vector3(0.064f, 0f, 0.23f);
                        rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
                    }

                    


                // Page Buttons
                    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(KeyCode.Q))
                    {
                        gameObject.layer = 2;
                    }
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.parent = menu.transform;
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.9f);
                    gameObject.transform.localPosition = new Vector3(0.56f, 0.65f, 0);
                    gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                    gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";

                    colorChanger = gameObject.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = buttonColors[0];
                    colorChanger.Start();

                    text = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    text.font = currentFont;
                    text.text = "<";
                    text.fontSize = 1;
                    text.color = textColors[0];
                    text.alignment = TextAnchor.MiddleCenter;
                    text.resizeTextForBestFit = true;
                    text.resizeTextMinSize = 0;
                    component = text.GetComponent<RectTransform>();
                    component.localPosition = Vector3.zero;
                    component.sizeDelta = new Vector2(0.2f, 0.03f);
                    component.localPosition = new Vector3(0.064f, 0.195f, 0f);
                    component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                    gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    if (!UnityInput.Current.GetKey(KeyCode.Q))
                    {
                        gameObject.layer = 2;
                    }
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    gameObject.transform.parent = menu.transform;
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localScale = new Vector3(0.09f, 0.2f, 0.9f);
                    gameObject.transform.localPosition = new Vector3(0.56f, -0.65f, 0);
                    gameObject.GetComponent<Renderer>().material.color = buttonColors[0].colors[0].color;
                    gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";

                    colorChanger = gameObject.AddComponent<ColorChanger>();
                    colorChanger.colorInfo = buttonColors[0];
                    colorChanger.Start();

                    text = new GameObject
                    {
                        transform =
                        {
                            parent = canvasObject.transform
                        }
                    }.AddComponent<Text>();
                    text.font = currentFont;
                    text.text = ">";
                    text.fontSize = 1;
                    text.color = textColors[0];
                    text.alignment = TextAnchor.MiddleCenter;
                    text.resizeTextForBestFit = true;
                    text.resizeTextMinSize = 0;
                    component = text.GetComponent<RectTransform>();
                    component.localPosition = Vector3.zero;
                    component.sizeDelta = new Vector2(0.2f, 0.03f);
                    component.localPosition = new Vector3(0.064f, -0.195f, 0f);
                    component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

                // Mod Buttons
                    ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
                    for (int i = 0; i < activeButtons.Length; i++)
                    {
                        CreateButton(i * 0.1f, activeButtons[i]);
                    }
        }


        public static void SysFireProjectile(string projectilename, string trailname, Vector3 position, Vector3 velocity, float r, float g, float b, bool bluet, bool oranget, bool noDelay = false)
        {
            Projectiles.BetaFireProjectile(projectilename, position, velocity, new Color(r, g, b, 1f), noDelay);
        }


        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.9f, 0.08f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = buttonColors[1];
            }
            else
            {
                colorChanger.colorInfo = buttonColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = textColors[1];
            }
            else
            {
                text.color = textColors[0];
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Italic;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .03f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static void RPCProtection()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                UnityEngine.Object.Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch
                {
                    TPC = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
                }

                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = new Color32((byte)(backgroundColor.colors[0].color.r * 50), (byte)(backgroundColor.colors[0].color.g * 50), (byte)(backgroundColor.colors[0].color.b * 50), 255);
                    GameObject.Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = (TPC.transform.position + (Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)))) + (Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f)));
                    Vector3 rot = Quaternion.identity.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = backgroundColor.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = backgroundColor;
            colorChanger.Start();
        }

        public static void RPCProtection1()
        {
            if (hasRemovedThisFrame == false)
            {
                hasRemovedThisFrame = true;
                if (GetIndex("Experimental RPC Protection").enabled)
                {
                    RaiseEventOptions options = new RaiseEventOptions();
                    options.CachingOption = EventCaching.RemoveFromRoomCache;
                    options.TargetActors = new int[1] { PhotonNetwork.LocalPlayer.ActorNumber };
                    RaiseEventOptions optionsdos = options;
                    PhotonNetwork.NetworkingClient.OpRaiseEvent(200, null, optionsdos, SendOptions.SendReliable);
                }
                else
                {
                    GorillaNot.instance.rpcErrorMax = int.MaxValue;
                    GorillaNot.instance.rpcCallLimit = int.MaxValue;
                    GorillaNot.instance.logErrorMax = int.MaxValue;
                    // GorillaGameManager.instance.maxProjectilesToKeepTrackOfPerPlayer = int.MaxValue;

                    PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
                    PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
                    PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
                    PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
                    PhotonNetwork.SendAllOutgoingCommands();
                    GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
                }
            }
        }




        public static float ClampMin(float value, float min, float def)
        {
            if (value < min)
                return def;
            return value;
        }
        public static float ClampMax(float value, float max, float def)
        {
            if (value > max)
                return def;
            return value;
        }

        public static void Toggle(string buttonText)
        {
            if (buttonText.Contains("Page"))
            {
                int lastPage = ((buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage) - 1;
                if (buttonText == "PreviousPage")
                {
                    pageNumber--;
                    pageNumber = (int)ClampMin(pageNumber, 0, lastPage);
                }
                else if (buttonText == "NextPage")
                {
                    pageNumber++;
                    pageNumber = (int)ClampMax(pageNumber, lastPage, 0);
                }
                RecreateMenu();
                return;
            }
            ButtonInfo target = GetIndex(buttonText);
            if (target == null)
            {
                UnityEngine.Debug.LogError(buttonText + " does not exist");
                return;
            }

            if (target.isTogglable)
            {
                target.enabled = !target.enabled;

                if (target.enableMethod != null && target.enabled)
                try {target.enableMethod.Invoke();} catch { }

                if (target.disableMethod != null && !target.enabled)
                    try {target.disableMethod.Invoke();} catch { }
            }

            if (target.method != null)
                try {target.method.Invoke();} catch { }

            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in Menu.Buttons.buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }



        // Variables
        public static float projDebounceType = 0.1f;
        public static float projDebounce = 0f;
        public static bool hasRemovedThisFrame = false;

        // Important

        /*public static string[] fullProjectileNames = new string[]
       {
           "SlingshotProjectile",
           "SnowballProjectile",
           "WaterBalloonProjectile",
           "LavaRockProjectile",
           "HornsSlingshotProjectile_PrefabV",
           "CloudSlingshot_Projectile",
           "CupidArrow_Projectile",
           "IceSlingshotProjectile_PrefabV Variant",
           "ElfBow_Projectile",
           "MoltenRockSlingshot_Projectile",
           "SpiderBowProjectile Variant",
           "BucketGift_Cane_Projectile Variant",
           "BucketGift_Coal_Projectile Variant",
           "BucketGift_Roll_Projectile Variant",
           "BucketGift_Round_Projectile Variant",
           "BucketGift_Square_Projectile Variant",
           "ScienceCandyProjectile Variant"
       };*/

        public static string[] fullProjectileNames = new string[]
       {
            "Snowball",
            "WaterBalloon",
            "LavaRock",
            "ThrowableGift",
            "ScienceCandy",
            "FishFood"
       };

        // Objects
                    public static GameObject menu;
                    public static GameObject menuBackground;   
                    public static GameObject reference;
                    public static GameObject canvasObject;
                    public static GameObject pointer;

                    

        public static SphereCollider buttonCollider;
                    public static Camera TPC;
                    public static Text fpsObject;
                    public static Range range;

                    public static bool Invisible = true;
                    public static bool AllowedToInvis = true;
                    private static bool rigPositionSet = false;
        public static float flysped;
                    public static float colorchanger;

        // Data
        public static int pageNumber = 0;
            public static int buttonsType = 0;

        //THE COLOR HOUSE
        public static Color darkGrey = new Color(0.2f, 0.2f, 0.2f);
        public static Color darkRed = new Color(0.5f, 0f, 0f);
        public static Color crimson = new Color(0.86f, 0.08f, 0.24f);
        public static Color maroon = new Color(0.5f, 0f, 0f);
        public static Color indianRed = new Color(0.8f, 0.36f, 0.36f);
        public static Color firebrick = new Color(0.7f, 0.13f, 0.13f);
        public static Color brickRed = new Color(0.8f, 0.25f, 0.33f);
        public static Color tomato = new Color(1f, 0.39f, 0.28f);
        public static Color coral = new Color(1f, 0.5f, 0.31f);
        public static Color darkSalmon = new Color(0.91f, 0.59f, 0.48f);
        public static Color salmon = new Color(0.98f, 0.5f, 0.45f);
        public static Color lightCoral = new Color(0.94f, 0.5f, 0.5f);
        public static Color hotPink = new Color(1f, 0.41f, 0.71f);
        public static Color paleVioletRed = new Color(0.86f, 0.44f, 0.58f);
        public static Color mediumVioletRed = new Color(0.78f, 0.08f, 0.52f);
        public static Color deepPink = new Color(1f, 0.08f, 0.58f);
        public static Color pink = new Color(1f, 0.75f, 0.8f);
        public static Color lightPink = new Color(1f, 0.71f, 0.76f);
        public static Color orchid = new Color(0.85f, 0.44f, 0.84f);
        public static Color mediumOrchid = new Color(0.73f, 0.33f, 0.83f);
        public static Color paleOrchid = new Color(0.86f, 0.44f, 0.84f);
        public static Color purple = new Color(0.5f, 0f, 0.5f);
        public static Color mediumPurple = new Color(0.58f, 0.44f, 0.86f);
        public static Color thistle = new Color(0.85f, 0.75f, 0.85f);
        public static Color plum = new Color(0.87f, 0.63f, 0.87f);
        public static Color lavender = new Color(0.71f, 0.49f, 0.86f);
        public static Color violet = new Color(0.56f, 0.27f, 0.52f);
        public static Color indigo = new Color(0.29f, 0f, 0.51f);
        public static Color slateBlue = new Color(0.42f, 0.35f, 0.8f);
        public static Color darkSlateBlue = new Color(0.28f, 0.24f, 0.55f);
        public static Color mediumSlateBlue = new Color(0.48f, 0.41f, 0.93f);
        public static Color blueViolet = new Color(0.54f, 0.17f, 0.89f);
        public static Color darkViolet = new Color(0.58f, 0f, 0.83f);
        public static Color darkOrchid = new Color(0.6f, 0.2f, 0.8f);
        public static Color darkMagenta = new Color(0.55f, 0f, 0.55f);
        public static Color darkLavender = new Color(0.45f, 0.31f, 0.59f);
        public static Color darkIndigo = new Color(0.25f, 0f, 0.75f);
        public static Color darkCornflowerBlue = new Color(0.11f, 0.15f, 0.47f);
        public static Color darkCyan = new Color(0f, 0.55f, 0.55f);
        public static Color cadetBlue = new Color(0.37f, 0.62f, 0.63f);
        public static Color darkTurquoise = new Color(0f, 0.81f, 0.82f);
        public static Color mediumTurquoise = new Color(0.28f, 0.82f, 0.8f);
        public static Color lightSeaGreen = new Color(0.13f, 0.7f, 0.67f);
        public static Color turquoise = new Color(0.25f, 0.88f, 0.82f);
        public static Color aquamarine = new Color(0.5f, 1f, 0.83f);
        public static Color mediumAquamarine = new Color(0.4f, 0.8f, 0.67f);
        public static Color lightGreen = new Color(0.56f, 0.93f, 0.56f);
        public static Color paleGreen = new Color(0.6f, 0.98f, 0.6f);
        public static Color springGreen = new Color(0f, 1f, 0.5f);
        public static Color mediumSpringGreen = new Color(0f, 0.98f, 0.6f);
        public static Color darkSeaGreen = new Color(0.56f, 0.74f, 0.56f);
        public static Color seaGreen = new Color(0.18f, 0.55f, 0.34f);
        public static Color forestGreen = new Color(0.13f, 0.55f, 0.13f);
        public static Color green = new Color(0f, 0.5f, 0f);
        public static Color darkOliveGreen = new Color(0.33f, 0.42f, 0.18f);
        public static Color oliveDrab = new Color(0.42f, 0.56f, 0.14f);
        public static Color olive = new Color(0.5f, 0.5f, 0f);
        public static Color yellowGreen = new Color(0.6f, 0.8f, 0.2f);
        public static Color chartreuse = new Color(0.5f, 1f, 0f);
        public static Color lawnGreen = new Color(0.49f, 0.99f, 0f);
        public static Color lime = new Color(0f, 1f, 0f);
        public static Color limeGreen = new Color(0.2f, 0.8f, 0.2f);
        public static Color lightGoldenrodYellow = new Color(0.98f, 0.98f, 0.82f);
        public static Color lightYellow = new Color(1f, 1f, 0.88f);
        public static Color paleGoldenrod = new Color(0.93f, 0.91f, 0.67f);
        public static Color darkKhaki = new Color(0.74f, 0.72f, 0.42f);
        public static Color gold = new Color(1f, 0.84f, 0f);
        public static Color lightGoldenrod = new Color(0.98f, 0.98f, 0.82f);
        public static Color goldenrod = new Color(0.85f, 0.65f, 0.13f);
        public static Color darkGoldenrod = new Color(0.72f, 0.53f, 0.04f);
        public static Color rosyBrown = new Color(0.74f, 0.56f, 0.56f);
        public static Color saddleBrown = new Color(0.55f, 0.27f, 0.07f);
        public static Color sienna = new Color(0.63f, 0.32f, 0.18f);
        public static Color peru = new Color(0.8f, 0.52f, 0.25f);
        public static Color burlywood = new Color(0.87f, 0.72f, 0.53f);
        public static Color beige = new Color(0.96f, 0.96f, 0.86f);
        public static Color wheat = new Color(0.96f, 0.87f, 0.7f);
        public static Color sandyBrown = new Color(0.96f, 0.64f, 0.38f);
        public static Color tan = new Color(0.82f, 0.71f, 0.55f);
        public static Color chocolate = new Color(0.82f, 0.41f, 0.12f);
        public static Color brown = new Color(0.65f, 0.16f, 0.16f);
        public static Color lightSalmon = new Color(1f, 0.63f, 0.48f);
        public static Color orange = new Color(1f, 0.65f, 0f);
        public static Color darkOrange = new Color(1f, 0.55f, 0f);
        public static Color orangeRed = new Color(1f, 0.27f, 0f);
        public static Color khaki = new Color(0.94f, 0.9f, 0.55f);
    }

}


