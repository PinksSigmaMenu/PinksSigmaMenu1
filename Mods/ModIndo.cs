using PinkMenu.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace PinkMenu.Mods
{
    internal class ModIndo
    {
        public static void MenuInfo()
        {
            GameObject signPosition = GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/outerstores/Bottom Floor/OutsideBuildings/InfoAnchor/infosign");

            GameObject textObject = new GameObject("TextObject");
            textObject.transform.position = signPosition.transform.position + Vector3.up * 0.10f; 
            textObject.transform.rotation = signPosition.transform.rotation * Quaternion.Euler(0f, 90f, 0f); 
            textObject.transform.localScale = new Vector3(0.20f, 0.20f, 0.20f);

            textObject.transform.Rotate(Vector3.up, 180f);

            TextMeshPro textComponent = textObject.AddComponent<TextMeshPro>();
            textComponent.text = "Pink Menu Info Hut";
            textComponent.fontSize = 1;
            textComponent.color = SigmaColors.hotPink; 
            textComponent.enableAutoSizing = true;
            textComponent.fontSizeMin = 0;
            textComponent.fontStyle = FontStyles.Italic;
            textComponent.alignment = TextAlignmentOptions.Center;
            textComponent.richText = true;

            UnityEngine.Object.Destroy(textObject, Time.deltaTime);
        }
    }
}
