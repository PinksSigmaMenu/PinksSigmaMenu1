﻿using ExitGames.Client.Photon.StructWrapping;
using GorillaLocomotion;
using Oculus.Interaction;
using Photon.Pun;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using iiMenu.Mods.Spammers;
using Oculus.Interaction.Input;
using static Mono.Math.BigInteger;
using static PinkMenu.Managers.RigManager;
using static PinkMenu.Menu.Main;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
using PinkMenu.Managers;
using PinkMenu.Helpers;

namespace PinkMenu.Mods
{
    internal class Visuals
    {
        public static void Beaconss()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig POS in GorillaParent.instance.vrrigs)
                {
                    if (POS != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject Penis = new GameObject("Line");
                        LineRenderer lineRenderer = Penis.AddComponent<LineRenderer>();
                        lineRenderer.startWidth = 0.03f;
                        lineRenderer.endWidth = 0.03f;
                        lineRenderer.positionCount = 2;
                        lineRenderer.SetPosition(0, POS.transform.position + new Vector3(0f, 9999f, 0f));
                        lineRenderer.SetPosition(1, POS.transform.position - new Vector3(0f, 9999f, 0f));
                        Penis.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Penis.transform.position = POS.transform.position;
                        Penis.transform.rotation = POS.transform.rotation;
                        Shader ESPShader = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial = new Material(ESPShader);
                        Penis.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
                        UnityEngine.Object.Destroy(Penis, Time.deltaTime);
                    }
                }
            }
        }
        public static void SnakeESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {

                        GameObject PinksOBJ = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        PinksOBJ.transform.localScale = new Vector3(0.095f, 0.095f, 0.095f);
                        PinksOBJ.transform.position = FullPlayers.transform.position;
                        PinksOBJ.transform.rotation = FullPlayers.transform.rotation;

                        Collider collider = PinksOBJ.GetComponent<Collider>();
                        if (collider != null)
                        {
                            UnityEngine.Object.Destroy(collider);
                        }
                        Shader ESPShader = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial = new Material(ESPShader);
                        PinksOBJ.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
                        UnityEngine.Object.Destroy(PinksOBJ, 0.50f);
                    }
                }
            }
        }
        public static void CapsuleESPP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject PinksPen = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        PinksPen.transform.position = FullPlayers.transform.position;
                        PinksPen.transform.rotation = FullPlayers.transform.rotation;
                        PinksPen.transform.localScale = new Vector3(0.40f, 0.45f, 0.40f);
                        Shader ESPShader = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial = new Material(ESPShader);
                        PinksPen.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        Color transparentMagenta = new Color(SigmaColors.hotPink.r, SigmaColors.hotPink.g, SigmaColors.hotPink.b, 0.5f);
                        Color transparentBlack = new Color(SigmaColors.deepPink.r, SigmaColors.deepPink.g, SigmaColors.deepPink.b, 0.5f);
                        Color lerpedColor = Color.Lerp(transparentMagenta, transparentBlack, pingPongValue);
                        sphereMaterial.color = lerpedColor;
                        UnityEngine.Object.Destroy(PinksPen, Time.deltaTime);
                        Collider collider = PinksPen.GetComponent<Collider>();
                        if (collider != null)
                        {
                            UnityEngine.Object.Destroy(collider);
                        }
                    }
                }
            }
        }
        public static void BugESPP()
        {
            GameObject FloatingBugHoldable = GameObject.Find("Floating Bug Holdable");

            GameObject Obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (FloatingBugHoldable != null)
            {


                Obj.transform.localScale = new Vector3(0.30f, 0.30f, 0.30f);
                Obj.transform.position = FloatingBugHoldable.transform.position;
                Obj.transform.rotation = FloatingBugHoldable.transform.rotation;
                Shader ESPShader3 = Shader.Find("GUI/Text Shader");
                Material sphereMaterial1 = new Material(ESPShader3);
                Obj.GetComponent<Renderer>().material = sphereMaterial1;
                float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                Color transparentMagenta = new Color(SigmaColors.hotPink.r, SigmaColors.hotPink.g, SigmaColors.hotPink.b, 0.5f);
                Color transparentBlack = new Color(SigmaColors.deepPink.r, SigmaColors.deepPink.g, SigmaColors.deepPink.b, 0.5f);
                Color lerpedColor = Color.Lerp(transparentMagenta, transparentBlack, pingPongValue);
                sphereMaterial1.color = lerpedColor;
                Obj.transform.SetParent(FloatingBugHoldable.transform);


                UnityEngine.Object.Destroy(Obj, Time.deltaTime);
            }
            else
            {

            }
        }

        public static void PeenSP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject LeftNut = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        LeftNut.transform.localScale = new Vector3(0.50f, 0.100f, 0.100f);
                        LeftNut.transform.position = FullPlayers.transform.position;
                        LeftNut.transform.rotation = FullPlayers.transform.rotation;
                        Shader ESPShader = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial = new Material(ESPShader);
                        LeftNut.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
                        UnityEngine.Object.Destroy(LeftNut, 0.50f);
                        GameObject rightnut = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        rightnut.transform.localScale = new Vector3(0.50f, 0.100f, 0.100f);
                        rightnut.transform.position = FullPlayers.transform.position;
                        LeftNut.transform.rotation = FullPlayers.transform.rotation;
                        Shader ESPShaderr = Shader.Find("GUI/Text Shader");
                        Material sphereMaterialr = new Material(ESPShader);
                        rightnut.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValuer = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
                        UnityEngine.Object.Destroy(rightnut, 0.100f);
                        GameObject Peanit = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        Peanit.transform.localScale = new Vector3(0.100f, 0.50f, 0.0100f);
                        Peanit.transform.position = FullPlayers.transform.position;
                        Peanit.transform.rotation = FullPlayers.transform.rotation;
                        Shader ESPShader3 = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial1 = new Material(ESPShader);
                        Peanit.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);
                        UnityEngine.Object.Destroy(Peanit, 0.50f);
                        Collider collider = Peanit.GetComponent<Collider>();
                        if (collider != null)
                        {
                            UnityEngine.Object.Destroy(collider);
                        }
                        UnityEngine.Object.Destroy(LeftNut, Time.deltaTime);
                        UnityEngine.Object.Destroy(rightnut, Time.deltaTime);
                        UnityEngine.Object.Destroy(Peanit, Time.deltaTime);
                    }
                }
            }
        }
        public static void Sigma()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig Sigmarizz in GorillaParent.instance.vrrigs)
                {
                    if (Sigmarizz != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject Sigma = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        Sigma.transform.position = Sigmarizz.transform.position;
                        Sigma.transform.rotation = Sigmarizz.transform.rotation;
                        Sigma.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                        Shader ShaderShit = Shader.Find("GUI/Text Shader");
                        Material SphereMats = new Material(ShaderShit);
                        Sigma.GetComponent<Renderer>().material = SphereMats;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 1f, 0.90f);
                        SphereMats.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);
                        UnityEngine.Object.Destroy(Sigma, Time.deltaTime);
                    }
                }
            }
        }
        public static void Tracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig Trace in GorillaParent.instance.vrrigs)
                {
                    if (Trace != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject Lines = new GameObject("Line");
                        LineRenderer lineRenderer = Lines.AddComponent<LineRenderer>();
                        lineRenderer.SetPosition(0, GorillaTagger.Instance.offlineVRRig.transform.position);
                        lineRenderer.startWidth = 0.02f;
                        lineRenderer.endWidth = 0.02f;
                        lineRenderer.SetPositions(new Vector3[]
                         {
                         Player.Instance.bodyCollider.transform.position,
                        Trace.transform.position,
                        });
                        Shader LineShader = Shader.Find("GUI/Text Shader");
                        Material LineMat = new Material(LineShader);
                        Lines.GetComponent<Renderer>().material = LineMat;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                        LineMat.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);

                        UnityEngine.Object.Destroy(Lines, Time.deltaTime);
                    }
                }
            }
        }
        public static void HandTracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig Trace in GorillaParent.instance.vrrigs)
                {
                    if (Trace != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject Lines = new GameObject("Line");
                        LineRenderer lineRenderer = Lines.AddComponent<LineRenderer>();
                        lineRenderer.SetPosition(0, GorillaTagger.Instance.leftHandTransform.transform.position);
                        lineRenderer.startWidth = 0.02f;
                        lineRenderer.endWidth = 0.02f;
                        lineRenderer.SetPositions(new Vector3[]
                        {
                         Player.Instance.rightControllerTransform.position,
                        Trace.transform.position,
                    });
                        Shader LineShader2 = Shader.Find("GUI/Text Shader");
                        Material LineMat2 = new Material(LineShader2);
                        Lines.GetComponent<Renderer>().material = LineMat2;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                        LineMat2.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);

                        UnityEngine.Object.Destroy(Lines, Time.deltaTime);
                    }
                }
            }
        }
        public static void HeadESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        {
                            GameObject SObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            SObject.transform.position = FullPlayers.transform.position;
                            SObject.transform.rotation = FullPlayers.transform.rotation;
                            SObject.transform.position += new Vector3(0.00f, 0.10f, 0.00f);
                            SObject.transform.localScale = new Vector3(0.40f, 0.40f, 0.40f);


                            Shader ShaderShit = Shader.Find("GUI/Text Shader");
                            Material SphereMats = new Material(ShaderShit);
                            SObject.GetComponent<Renderer>().material = SphereMats;
                            float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                            Color transparentDarkMagenta = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                            Color transparentBlack = new Color(Color.black.r, Color.black.g, Color.black.b, 0.5f);
                            Color lerpedColor = Color.Lerp(transparentDarkMagenta, transparentBlack, pingPongValue1);
                            SphereMats.color = lerpedColor;
                            UnityEngine.Object.Destroy(SObject, Time.deltaTime);
                            Collider collider = SObject.GetComponent<Collider>();
                            if (collider != null)
                            {
                                UnityEngine.Object.Destroy(collider);
                            }
                        }
                    }
                }
            }
        }

        internal class GhostPatch : MonoBehaviour
        {
            public static bool Prefix(VRRig __instance)
            {
                return !(__instance == GorillaTagger.Instance.offlineVRRig);
            }
        }
        // public static void BoneESP()
        //   {
        //      if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
        //      {
        //           foreach (VRRig POS in GorillaParent.instance.vrrigs)
        //          {
        //              if (POS != GorillaTagger.Instance.offlineVRRig)
        //               {
        //                  {
        //                      GameObject HeadLine = new GameObject("Line");
        //                      LineRenderer HeadLineOBJ = HeadLine.AddComponent<LineRenderer>();
        //
        //                      HeadLineOBJ.startWidth = 0.1f;
        //                     HeadLineOBJ.endWidth = 0.1f;
        //                     HeadLineOBJ.transform.rotation = POS.transform.rotation;
        //                     HeadLineOBJ.transform.localScale = new Vector3(1f, 1f, 1f);
        //                   HeadLineOBJ.SetPosition(0, POS.transform.position);
        //                   HeadLineOBJ.SetPosition(1, POS.transform.position);
        //
        //
        //                  Shader HeadLineShader = Shader.Find("GUI/Text Shader");
        //                  Material HeadMaterial = new Material(HeadLineShader);
        //                 HeadLineOBJ.GetComponent<Renderer>().material = HeadMaterial;
        //                 UnityEngine.Object.Destroy(HeadLine, Time.deltaTime);
        //              }
        //             }
        //          }
        //       }
        //      }

        //this is bone esp above if you see this drperky PLES FIX IT


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
                    UnityEngine.Object.Destroy(sphere, Time.deltaTime);
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
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                    UnityEngine.Object.Destroy(sphere, Time.deltaTime);
                }
            }
        }
        public static void GorillaChams()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        Shader ChamsShader = Shader.Find("GUI/Text Shader");
                        Material ChamMaterial = new Material(ChamsShader);
                        FullPlayers.GetComponent<Renderer>().material = ChamMaterial;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                        ChamMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);


                    }
                }
            }
        }






        public static void BoneESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        Transform[] allBoneTransforms = FullPlayers.transform.GetComponentsInChildren<Transform>();

                        foreach (Transform boneTransform in allBoneTransforms)
                        {
                            if (boneTransform != FullPlayers.transform && boneTransform.parent)
                            {
                                GameObject BoneLine = new GameObject("Line");
                                BoneLine.transform.SetParent(boneTransform);
                                LineRenderer lineRenderer = BoneLine.AddComponent<LineRenderer>();

                                List<Vector3> positions = new List<Vector3>();
                                positions.Add(boneTransform.position);
                                positions.Add(boneTransform.parent.position);

                                lineRenderer.startWidth = 0.03f;
                                lineRenderer.endWidth = 0.03f;
                                lineRenderer.positionCount = positions.Count;
                                lineRenderer.SetPositions(positions.ToArray());

                                Shader LineShader = Shader.Find("GUI/Text Shader");
                                Material LineMaterial = new Material(LineShader);
                                lineRenderer.material = LineMaterial;

                                float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                                LineMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);

                            }
                        }
                    }
                }
            }
        }
        public static void HoldableTracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig Trace in GorillaParent.instance.vrrigs)
                {
                    if (Trace != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject SphereObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        SphereObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
                        SphereObject.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHandTransform.rotation;

                        Shader SphereShader = Shader.Find("GUI/Text Shader");
                        Material SphereMat = new Material(SphereShader);
                        SphereObject.GetComponent<Renderer>().material = SphereMat;
                        float pingPongValue2 = Mathf.PingPong(Time.time / 2f, 1f);
                        SphereMat.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue2);

                        UnityEngine.Object.Destroy(SphereObject, Time.deltaTime);

                        Vector3 spherePosition = SphereObject.transform.position;

                        GameObject Lines = new GameObject("Line");
                        LineRenderer lineRenderer = Lines.AddComponent<LineRenderer>();
                        lineRenderer.startWidth = 0.02f;
                        lineRenderer.endWidth = 0.02f;
                        lineRenderer.SetPositions(new Vector3[]
                        {
                    Player.Instance.bodyCollider.transform.position,
                    spherePosition 
                        });

                        Shader LineShader = Shader.Find("GUI/Text Shader");
                        Material LineMat = new Material(LineShader);
                        Lines.GetComponent<Renderer>().material = LineMat;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                        LineMat.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue1);

                        UnityEngine.Object.Destroy(Lines, Time.deltaTime);
                    }
                }
            }
        }
        public static void SnakeESP2()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {

                        GameObject PinksOBJ = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        PinksOBJ.transform.localScale = new Vector3(0.095f, 0.095f, 0.095f);
                        PinksOBJ.transform.position = FullPlayers.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                        PinksOBJ.transform.rotation = FullPlayers.transform.rotation;

                        Collider collider = PinksOBJ.GetComponent<Collider>();
                        if (collider)
                        {
                            UnityEngine.Object.Destroy(collider);
                        }
                        Shader ESPShader = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial = new Material(ESPShader);
                        PinksOBJ.GetComponent<Renderer>().material = sphereMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
                        UnityEngine.Object.Destroy(PinksOBJ, 0.50f);
                    }
                }
            }
        }
    }
}














  