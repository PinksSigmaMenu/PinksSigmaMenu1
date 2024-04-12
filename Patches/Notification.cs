﻿using BepInEx;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Mono;
using Photon.Pun;
using System.Threading;
using ExitGames.Client.Photon;
using UnityEngine.UIElements;
using System.Threading.Tasks;

namespace GTAG_NotificationLib
{
    public class NotifiLib : MonoBehaviour
    {
        public static int notificationDecayTime;
        GameObject HUDObj;
        GameObject HUDObj2;
        GameObject MainCamera;
        Text Testtext;
        Material AlertText = new Material(Shader.Find("GUI/Text Shader"));
        int NotificationDecayTime = 150;
        int NotificationDecayTimeCounter = 150;
        public static int NoticationThreshold = 5; //Amount of notifications before they stop queuing up
        string[] Notifilines;
        string newtext;
        public static string PreviousNotifi;
        bool HasInit = false;
        static Text NotifiText;
        public static bool IsEnabled = true;
        public static void TimedSendNotification(string NotificationText, int clearTime = -1)
        {
            if (clearTime < 0)
            {
                clearTime = notificationDecayTime;
            }
            try
            {
                if (NotifiLib.IsEnabled && NotifiLib.PreviousNotifi != NotificationText)
                {
                    if (!NotificationText.Contains(Environment.NewLine))
                    {
                        NotificationText += Environment.NewLine;
                    }
                    NotifiLib.NotifiText.text = NotifiLib.NotifiText.text + NotificationText;
                    NotifiLib.NotifiText.supportRichText = true;
                    NotifiLib.PreviousNotifi = NotificationText;
                    try
                    {
                        ClearPastNotifications(1);
                    }
                    catch { /* cheeseburger */ }
                }
            }
            catch
            {
                UnityEngine.Debug.LogError("Notification failed, object probably nil due to third person ; " + NotificationText);
            }

        }
        private void Init()
        {
            //this is mostly copy pasted from LHAX, which was also made by me.
            //LHAX got leaked the day before this. so i might as well make this public cus people asked me to.
            MainCamera = GameObject.Find("Main Camera");
            HUDObj = new GameObject();//GameObject.CreatePrimitive(PrimitiveType.Cube);
            HUDObj2 = new GameObject();
            HUDObj2.name = "NOTIFICATIONLIB_HUD_OBJ";
            HUDObj.name = "NOTIFICATIONLIB_HUD_OBJ";
            HUDObj.AddComponent<Canvas>();
            HUDObj.AddComponent<CanvasScaler>();
            HUDObj.AddComponent<GraphicRaycaster>();
            HUDObj.GetComponent<Canvas>().enabled = true;
            HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            HUDObj.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
            HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
            //HUDObj.CreatePrimitive()
            HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);//new Vector3(-67.151f, 11.914f, -82.749f);
            HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
            HUDObj.transform.parent = HUDObj2.transform;
            HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            var Temp = HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
            Temp.y = -270f;
            HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
            HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(Temp);
            GameObject TestText = new GameObject();
            TestText.transform.parent = HUDObj.transform;
            Testtext = TestText.AddComponent<Text>();
            Testtext.text = "";
            Testtext.fontSize = 10;
            Testtext.font = GameObject.Find("COC Text").GetComponent<Text>().font;
            Testtext.rectTransform.sizeDelta = new Vector2(260, 70);
            Testtext.alignment = TextAnchor.LowerLeft;
            Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
            Testtext.rectTransform.localPosition = new Vector3(-1.2f, -.7f, -.6f);
            Testtext.material = AlertText;
            NotifiText = Testtext;
        }

        private void FixedUpdate()
        {
            //This is a bad way to do this, but i do not want to rely on utila.
            if (HasInit == false)
            {
                if (GameObject.Find("Main Camera") != null)
                {
                    Init();
                    HasInit = true;
                }
            }
            HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
            HUDObj2.transform.rotation = MainCamera.transform.rotation;
            //HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            if (Testtext.text != "") //THIS CAUSES A MEMORY LEAK!!!!! -no longer causes a memory leak
            {
                NotificationDecayTimeCounter++;
                if (NotificationDecayTimeCounter > NotificationDecayTime)
                {
                    Notifilines = null;
                    newtext = "";
                    NotificationDecayTimeCounter = 0;
                    Notifilines = Testtext.text.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray();
                    foreach (string Line in Notifilines)
                    {
                        if (Line != "")
                        {
                            newtext = newtext + Line + "\n";
                        }
                    }

                    Testtext.text = newtext;
                }
            }
            else
            {
                NotificationDecayTimeCounter = 0;
            }
        }

        public static float ropedelay;

        public static void SendNotification(string NotificationText)
        {
            if (ropedelay < Time.time)
            {
                ropedelay = Time.time + 0.05f;
                if (IsEnabled)
                {
                    if (!NotificationText.Contains(Environment.NewLine)) { NotificationText = NotificationText + Environment.NewLine; }
                    NotifiText.text = NotifiText.text + NotificationText;
                    PreviousNotifi = NotificationText;
                }
            }
        }
        public static void SendTimedNotification(string NotificationText, float time)
        {
            if (ropedelay < Time.time)
            {
                ropedelay = Time.time + time;
                if (IsEnabled)
                {
                    if (!NotificationText.Contains(Environment.NewLine)) { NotificationText = NotificationText + Environment.NewLine; }
                    NotifiText.text = NotifiText.text + NotificationText;
                    PreviousNotifi = NotificationText;
                }
            }
        }
        public static void ClearAllNotifications()
        {
            NotifiText.text = "";
        }
        public static void ClearPastNotifications(int amount)
        {
            string[] Notifilines = null;
            string newtext = "";
            Notifilines = NotifiText.text.Split(Environment.NewLine.ToCharArray()).Skip(amount).ToArray();
            foreach (string Line in Notifilines)
            {
                if (Line != "")
                {
                    newtext = newtext + Line + "\n";
                }
            }

            NotifiText.text = newtext;
        }
    }
}