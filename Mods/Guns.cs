using PinkMenu.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace PinkMenu.Mods
{
    internal class Guns
    {
        public static void InternalTag(VRRig WeHit)
        {
            if (WeHit.setMatIndex != 2 && GorillaTagger.Instance.offlineVRRig.setMatIndex == 2)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = WeHit.transform.position - new Vector3(0f, 3f, 0f);
                GorillaTagger.Instance.myVRRig.transform.position = WeHit.transform.position - new Vector3(0f, 3f, 0f);
                GorillaLocomotion.Player.Instance.rightControllerTransform.position = WeHit.transform.position;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void TagAll()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                InternalTag(vrrig);
            }
        }
        public static GliderHoldable[] GliderThing = null;


        public static void LookAtPlayerGun(VRRig WeHit, RaycastHit? ray = null)
        {
            if (WeHit.setMatIndex != 2 && GorillaTagger.Instance.offlineVRRig.setMatIndex == 2)
            {
                VRRig possibly = ray.Value.collider.GetComponentInParent<VRRig>();
                if (possibly && possibly != GorillaTagger.Instance.offlineVRRig)
                {
                    GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(possibly.headMesh.transform.position);
                }
            }
        }

        public static void BugGun(VRRig WeHit)
        {
            if (WeHit.setMatIndex != 2 && GorillaTagger.Instance.offlineVRRig.setMatIndex == 2)
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GameObject Bug = GameObject.Find("Floating Bug Holdable");

                    Bug.transform.position = Gun.GunPointer.transform.position;
                }
            }
        }

        public static void RigGun(VRRig WeHit)
        {
            if (WeHit.setMatIndex != 2 && GorillaTagger.Instance.offlineVRRig.setMatIndex == 2)
            {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    Gun.GunPointer.GetComponent<Renderer>().material.color = SigmaColors.hotPink;
                    SetRigPositions(Gun.GunPointer.transform.position + new Vector3(0f, 0.45f, 0f), Quaternion.identity);
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    Gun.GunPointer.GetComponent<Renderer>().material.color = SigmaColors.hotPink;
            }
        }
        private static void SetRigPositions(Vector3 position, Quaternion rotation)
        {
            GorillaTagger.Instance.offlineVRRig.transform.position = position;
            GorillaTagger.Instance.myVRRig.transform.position = position;
            GorillaTagger.Instance.offlineVRRig.transform.rotation = rotation;
            GorillaTagger.Instance.myVRRig.transform.rotation = rotation;
        }
    }
}

   
