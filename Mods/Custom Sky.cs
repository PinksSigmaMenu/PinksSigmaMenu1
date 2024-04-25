using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


namespace StupidTemplate.Mods
{
    internal class Custom_Sky
    {
        private Renderer _renderer;

        public static Color pink = new Color(1f, 0.75f, 0.8f);
        public static Color deepPink = new Color(0.976f, 0.725f, 0.945f);
       
        public static void CustomSky()
        {


            Material mat = new Material(Shader.Find("GorillaTag/UberShader"));
            mat.color = Color.Lerp(pink, deepPink, Mathf.PingPong(Time.time, 0.50f));

            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky/newsky (1)").GetComponent<Renderer>().material = mat;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>().material = mat;
          




        }

    }
}
