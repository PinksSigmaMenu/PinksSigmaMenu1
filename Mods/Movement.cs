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
using Valve.Newtonsoft.Json.Converters;
using Valve.VR;
using static Unity.Burst.Intrinsics.Arm;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Movement
    {
        public static void HuntBreadcrumbs()
        {
            GorillaHuntManager sillyComputer = GorillaGameManager.instance.gameObject.GetComponent<GorillaHuntManager>();
            Photon.Realtime.Player target = sillyComputer.GetTargetOf(PhotonNetwork.LocalPlayer);
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                VRRig vrrig = RigManager.GetVRRigFromPlayer(player);
                if (player == target)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;

                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                    sphere.GetComponent<Renderer>().material.color = thecolor;
                    sphere.transform.position = vrrig.transform.position;
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    UnityEngine.Object.Destroy(sphere, 20f);
                }
                if (sillyComputer.GetTargetOf(player) == PhotonNetwork.LocalPlayer)
                {
                    UnityEngine.Color thecolor = Color.magenta;
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(sphere.GetComponent<SphereCollider>());
                    sphere.GetComponent<Renderer>().material.color = thecolor;
                    sphere.transform.position = vrrig.transform.position;
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    UnityEngine.Object.Destroy(sphere, 20f);
                }
            }
        }
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
        public static void InsaneMonkey()
        {
            for (int i = 1; i < 2; i++)
            {
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360),
                (float)UnityEngine.Random.Range(0, 360 / i),
                (float)UnityEngine.Random.Range(0, 360 / i));
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360),
                (float)UnityEngine.Random.Range(0, 360 / i),
                (float)UnityEngine.Random.Range(0, 360 / i));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.eulerAngles = new Vector3(
                (float)UnityEngine.Random.Range(0, 360),
                (float)UnityEngine.Random.Range(0, 360 / i),
                (float)UnityEngine.Random.Range(0, 360 / i));
            }
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
                GorillaLocomotion.Player.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * Main.flysped;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static VRRig player;
    }
}
    





    








