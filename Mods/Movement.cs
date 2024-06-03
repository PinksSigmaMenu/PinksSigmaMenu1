using GorillaLocomotion;
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
using UnityEngine.XR;

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

        public static void SpeedBoost()
        {
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 20f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 20f;
        }



        public static void BatHalo()
        {
            float offset = 360f / 3f;
            GameObject caveBat = GameObject.Find("Cave Bat Holdable");
            if (caveBat)
            {
                caveBat.GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
                caveBat.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 1, MathF.Sin(offset + ((float)Time.frameCount / 30)));
            }
        }

        public static void BeachBallHalo()
        {
            float offset = (360f / 3f) * 2f;
            GameObject.Find("BeachBall").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 1f, MathF.Sin(offset + ((float)Time.frameCount / 30)));
        }

        public static void BugHalo()
        {
            float offset = 0;
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
            GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 1f, MathF.Sin(offset + ((float)Time.frameCount / 30)));
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

        public static void TriggerFly()
        {
            float Ltrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);

            if (Ltrigger > 0.5f)
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
        public static void GrabRig()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static class MonsterGrabber
        {
            public static void GrabMonsters()
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    MoveAllMonkeysToRightHand();
                }
            }

            private static void MoveAllMonkeysToRightHand()
            {
                Vector3 rightHandPosition = GorillaTagger.Instance.rightHandTransform.position;

                MonkeyeAI[] monkeys = UnityEngine.Object.FindObjectsOfType<MonkeyeAI>();

                foreach (MonkeyeAI monkey in monkeys)
                {
                    MoveMonkeyToPosition(monkey, rightHandPosition);
                }
            }

            private static void MoveMonkeyToPosition(MonkeyeAI monkey, Vector3 position)
            {
                monkey.gameObject.transform.position = position;
            }
        }

        public static class MonsterOrbit
        {
            private static float orbitRadius = 2.0f;
            private static float orbitSpeed = 1.0f;
            private static List<MonkeyeAI> spawnedMonkeys = new List<MonkeyeAI>();
            private static GameObject monkeyPrefab;

            public static void SetMonkeyPrefab(GameObject prefab)
            {
                monkeyPrefab = prefab;
            }

            public static void OrbitMonkeys()
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    if (spawnedMonkeys.Count == 0)
                    {
                        SpawnMonkeys(5);
                    }
                    OrbitMonkeysAroundHead();
                }
            }

            private static void SpawnMonkeys(int numMonkeys)
            {
                for (int i = 0; i < numMonkeys; i++)
                {
                    MonkeyeAI newMonkey = SpawnMonkey();
                    if (newMonkey)
                    {
                        spawnedMonkeys.Add(newMonkey);
                    }
                }
            }

            private static void OrbitMonkeysAroundHead()
            {
                Vector3 headPosition = GorillaTagger.Instance.offlineVRRig.head.headTransform.position;

                float angleStep = 360.0f / spawnedMonkeys.Count;

                for (int i = 0; i < spawnedMonkeys.Count; i++)
                {
                    float angle = Time.time * orbitSpeed + i * angleStep;
                    Vector3 orbitPosition = CalculateOrbitPosition(headPosition, angle);
                    MoveMonkeyToPosition(spawnedMonkeys[i], orbitPosition);
                }
            }



            private static Vector3 CalculateOrbitPosition(Vector3 center, float angle)
            {
                float radian = angle * Mathf.Deg2Rad;
                float x = center.x + orbitRadius * Mathf.Cos(radian);
                float z = center.z + orbitRadius * Mathf.Sin(radian);
                return new Vector3(x, center.y, z);
            }

            private static void MoveMonkeyToPosition(MonkeyeAI monkey, Vector3 position)
            {
                monkey.gameObject.transform.position = position;
            }

            private static MonkeyeAI SpawnMonkey()
            {
                if (monkeyPrefab == null)
                {
                    Debug.LogError("Monkey prefab is not set.");
                    return null;
                }

                GameObject monkeyObject = GameObject.Instantiate(monkeyPrefab);
                MonkeyeAI monkeyAI = monkeyObject.GetComponent<MonkeyeAI>();
                return monkeyAI;
            }
        }


        public static GameObject rplat;
        public static GameObject lplat;
        public static GameObject platformsL;
        public static GameObject platformsR;
        public static bool rplatEnabled = false;
        public static bool lplatEnabled = false;

        private static Color pingPongColor;

        public static void NormalPlats()
        {
            if (pingPongColor == Color.clear)
                pingPongColor = Color.Lerp(SigmaColors.hotPink, SigmaColors.lightPink, 0.5f);

            pingPongColor = Color.Lerp(SigmaColors.hotPink, SigmaColors.lightPink, Mathf.PingPong(Time.time, 1));

            if (ControllerInputPoller.instance.rightGrab)
            {
                NormalPlats(ref rplat, ref platformsR, GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.rotation, pingPongColor);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                NormalPlats(ref lplat, ref platformsL, GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.rotation, pingPongColor);
            }
            DestroyPlatformIfNotGrabbing(ControllerInputPoller.instance.rightGrab, ref rplat, ref platformsR);
            DestroyPlatformIfNotGrabbing(ControllerInputPoller.instance.leftGrab, ref lplat, ref platformsL);
        }

        private static void NormalPlats(ref GameObject platform, ref GameObject platformParent, Vector3 position, Quaternion rotation, Color platformColor)
        {
            if (platform)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.GetComponent<Renderer>().material.color = platformColor;
                platform.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platform.transform.position = position;
                platform.transform.rotation = rotation;
                platform.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);

                platformParent = new GameObject("PlatformParent");
                platformParent.transform.position = position;
                platformParent.transform.rotation = rotation;

                GameObject platformChild = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platformChild.transform.parent = platformParent.transform;
                platformChild.GetComponent<Renderer>().material.color = Color.black;
                platformChild.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platformChild.transform.localPosition = Vector3.zero;
                platformChild.transform.localRotation = Quaternion.identity;
                platformChild.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);

                GameObject outline1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                outline1.transform.parent = platformParent.transform;
                outline1.GetComponent<Renderer>().material.color = Color.black;
                outline1.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                outline1.transform.localPosition = Vector3.back * 0.00f;
                outline1.transform.localRotation = Quaternion.identity;
                outline1.transform.localScale = new Vector3(0.01f, 0.26f, 0.001f);

                GameObject outline2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                outline2.transform.parent = platformParent.transform;
                outline2.GetComponent<Renderer>().material.color = Color.black;
                outline2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                outline2.transform.localPosition = Vector3.back * 0.0f;
                outline2.transform.localRotation = Quaternion.identity;
                outline2.transform.localScale = new Vector3(0.001f, 0.26f, 0.26f);
            }
        }
        //your a pussy if you skid this it took me legit hours to make this shit
        private static void DestroyPlatformIfNotGrabbing(bool isGrabbing, ref GameObject platform, ref GameObject platformParent)
        {
            if (!isGrabbing && platform)
            {
                GameObject.Destroy(platform);
                GameObject.Destroy(platformParent);
                platform = null;
                platformParent = null;
            }
        }

        public static void TriggerPlats()
        {
            float rightTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand);
            float leftTrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);

            if (pingPongColor == Color.clear)
                pingPongColor = Color.Lerp(SigmaColors.hotPink, SigmaColors.lightPink, 0.5f);

            pingPongColor = Color.Lerp(SigmaColors.hotPink, SigmaColors.lightPink, Mathf.PingPong(Time.time, 1));

            if (rightTrigger > 0)
            {
                TriggerPlats(ref rplat, ref platformsR, GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.rotation, pingPongColor);
            }
            if (leftTrigger > 0)
            {
                TriggerPlats(ref lplat, ref platformsL, GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.rotation, pingPongColor);
            }
            DestroyPlatformIfNotTriggering(rightTrigger > 0, ref rplat, ref platformsR);
            DestroyPlatformIfNotTriggering(leftTrigger > 0, ref lplat, ref platformsL);
        }

        private static void TriggerPlats(ref GameObject platform, ref GameObject platformParent, Vector3 position, Quaternion rotation, Color platformColor)
        {
            if (platform)
            {
                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.GetComponent<Renderer>().material.color = platformColor;
                platform.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platform.transform.position = position;
                platform.transform.rotation = rotation;
                platform.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);

                platformParent = new GameObject("PlatformParent");
                platformParent.transform.position = position;
                platformParent.transform.rotation = rotation;

                GameObject platformChild = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platformChild.transform.parent = platformParent.transform;
                platformChild.GetComponent<Renderer>().material.color = Color.black;
                platformChild.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platformChild.transform.localPosition = Vector3.zero;
                platformChild.transform.localRotation = Quaternion.identity;
                platformChild.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);

                GameObject outline1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                outline1.transform.parent = platformParent.transform;
                outline1.GetComponent<Renderer>().material.color = Color.black;
                outline1.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                outline1.transform.localPosition = Vector3.back * 0.00f;
                outline1.transform.localRotation = Quaternion.identity;
                outline1.transform.localScale = new Vector3(0.01f, 0.26f, 0.001f);

                GameObject outline2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                outline2.transform.parent = platformParent.transform;
                outline2.GetComponent<Renderer>().material.color = Color.black;
                outline2.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                outline2.transform.localPosition = Vector3.back * 0.0f;
                outline2.transform.localRotation = Quaternion.identity;
                outline2.transform.localScale = new Vector3(0.001f, 0.26f, 0.26f);
            }
        }

        private static void DestroyPlatformIfNotTriggering(bool isTriggering, ref GameObject platform, ref GameObject platformParent)
        {
            if (!isTriggering && platform)
            {
                GameObject.Destroy(platform);
                GameObject.Destroy(platformParent);
                platform = null;
                platformParent = null;
            }
        }
    }
}

      




































