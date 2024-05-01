using GorillaLocomotion;
using GTAG_NotificationLib;
using Photon.Pun;
using Photon.Realtime;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Patches;
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
using UnityEngine;
using Valve.Newtonsoft.Json.Converters;
using Valve.VR;
using static Unity.Burst.Intrinsics.Arm;
using static StupidTemplate.Menu.Main;
using StupidTemplate.Mods;
using PinkMenu.Helpers;

namespace StupidTemplate.Mods
{
    internal class Movement
    {
        public static void nofingermovment()
        {

            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }
        public static bool fakeoculusmenu()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                Movement.nofingermovment();
            }
            {
                System.Type type = GorillaLocomotion.Player.Instance.GetType();
                FieldInfo feildInfo = type.GetField("leftHandHolding", BindingFlags.NonPublic | BindingFlags.Instance);
                feildInfo.SetValue(GorillaLocomotion.Player.Instance, ControllerInputPoller.instance.leftControllerPrimaryButton);
                type = GorillaLocomotion.Player.Instance.GetType();
                feildInfo = type.GetField("rightHandHolding", BindingFlags.NonPublic | BindingFlags.Instance);
                feildInfo.SetValue(GorillaLocomotion.Player.Instance, ControllerInputPoller.instance.leftControllerPrimaryButton);
                GorillaLocomotion.Player.Instance.InReportMenu = ControllerInputPoller.instance.leftControllerPrimaryButton;
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller").SetActive(!ControllerInputPoller.instance.leftControllerPrimaryButton);
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller").SetActive(!ControllerInputPoller.instance.leftControllerPrimaryButton);
            }

            return false;
        }
        private static float delaythinggg;
        public static void TagSelf()
        {
            if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && Time.time > delaythinggg)
            {
                PhotonView.Get(GorillaGameManager.instance).RPC("ReportContactWithLavaRPC", RpcTarget.MasterClient, Array.Empty<object>());
                delaythinggg = Time.time + 0.5f;
            }
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    if (!gorillaTagManager.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        gorillaTagManager.currentInfected.Add(PhotonNetwork.LocalPlayer);
                        NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You have been tagged!</color>");

                    }
                }
            }
            else
            {
                foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
                {
                    if (gorillaTagManager.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                    {
                        NotifiLib.SendNotification("<color=grey>[</color><color=green>SUCCESS</color><color=grey>]</color> <color=white>You have been tagged!</color>");
                        GorillaTagger.Instance.offlineVRRig.enabled = true;

                    }
                    else
                    {
                        foreach (VRRig rig in GorillaParent.instance.vrrigs)
                        {
                            if (rig.mainSkin.material.name.Contains("fected"))
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = false;
                                GorillaTagger.Instance.offlineVRRig.transform.position = rig.rightHandTransform.position;
                                GorillaTagger.Instance.myVRRig.transform.position = rig.rightHandTransform.position;
                            }
                        }
                    }
                }
            }
        }
        public static void RpcFlush()
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
        public static void OrbitGliders()
        {
            GliderHoldable[] them = GetGliders();
            int index = 0;
            foreach (GliderHoldable glider in them)
            {
                float offset = (360f / (float)them.Length) * index;
                glider.gameObject.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)) * 5f, 2, MathF.Sin(offset + ((float)Time.frameCount / 30)) * 5f);
                index++;
            }
        }
        public static GliderHoldable[] archiveholdables = null;
        public static GliderHoldable[] GetGliders()
        {
            if (archiveholdables == null)
            {
                archiveholdables = UnityEngine.Object.FindObjectsOfType<GliderHoldable>();
            }
            return archiveholdables;
        }
        public static void FastGliders()
        {
            foreach (GliderHoldable glider in GetGliders())
            {
                glider.pullUpLiftBonus = 0.5f;
                glider.dragVsSpeedDragFactor = 0.5f;
            }
        }
        public static void fortnitemove()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
                }
                catch { }

                GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                }
                catch { }

                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;

                GameObject l = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(l.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(l.GetComponent<SphereCollider>());

                l.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                l.transform.position = GorillaTagger.Instance.leftHandTransform.position;

                GameObject r = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(r.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(r.GetComponent<SphereCollider>());

                r.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                r.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                l.GetComponent<Renderer>().material.color = Color.black;
                r.GetComponent<Renderer>().material.color = Color.blue;

                UnityEngine.Object.Destroy(l, Time.deltaTime);
                UnityEngine.Object.Destroy(r, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
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
        public static void HitTheMeanestGriddy()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                Vector3 bodyOffset = GorillaTagger.Instance.offlineVRRig.transform.forward * (5f * Time.deltaTime);
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + bodyOffset;
                try
                {
                    GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + bodyOffset;
                }
                catch { }

                GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                GorillaTagger.Instance.myVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;

                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + (GorillaTagger.Instance.offlineVRRig.transform.right * -0.33f) + (GorillaTagger.Instance.offlineVRRig.transform.forward * (0.5f * Mathf.Cos((float)Time.frameCount / 10f))) + (GorillaTagger.Instance.offlineVRRig.transform.up * (-0.5f * Mathf.Abs(Mathf.Sin((float)Time.frameCount / 10f))));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + (GorillaTagger.Instance.offlineVRRig.transform.right * 0.33f) + (GorillaTagger.Instance.offlineVRRig.transform.forward * (0.5f * Mathf.Cos((float)Time.frameCount / 10f))) + (GorillaTagger.Instance.offlineVRRig.transform.up * (-0.5f * Mathf.Abs(Mathf.Sin((float)Time.frameCount / 10f))));

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;

                GameObject l = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(l.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(l.GetComponent<SphereCollider>());

                l.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                l.transform.position = GorillaTagger.Instance.leftHandTransform.position;

                GameObject r = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(r.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(r.GetComponent<SphereCollider>());

                r.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                r.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                l.GetComponent<Renderer>().material.color = Color.black;
                r.GetComponent<Renderer>().material.color = Color.blue;

                UnityEngine.Object.Destroy(l, Time.deltaTime);
                UnityEngine.Object.Destroy(r, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void SlowGliders()
        {
            foreach (GliderHoldable glider in GetGliders())
            {
                glider.pullUpLiftBonus = 0.05f;
                glider.dragVsSpeedDragFactor = 0.05f;
            }
        }

        public static void FixGliderSpeed()
        {
            foreach (GliderHoldable glider in GetGliders())
            {
                glider.pullUpLiftBonus = 0.1f;
                glider.dragVsSpeedDragFactor = 0.2f;
            }
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
        public static void loudhandtaps()
        {
            GorillaTagger.Instance.handTapVolume = 999;
        }

        public static void quiethandtaps()
        {
            GorillaTagger.Instance.handTapVolume = 0.50f;
        }

        public static void nohandtaps()
        {
            GorillaTagger.Instance.handTapVolume = 0;
        }

        public static void RightTriggerDisconnect()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void LeftTriggerDisconnect()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

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

        public static void TriggerFly()
        {
            if (ControllerInputPoller.instance.leftControllerGripFloat > 0f)
            {
                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}


    



// <summary>
// 
// private static GameObject RPlat;
// private static GameObject LPlat;
// private static System.Action<UnityEngine.Object> Destroy = UnityEngine.Object.Destroy;
// public static void Plats()
// {
//     if (ControllerInputPoller.instance.rightGrab)
//     {
//         RPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
//         RPlat.transform.localScale = new Vector3(0.25f, 0.05f, 0.5f);
//         Shader ESPShader = Shader.Find("GorillaTag/UberShader");
//         Material sphereMaterial = new Material(ESPShader);
//         RPlat.GetComponent<Renderer>().material = sphereMaterial;
//         RPlat.transform.position = new Vector3(0f, 2f, 0f);
//         RPlat.transform.rotation = Quaternion.identity;
//
//         float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
//         RPlat.GetComponent<Renderer>().material.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);
//         Destroy(RPlat);
//     }
//
//     if (ControllerInputPoller.instance.leftGrab)
//     {
//         LPlat = GameObject.CreatePrimitive(PrimitiveType.Cube);
//         LPlat.transform.localScale = new Vector3(0.25f, 0.05f, 0.5f);
//         Shader ESPShader = Shader.Find("GorillaTag/UberShader");
//         Material sphereMaterial = new Material(ESPShader);
//         LPlat.GetComponent<Renderer>().material = sphereMaterial;
//
//         LPlat.transform.position = new Vector3(0f, 2f, 0f);
//         LPlat.transform.rotation = Quaternion.identity;
//
//         float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
//         LPlat.GetComponent<Renderer>().material.color = Color.Lerp(Color.magenta, Color.black, pingPongValue);
//
//         Destroy(LPlat);
//     }
// }
// }
// </summary>

//Scratched Idea
























