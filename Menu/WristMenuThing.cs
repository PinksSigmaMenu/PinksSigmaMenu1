using UnityEngine;
using TMPro;
using PinkMenu.Helpers;

namespace PinkMenu.Menu
{
    internal class WristMenuThing
    {
        public static void WristMenu()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject backobject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                backobject.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + GorillaTagger.Instance.bodyCollider.transform.forward * 0.7f;
                backobject.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                backobject.transform.localScale = new Vector3(0.01f, 0.80f, 0.80f);
                UnityEngine.Object.Destroy(backobject, Time.deltaTime);

                Material backMaterial = new Material(Shader.Find("GorillaTag/UberShader"));
                backobject.GetComponent<Renderer>().material = backMaterial;
                backMaterial.color = Color.Lerp(SigmaColors.darkGoldenrod, SigmaColors.lightGoldenrod, Mathf.PingPong(Time.time / 2f, 1f));

                GameObject menuObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                menuObject.transform.position = backobject.transform.position;
                menuObject.transform.rotation = backobject.transform.rotation;
                menuObject.transform.localScale = new Vector3(0.02f, 0.70f, 0.70f);
                UnityEngine.Object.Destroy(menuObject, Time.deltaTime);

                Material menuMaterial = new Material(Shader.Find("GorillaTag/UberShader"));
                menuObject.GetComponent<Renderer>().material = menuMaterial;
                menuMaterial.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, Mathf.PingPong(Time.time / 2f, 1f));

                GameObject textObject = new GameObject("TextObject");
                textObject.transform.position = menuObject.transform.position + menuObject.transform.forward * 0.2f;
                textObject.transform.rotation = menuObject.transform.rotation;
                textObject.transform.localScale = new Vector3(0.02f, 0.20f, 0.02f);
                TextMeshPro textComponent = textObject.AddComponent<TextMeshPro>();
                textComponent.text = "Pink WristMenu";
                textComponent.fontSize = 1;
                textComponent.color = SigmaColors.aliceBlue;
                textComponent.enableAutoSizing = true;
                textComponent.fontSizeMin = 0;
                textComponent.fontStyle = FontStyles.Italic;
                textComponent.alignment = TextAlignmentOptions.Center;
                textComponent.richText = true;
                MonoBehaviour.Destroy(textObject, Time.deltaTime);
            }
        }
    }
}
