using iiMenu.Mods.Spammers;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using static Mono.Math.BigInteger;
using static StupidTemplate.Classes.RigManager;
using static StupidTemplate.Menu.Main;

namespace StupidTemplate.Mods
{
    internal class Spammers
    {
        public static void SnowBallSpammer()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.45f, 0f);

                Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f;

                Color snowballColor = new Color(1f, 0f, 1f);

                Projectiles.SysFireProjectile("Snowball", "none", POS, velocity, snowballColor, 1f, 0f, 1f, false, false, false);

            }
        }
        public static void WaterBalloonSpammer()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.45f, 0f);

                Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f;

                Color snowballColor = new Color(1f, 0f, 1f);

                Projectiles.SysFireProjectile("WaterBalloonSpammer", "none", POS, velocity, snowballColor, 1f, 0f, 1f, false, false, false);

            }
        }
        public static void LavaRockSpammer()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.45f, 0f);

                Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f;

                Color snowballColor = new Color(1f, 0f, 1f);

                Projectiles.SysFireProjectile("LavaRock", "none", POS, velocity, snowballColor, 1f, 0f, 1f, false, false, false);

            }
        }
        public static void ThrowableGiftSpammer()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.45f, 0f);

                Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f;

                Color snowballColor = new Color(1f, 0f, 1f);

                Projectiles.SysFireProjectile("ThrowableGift", "none", POS, velocity, snowballColor, 1f, 0f, 1f, false, false, false);
            }
        }
        public static void ScienceCandySpammer()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.45f, 0f);

                Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f;

                Color snowballColor = new Color(1f, 0f, 1f);

                Projectiles.SysFireProjectile("ScienceCandy", "none", POS, velocity, snowballColor, 0f, 0f, 0f, false, false, false);
            }
        }
        public static void FishFoodSpammer()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 POS = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.45f, 0f);

                Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 8.33f;

                Color snowballColor = new Color(1f, 0f, 1f);

                Projectiles.SysFireProjectile("FishFood", "none", POS, velocity, snowballColor, 1f, 0f, 1f, false, false, false);
            }
        }
    }
}



                
        

