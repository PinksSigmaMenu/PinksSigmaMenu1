using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace StupidTemplate.Mods.Stuff
{
    internal class UpAndDown
    {
        public static void UpAndDownsyndrome()
        {
            if (ControllerInputPoller.instance != null)
            {
                if (ControllerInputPoller.instance.leftGrab)
                {
                    GorillaLocomotion.Player.Instance.transform.Translate(Vector3.up * 2f, Space.World);
                }
                else if (ControllerInputPoller.instance.rightGrab)
                {
                    GorillaLocomotion.Player.Instance.transform.Translate(Vector3.down * 2f, Space.World);
                }
            }
        }
    }
}













