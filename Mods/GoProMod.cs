using GTAG_NotificationLib;
using Oculus.Platform;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

class Gopro
{
    public static void Camera()
    {
        if (ControllerInputPoller.instance.rightGrab)
        {
            GameObject Camera = GameObject.Find("Shoulder/Camera");

            Camera.transform.position = GorillaTagger.Instance.rightHandTransform.position;
            Camera.transform.rotation = GorillaTagger.Instance.rightHandTransform.rotation;



        }
    }
  
}
