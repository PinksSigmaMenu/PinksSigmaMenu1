using ExitGames.Client.Photon.StructWrapping;
using GorillaLocomotion;
using Oculus.Interaction;
using Photon.Pun;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace StupidTemplate.Mods.Holdables
{
    internal class Holdables
    {
        public static void KKKHat()
        {
            GameObject NewHat = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewHat.transform.position = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
            NewHat.transform.rotation = GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation;
            NewHat.transform.position += new Vector3(0f, 0.20f, 0f);
            NewHat.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            Shader ESPShader = Shader.Find("GorillaTag/UberShader");
            Material sphereMaterial = new Material(ESPShader);
            NewHat.GetComponent<Renderer>().material = sphereMaterial;
            Collider collider = NewHat.GetComponent<Collider>();
            if (collider != null)
            {
                UnityEngine.Object.Destroy(collider);
            }
            UnityEngine.Object.Destroy(NewHat, Time.deltaTime);


            GameObject NewHat2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewHat2.transform.position = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
            NewHat2.transform.rotation = GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation;
            NewHat2.transform.position += new Vector3(0f, 0.27f, 0f);
            NewHat2.transform.localScale = new Vector3(0.20f, 0.20f, 0.20f);
            Shader ESPShader2 = Shader.Find("GorillaTag/UberShader");
            Material sphereMaterial2 = new Material(ESPShader2);
            NewHat2.GetComponent<Renderer>().material = sphereMaterial2;
            Collider collider2 = NewHat2.GetComponent<Collider>();
            if (collider != null)
            {
                UnityEngine.Object.Destroy(collider2);
            }
            UnityEngine.Object.Destroy(NewHat2, Time.deltaTime);


            GameObject NewHat3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewHat3.transform.position = GorillaTagger.Instance.offlineVRRig.headMesh.transform.position;
            NewHat3.transform.rotation = GorillaTagger.Instance.offlineVRRig.headMesh.transform.rotation;
            NewHat3.transform.position += new Vector3(0f, 0.33f, 0f);
            NewHat3.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            Shader ESPShader3 = Shader.Find("GorillaTag/UberShader");
            Material sphereMaterial3 = new Material(ESPShader3);
            NewHat3.GetComponent<Renderer>().material = sphereMaterial3;
            Collider collider3 = NewHat3.GetComponent<Collider>();
            if (collider != null)
            {
                UnityEngine.Object.Destroy(collider3);
            }
            UnityEngine.Object.Destroy(NewHat3, Time.deltaTime);
        }

       
      
    }
}
