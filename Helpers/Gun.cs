using BepInEx;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.XR;

namespace StupidTemplate.Helpers
{
    internal class Gun

        //penus
    {
        public static GameObject GunPointer = null;
        public static GameObject TeleportGunPointer = null;
        public static LineRenderer LineRender = null;

        public static void CreateGun()
        {
            GunPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GunPointer.GetComponent<Renderer>().material.color = Color.cyan;
            GunPointer.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            UnityEngine.Object.Destroy(GunPointer.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(GunPointer.GetComponent<Collider>());
            GunPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            GunPointer.SetActive(false);

            LineRender = GunPointer.AddComponent<LineRenderer>();
            LineRender.startColor = Color.cyan;
            LineRender.endColor = Color.cyan;
            LineRender.startWidth = 0.01f;
            LineRender.endWidth = 0.01f;
            LineRender.positionCount = 2;
            LineRender.useWorldSpace = true;
            LineRender.material.shader = Shader.Find("GUI/Text Shader");
            LineRender.enabled = false;

            TeleportGunPointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            TeleportGunPointer.GetComponent<Renderer>().material.color = Color.green;
            TeleportGunPointer.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            UnityEngine.Object.Destroy(TeleportGunPointer.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(TeleportGunPointer.GetComponent<Collider>());
            TeleportGunPointer.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            TeleportGunPointer.SetActive(false);
        }

        public static void UpdateGun(Action<VRRig> WhenHit)
        {
            if (GunPointer == null)
                CreateGun();
            if (!ControllerInputPoller.instance.rightGrab)
            {
                GunPointer.SetActive(false);
                LineRender.enabled = false;
                return;
            }

            RaycastHit RaycastResult;
            if (Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, -GorillaTagger.Instance.rightHandTransform.up, out RaycastResult))
            {
                GunPointer.transform.position = RaycastResult.point;
                LineRender.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                LineRender.SetPosition(1, GunPointer.transform.position);
                LineRender.enabled = true;
                GunPointer.SetActive(true);

                if (ControllerInputPoller.TriggerFloat(XRNode.RightHand) > 0.5f)
                {
                    VRRig RigHit = RaycastResult.collider.GetComponentInParent<VRRig>();
                    if (RigHit && RigHit != GorillaTagger.Instance.offlineVRRig)
                        WhenHit(RigHit);
                }
            }
        }
    }
}


