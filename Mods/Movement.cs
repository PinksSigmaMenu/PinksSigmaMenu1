using GorillaLocomotion;
using Photon.Pun;
using StupidTemplate.Menu;
using StupidTemplate.Patches;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using UnityEngine;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Movement
    {
        public static void TagAll()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (GorillaTagManager tagman in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Photon.Realtime.Player v in PhotonNetwork.PlayerList)
                    {
                        if (!tagman.currentInfected.Contains(v))
                        {
                            tagman.currentInfected.Add(v);
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            {
                                GorillaTagger.Instance.leftHandTransform.position = tagman.transform.position;
                                GorillaTagger.Instance.rightHandTransform.position = tagman.transform.position;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                {
                    //NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You must be tagged.</color>");
                }
                else
                {
                    bool isInfectedPlayers = false;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            isInfectedPlayers = true;
                            break;
                        }
                    }
                    if (isInfectedPlayers == true)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (!vrrig.mainSkin.material.name.Contains("fected"))
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;

                                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position - new Vector3(0f, -1f, 2f);
                                GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position - new Vector3(0f, -1f, 2f);
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                GorillaLocomotion.Player.Instance.leftControllerTransform.position = vrrig.transform.position;
                            }
                        }
                    }
                    else
                    {
                        //NotifiLib.SendNotification("<color=grey>[</color><color=purple>SUCCESS</color><color=grey>]</color> <color=white>Everyone is tagged!</color>");
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
        }
        public static void Platformss()
        {
            {

                GameObject RPlat = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                GameObject RPlat2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                if (ControllerInputPoller.instance.rightGrab)

                {
                    RPlat.transform.localScale = new Vector3(0.300f, 0.300f, 0.300f);
                    RPlat.transform.position = GorillaTagger.Instance.rightHandTransform.transform.position;
                    RPlat.transform.rotation = GorillaTagger.Instance.rightHandTransform.transform.rotation;
                }



                GameObject LPlat = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                if (ControllerInputPoller.instance.leftGrab)

                {
                    LPlat.transform.localScale = new Vector3(0.300f, 0.300f, 0.300f);
                    LPlat.transform.position = GorillaTagger.Instance.leftHandTransform.transform.position;
                    LPlat.transform.rotation = GorillaTagger.Instance.leftHandTransform.transform.rotation;
                }

                Shader ESPShader = Shader.Find("GUI/Text Shader");
                Material sphereMaterial = new Material(ESPShader);
                LPlat.GetComponent<Renderer>().material = sphereMaterial;
                float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                sphereMaterial.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);
                Shader ESPShader2 = Shader.Find("GUI/Text Shader");
                Material sphereMaterial2 = new Material(ESPShader);
                RPlat.GetComponent<Renderer>().material = sphereMaterial;
                float pingPongValue2 = Mathf.PingPong(Time.time / 2f, 1f);
                sphereMaterial.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);
                UnityEngine.Object.Destroy(RPlat, Time.deltaTime);
                UnityEngine.Object.Destroy(LPlat, Time.deltaTime);
            }
        }
        public static void UpAndDownsyndrome()
        {
            if (ControllerInputPoller.instance != null)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.Player.Instance.transform.Translate(Vector3.up * 2f, Space.World);
                }
                else if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaLocomotion.Player.Instance.transform.Translate(Vector3.down * 2f, Space.World);
                }
            }
        }

        public static GameObject leftPlatO;
        public static GameObject rightPlatO;
        public static GameObject rightPlat;
        public static GameObject leftPlat;
        public static bool rightPlatTrig = false;
        public static bool leftPlatTrig = false;
        private static bool lastHit;
        private static bool hit;

        public static void lilriftplats()
        {


            if (ControllerInputPoller.instance.rightGrab)
            {



                if (!rightPlatTrig)
                {

                    rightPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rightPlat.GetComponent<Renderer>().material.color = Color.black;
                    rightPlat.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    rightPlat.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    rightPlat.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);
                    rightPlatO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    rightPlatO.GetComponent<Renderer>().material.color = Color.magenta;
                    rightPlatO.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    rightPlatO.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    rightPlatO.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);
                    rightPlatTrig = true;
                }
            }
            else
            {
                if (rightPlatTrig)
                {
                    UnityEngine.Object.Destroy(rightPlat);
                    UnityEngine.Object.Destroy(rightPlatO);
                    rightPlatTrig = false;
                }
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (!leftPlatTrig)
                {
                    leftPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    leftPlat.GetComponent<Renderer>().material.color = Color.black;
                    leftPlat.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    leftPlat.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    leftPlat.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);
                    leftPlatO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    leftPlatO.GetComponent<Renderer>().material.color = Color.magenta;
                    leftPlatO.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    leftPlatO.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    leftPlatO.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);
                    leftPlatTrig = true;
                }
            }
            else
            {
                if (leftPlatTrig)
                {
                    UnityEngine.Object.Destroy(leftPlat);
                    UnityEngine.Object.Destroy(leftPlatO);
                    leftPlatTrig = false;
                }
            }
        }
        public static void lilrifttagall()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (GorillaTagManager tagman in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                {
                    foreach (Photon.Realtime.Player v in PhotonNetwork.PlayerList)
                    {
                        if (!tagman.currentInfected.Contains(v))
                        {
                            tagman.currentInfected.Add(v);
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            if (!tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Add(v);
                            }
                            {
                                GorillaTagger.Instance.leftHandTransform.position = tagman.transform.position;
                                GorillaTagger.Instance.rightHandTransform.position = tagman.transform.position;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                {
                    //NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You must be tagged.</color>");
                }
                else
                {
                    bool isInfectedPlayers = false;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            isInfectedPlayers = true;
                            break;
                        }
                    }
                    if (isInfectedPlayers == true)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (!vrrig.mainSkin.material.name.Contains("fected"))
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;

                                GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position - new Vector3(0f, -1f, 2f);
                                GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position - new Vector3(0f, -1f, 2f);
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                GorillaLocomotion.Player.Instance.leftControllerTransform.position = vrrig.transform.position;
                            }
                        }
                    }
                    else
                    {
                        //NotifiLib.SendNotification("<color=grey>[</color><color=purple>SUCCESS</color><color=grey>]</color> <color=white>Everyone is tagged!</color>");
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
        }
        public static void InsaneMonkey()
        {
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 360),
                (float)UnityEngine.Random.Range(0, 360));
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 360));
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 360));
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 180), 
                (float)UnityEngine.Random.Range(0, 180));
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 180), 
                (float)UnityEngine.Random.Range(0, 180));
            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360), 
                (float)UnityEngine.Random.Range(0, 180), 
                (float)UnityEngine.Random.Range(0, 180));
        }


        public static bool Invisible = true;
        public static bool AllowedToInvis = true;
        private static bool rigPositionSet = false;

        public static void InvisMonke()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {

                Invisible = !Invisible;


                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(99999f, 99999f, 99999f);

                if (rigPositionSet)
                    rigPositionSet = false;
            }



            if (ControllerInputPoller.instance.rightControllerSecondaryButton && !rigPositionSet)
            {

                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
        }
        public static void FlyMode()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Main.flysped;
                Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void TagGun() 
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton) 
            {
                RaycastHit raycastHit;
                Physics.Raycast(Player.Instance.rightControllerTransform.transform.position, Player.Instance.headCollider.transform.forward, out raycastHit);
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Main.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                Main.pointer.transform.position = raycastHit.point;
                Main.pointer.GetComponent<Renderer>().material.color = Color.magenta;
                UnityEngine.Object.Destroy(Main.pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(Main.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(Main.pointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(Main.pointer, Time.deltaTime);
                if (ControllerInputPoller.instance.rightGrab)
                {
                    Player.Instance.rightControllerTransform.position = Main.pointer.transform.position;
                }
                else
                {
                    UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                }
            }
        }
    }
}



