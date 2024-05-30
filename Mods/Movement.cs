﻿using GorillaLocomotion;
using PinkMenu.Patches;
using Photon.Pun;
using Photon.Realtime;
using PinkMenu.Classes;
using PinkMenu.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Text;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem.XR;
using UnityEngine.Playables;
using Valve.VR.InteractionSystem;
using BepInEx;
using ExitGames.Client.Photon;
using Fusion;
using g3;
using GorillaNetworking;
using GorillaTag;
using HarmonyLib;
using Meta.WitAi.Events;
using PlayFab;
using POpusCodec.Enums;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using Valve.Newtonsoft.Json.Converters;
using Valve.VR;
using static Unity.Burst.Intrinsics.Arm;
using PinkMenu.Mods;
using PinkMenu.Helpers;
using PinkMenu.Managers;

namespace PinkMenu.Mods
{
    internal class Movement
    {

        public static bool isMaster()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                return true;
            }
            return false;
        }

        public static bool inModded()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED"))
            {
                return true;
            }
            return false;
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

        public static void BatHalo()
        {
            float offset = 360f / 3f;
            GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
            GameObject.Find("Cave Bat Holdable").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 2, MathF.Sin(offset + ((float)Time.frameCount / 30)));
        }

        public static void BeachBallHalo()
        {
            float offset = (360f / 3f) * 2f;
            GameObject.Find("BeachBall").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 2, MathF.Sin(offset + ((float)Time.frameCount / 30)));
        }

        public static void BugHalo()
        {
            float offset = 0;
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
            GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 2, MathF.Sin(offset + ((float)Time.frameCount / 30)));
        }
        public static void instacrash()
        {
            Application.Quit();
        }

        public static void InsaneMonkey()
        {
            GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3(
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f));

            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3(
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f));

            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3(
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f),
                UnityEngine.Random.Range(0f, 360f));

            GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
        }
        public static void loudhandtaps()
        {
            GorillaTagger.Instance.handTapVolume = 999;
        }

        public static void quiethandtaps()
        {
            GorillaTagger.Instance.handTapVolume = 0.10f;
        }

        public static void nohandtaps()
        {
            GorillaTagger.Instance.handTapVolume = 0;
        }



        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        //
        private static bool moveForward = false;
        private static bool moveBackward = false;
        private static bool moveLeft = false;
        private static bool moveRight = false;

        public static void UpdateFlyControls()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                moveForward = true;
                moveBackward = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                moveLeft = true;
                moveRight = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                moveBackward = true;
                moveForward = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                moveRight = true;
                moveLeft = false;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                moveForward = false;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                moveLeft = false;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                moveBackward = false;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                moveRight = false;
            }

            Vector3 movement = Vector3.zero;

            if (moveForward)
            {
                movement += GorillaTagger.Instance.transform.forward;
            }
            else if (moveBackward)
            {
                movement -= GorillaTagger.Instance.transform.forward;
            }

            if (moveRight)
            {
                movement += GorillaTagger.Instance.transform.right;
            }
            else if (moveLeft)
            {
                movement -= GorillaTagger.Instance.transform.right;
            }

            GorillaTagger.Instance.rigidbody.MovePosition(GorillaTagger.Instance.rigidbody.position + movement * 15f * Time.deltaTime);
        }
        //;
        public static void TriggerFly()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void SpazzyHands()
        {
            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3(
            UnityEngine.Random.Range(0f, 360f),
            UnityEngine.Random.Range(0f, 360f),
            UnityEngine.Random.Range(0f, 360f));

            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3(
            UnityEngine.Random.Range(0f, 360f),
            UnityEngine.Random.Range(0f, 360f),
            UnityEngine.Random.Range(0f, 360f));
        }



        static bool isGrabbing = false;
        static bool wasRightGrabToggled = false;

        public static void ghostmonkeywithballs()
        {

            if (ControllerInputPoller.instance.rightGrab && !wasRightGrabToggled)
            {
                isGrabbing = !isGrabbing;
                wasRightGrabToggled = true; 
                if (isGrabbing)
                {
                    GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(9999f, 9999f, 9999f);

                    GameObject[] InvisBalls = BallManager.GetInvisMonkeBalls();

                    InvisBalls[0].transform.position = GorillaTagger.Instance.rightHandTransform.transform.position;
                    InvisBalls[0].transform.rotation = GorillaTagger.Instance.rightHandTransform.transform.rotation;

                    InvisBalls[1].transform.position = GorillaTagger.Instance.rightHandTransform.transform.position;
                    InvisBalls[1].transform.rotation = GorillaTagger.Instance.rightHandTransform.transform.rotation;
                }
            }
            else if (!ControllerInputPoller.instance.rightGrab && wasRightGrabToggled)
            {
                wasRightGrabToggled = false; 
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                isGrabbing = false; 
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
        }

   
      private static GameObject RPlat;
        private static GameObject LPlat;
        private static System.Action<UnityEngine.Object> Destroy = UnityEngine.Object.Destroy;
        public static void Plats() 
        { 
            if (ControllerInputPoller.instance.leftGrab && !wasRightGrabToggled)
            {
                isGrabbing = !isGrabbing;
                wasRightGrabToggled = true;
                if (isGrabbing)
                {
                    LPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    LPlat.transform.localScale = new Vector3(0.25f, 0.05f, 0.5f);
                    Shader ESPShader = Shader.Find("GorillaTag/UberShader");
                    Material sphereMaterial = new Material(ESPShader);
                    RPlat.GetComponent<Renderer>().material = sphereMaterial;

                    LPlat.transform.position = GorillaTagger.Instance.rightHandTransform.transform.position;
                    LPlat.transform.rotation = GorillaTagger.Instance.rightHandTransform.transform.rotation;


                    float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                    LPlat.GetComponent<Renderer>().material.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);

                    Destroy(LPlat);
                }

            if (ControllerInputPoller.instance.rightGrab && !wasRightGrabToggled)
                {
                    isGrabbing = !isGrabbing;
                    wasRightGrabToggled = true;
                    if (isGrabbing)
                    {
                        RPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        RPlat.transform.localScale = new Vector3(0.25f, 0.05f, 0.5f);
                        Shader ESPShader = Shader.Find("GorillaTag/UberShader");
                        Material sphereMaterial = new Material(ESPShader);
                        RPlat.GetComponent<Renderer>().material = sphereMaterial;

                        RPlat.transform.position = GorillaTagger.Instance.offlineVRRig.rightHand.trackingPositionOffset;
                       // RPlat.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHand.trackingRotationOffset;


                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        RPlat.GetComponent<Renderer>().material.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);

                        Destroy(RPlat);
                    }
                }
            }
            else if (!ControllerInputPoller.instance.rightGrab && wasRightGrabToggled)
            {
                wasRightGrabToggled = false;
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                isGrabbing = false;
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
        }
    }
}
        

          




























