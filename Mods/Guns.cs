using PinkMenu.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PinkMenu.Mods
{
    internal class Guns
    {
        public static void InternalTag(VRRig WeHit)
        {
            if (WeHit.setMatIndex != 2 && GorillaTagger.Instance.offlineVRRig.setMatIndex == 2)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = WeHit.transform.position - new Vector3(0f, 3f, 0f);
                GorillaTagger.Instance.myVRRig.transform.position = WeHit.transform.position - new Vector3(0f, 3f, 0f);
                GorillaLocomotion.Player.Instance.rightControllerTransform.position = WeHit.transform.position;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void TagAll()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                InternalTag(vrrig);
            }
        }

    }
}
