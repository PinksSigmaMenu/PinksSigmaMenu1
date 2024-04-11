using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace StupidTemplate.Mods.Stuff
{
    internal class MOTDTEX
    {
        public static void MOTDTXT()
        {
            GameObject motdObject = GameObject.Find("motdtext");

            if (motdObject != null)
            {
                Text motdText = motdObject.GetComponent<Text>();

                if (motdText != null)
                {
                    Text motd = motdObject.GetComponent<Text>();
                    float lerp = Mathf.PingPong(Time.time, 1) / 1;
                    Color color = Color.Lerp(Color.magenta, Color.black, lerp);
                    motdText.color = color;

                    motdText.text = "HELLO FELLOW SIGMA WELCOME TO PINKS SIGMA MENU I HOPE YOU ENJOY AND MAKE SURE TO RIZZ UP ALL OF THEM LEVEL 10s";


                }
            }
        }
    }
}
