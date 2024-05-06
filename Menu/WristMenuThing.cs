using PinkMenu.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using ExitGames.Client.Photon.StructWrapping;
using GorillaLocomotion;
using Oculus.Interaction;
using Photon.Pun;
using Steamworks;
using UnityEngine.UIElements;
using System.Linq;
using iiMenu.Mods.Spammers;
using Oculus.Interaction.Input;
using static Mono.Math.BigInteger;
using static PinkMenu.Managers.RigManager;
using static PinkMenu.Menu.Main;
using UnityEngine.Animations.Rigging;

namespace PinkMenu.Menu
{
    internal class WristMenuThing
    {
        public static void WristMenu()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject backobject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                backobject.transform.position = GorillaTagger.Instance.bodyCollider.transform.position;
                backobject.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                backobject.transform.position = backobject.transform.position + backobject.transform.forward * 0.7f;
                backobject.transform.localScale = new Vector3(0.01f, 0.80f, 0.80f);

                UnityEngine.Object.Destroy(backobject, Time.deltaTime);

                Shader ESPShader2 = Shader.Find("GorillaTag/UberShader");
                Material sphereMaterial2 = new Material(ESPShader2);
                backobject.GetComponent<Renderer>().material = sphereMaterial2;

                float pingPongValue2 = Mathf.PingPong(Time.time / 2f, 1f);
                sphereMaterial2.color = Color.Lerp(SigmaColors.darkGoldenrod, SigmaColors.lightGoldenrod, pingPongValue2);

                backobject.transform.Rotate(Vector3.up, 90f);

                GameObject menuObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                menuObject.transform.position = GorillaTagger.Instance.bodyCollider.transform.position;
                menuObject.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                menuObject.transform.position = menuObject.transform.position + menuObject.transform.forward * 0.7f;
                menuObject.transform.localScale = new Vector3(0.02f, 0.70f, 0.70f);

                menuObject.transform.Rotate(Vector3.up, 90f);

                Shader ESPShader = Shader.Find("GorillaTag/UberShader");
                Material sphereMaterial = new Material(ESPShader);
                menuObject.GetComponent<Renderer>().material = sphereMaterial;

                float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                sphereMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);

                UnityEngine.Object.Destroy(menuObject, Time.deltaTime);

                GameObject textObject = new GameObject("TextObject");
                textObject.transform.position = menuObject.transform.position;
                textObject.transform.rotation = menuObject.transform.rotation;
                textObject.transform.position = textObject.transform.position + textObject.transform.forward * 0.2f;
                textObject.transform.localScale = new Vector3(0.02f, 0.20f, 0.02f);

                textObject.transform.Rotate(Vector3.up, 90f);

                TextMeshPro textComponent = textObject.AddComponent<TextMeshPro>();
                textComponent.text = "Pink WristMenu";
                textComponent.fontSize = 1;
                textComponent.color = SigmaColors.aliceBlue;
                textComponent.enableAutoSizing = true;
                textComponent.fontSizeMin = 0;
                textComponent.fontStyle = FontStyles.Italic;
                textComponent.alignment = TextAlignmentOptions.Center;
                textComponent.richText = true;
            }
        }
    }
}
