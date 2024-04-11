using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Vector3 = UnityEngine.Vector3;

namespace StupidTemplate.Mods
{
    internal class Teleport
    {
        public static void ForestTP()
        {
            GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-63.9905f, 1.0616f, -69.2698f);
        }

    }
}