using ExitGames.Client.Photon;
using GorillaTag;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using static PinkMenu.Managers.RigManager;
using static PinkMenu.Menu.Main;

namespace iiMenu.Mods.Spammers
{
    internal class Projectiles
    {
        public static void BetaFireProjectile(string projectileName, Vector3 position, Vector3 velocity, Color color, bool noDelay = false)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            GameObject lhelp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(lhelp, 0.1f);
            lhelp.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            lhelp.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            lhelp.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
            int[] overrides = new int[]
            {
                32,
                204,
                231,
                240,
                249,
                252
            };
            lhelp.AddComponent<GorillaSurfaceOverride>().overrideIndex = overrides[Array.IndexOf(fullProjectileNames, projectileName)];
            lhelp.GetComponent<Renderer>().enabled = false;
            if (Time.time > projDebounce)
            {
                try
                {
                    Vector3 startpos = position;
                    Vector3 charvel = velocity;

                    Vector3 oldVel = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                    //SnowballThrowable fart = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>();
                    string[] name2 = new string[]
                    {
                        "LMACE.",
                        "LMAEX.",
                        "LMAGD.",
                        "LMAHQ.",
                        "LMAIE.",
                        "LMAIO."
                    };
                    SnowballThrowable fart = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + fullProjectileNames[System.Array.IndexOf(fullProjectileNames, projectileName)] + "LeftAnchor").transform.Find(name2[System.Array.IndexOf(fullProjectileNames, projectileName)]).GetComponent<SnowballThrowable>();
                    Vector3 oldPos = fart.transform.position;
                    fart.randomizeColor = true;
                    fart.transform.position = startpos;
                    //fart.projectilePrefab.tag = projectileName;
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = charvel;
                    GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(true, color);
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                    //fart.OnRelease(null, null);
                    RPCProtection();
                    GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = oldVel;
                    fart.transform.position = oldPos;
                    fart.randomizeColor = false;
                    //fart.projectilePrefab.tag = "SnowballProjectile";
                }
                catch { /*NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>Grab a snowball in your left hand and put it in the snow.</color>");*/ }
                if (projDebounceType > 0f && !noDelay)
                {
                    projDebounce = Time.time + projDebounceType;
                }
            }
        }

        public static void SysFireProjectile(string projectilename, string trailname, Vector3 position, Vector3 velocity, Color snowballColor, float r, float g, float b, bool bluet, bool oranget, bool noDelay = false)
        {
            Projectiles.BetaFireProjectile(projectilename, position, velocity, new Color(r, g, b, 1f), noDelay);
        }

    }
}
//this was made by IIDK he said i could use it (:


