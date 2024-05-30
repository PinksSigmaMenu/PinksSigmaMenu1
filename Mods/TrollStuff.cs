using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

namespace PinkMenu.Mods
{
    internal class TrollStuff
    {
        public static void TagLag()
        {
            GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().tagCoolDown = 2E+5f;
        }
        
        public static void GhostMonkey()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new UnityEngine.Vector3(999, 999, 999);
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = UnityEngine.Vector3.zero;
            }
        }
        public static void RotateHeadY()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 150f * Time.deltaTime;
        }

        public static void RotateHeadX()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 150f * Time.deltaTime;
        }

        public static void RotateHeadZ()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 150f * Time.deltaTime;
        }
        public static void FixHeadRotation()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset = UnityEngine.Vector3.zero;
        }
        public static void FastHandTaps()
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
        }
  

    }
}


