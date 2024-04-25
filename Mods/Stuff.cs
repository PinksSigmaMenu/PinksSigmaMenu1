using GTAG_NotificationLib;
using Oculus.Platform;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using Meta.Voice.Samples.Shapes;
using UnityEngine.ProBuilder.MeshOperations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Data;
using System.Collections;

class Stuff
{
    public static void SquareHands()
    {

        Color DarkPink = new Color(0.75f, 0.0f, 0.5f);

        GameObject OBJ = GameObject.CreatePrimitive(PrimitiveType.Cube);

        OBJ.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
        OBJ.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHandTransform.rotation;
        OBJ.transform.localScale = new Vector3(0.30f, 0.38f, 0.30f);

        Shader Shader1 = Shader.Find("GorillaTag/UberShader");
        Material Mats = new Material(Shader1);
        OBJ.GetComponent<Renderer>().material = Mats;
        OBJ.GetComponent<Renderer>().material.color = DarkPink;
        UnityEngine.Object.Destroy(OBJ, Time.deltaTime);
        Collider collider = OBJ.GetComponent<Collider>();
        if (collider != null)
        {
            UnityEngine.Object.Destroy(collider);
        }

        Color Darkpink2 = new Color(0.75f, 0.0f, 0.5f);

        GameObject OBJ2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

        OBJ2.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
        OBJ2.transform.rotation = GorillaTagger.Instance.offlineVRRig.leftHandTransform.rotation;
        OBJ2.transform.localScale = new Vector3(0.30f, 0.38f, 0.30f);

        Shader Shader2 = Shader.Find("GorillaTag/UberShader");
        Material Mats2 = new Material(Shader2);
        OBJ2.GetComponent<Renderer>().material = Mats2;
        OBJ2.GetComponent<Renderer>().material.color = Darkpink2;
        UnityEngine.Object.Destroy(OBJ2, Time.deltaTime);
        Collider collider2 = OBJ2.GetComponent<Collider>();
        if (collider2 != null)
        {
            UnityEngine.Object.Destroy(collider2);
        }

    }
    public static void SphereHands()
    {

        Color DarkPink = new Color(0.75f, 0.0f, 0.5f);

        GameObject OBJ = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        OBJ.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
        OBJ.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHandTransform.rotation;
        OBJ.transform.localScale = new Vector3(0.30f, 0.38f, 0.30f);

        Shader Shader1 = Shader.Find("GorillaTag/UberShader");
        Material Mats = new Material(Shader1);
        OBJ.GetComponent<Renderer>().material = Mats;
        OBJ.GetComponent<Renderer>().material.color = DarkPink;
        UnityEngine.Object.Destroy(OBJ, Time.deltaTime);
        Collider collider = OBJ.GetComponent<Collider>();
        if (collider != null)
        {
            UnityEngine.Object.Destroy(collider);
        }

        Color Darkpink2 = new Color(0.75f, 0.0f, 0.5f);

        GameObject OBJ2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        OBJ2.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
        OBJ2.transform.rotation = GorillaTagger.Instance.offlineVRRig.leftHandTransform.rotation;
        OBJ2.transform.localScale = new Vector3(0.30f, 0.38f, 0.30f);

        Shader Shader2 = Shader.Find("GorillaTag/UberShader");
        Material Mats2 = new Material(Shader2);
        OBJ2.GetComponent<Renderer>().material = Mats2;
        OBJ2.GetComponent<Renderer>().material.color = Darkpink2;
        UnityEngine.Object.Destroy(OBJ2, Time.deltaTime);
        Collider collider2 = OBJ2.GetComponent<Collider>();
        if (collider2 != null)
        {
            UnityEngine.Object.Destroy(collider2);
        }
    }
    public static void Dress()
    {
        Color BaseColor = new Color(255, 0, 255); // Pink color

        GameObject Pean = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        Pean.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
        Pean.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
        Pean.transform.position += new Vector3(0f, -0.50f, 0f);
        Pean.transform.localScale = new Vector3(0.40f, 0.57f, 0.60f);

        Shader Shader2 = Shader.Find("GorillaTag/UberShader");
        Material Mats2 = new Material(Shader2);
        Pean.GetComponent<Renderer>().material = Mats2;
        Pean.GetComponent<Renderer>().material.color = BaseColor;
        UnityEngine.Object.Destroy(Pean, Time.deltaTime);
        Collider collider2 = Pean.GetComponent<Collider>();
        if (collider2 != null)
        {
            UnityEngine.Object.Destroy(collider2);
        }
    }
}

   


