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
        public static void SuperSpam()
        {
            {
                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {

                    Vector3 POS = GorillaTagger.Instance.rightHandTransform.transform.position;
                    Vector3 velocity = GorillaTagger.Instance.bodyCollider.transform.forward * 9f;
                    Color snowballColor = new Color(255f, 195f, 0f);
                    Projectiles.SysFireProjectile("FishFood", "none", POS, velocity, snowballColor, 255f, 195f, 0f, false, false, false);



                    Vector3 POS2 = GorillaTagger.Instance.rightHandTransform.transform.position;
                    Vector3 velocity2 = GorillaTagger.Instance.bodyCollider.transform.forward * 9;
                    Color snowballColor2 = new Color(255f, 195f, 0f);
                    Projectiles.SysFireProjectile("ScienceCandy", "none", POS2, velocity2, snowballColor2, 200f, 140, 0f, false, false, false);


                    Vector3 POS3 = GorillaTagger.Instance.rightHandTransform.transform.position;
                    Vector3 velocity3 = GorillaTagger.Instance.bodyCollider.transform.forward * 9f;
                    Color snowballColor3 = new Color(255f, 195f, 0f);
                    Projectiles.SysFireProjectile("ThrowableGift", "none", POS3, velocity3, snowballColor3, 125, 160, 0f, false, false, false);


                    Vector3 POS4 = GorillaTagger.Instance.rightHandTransform.transform.position;
                    Vector3 velocity4 = GorillaTagger.Instance.bodyCollider.transform.forward * 9f;
                    Color snowballColor4 = new Color(255f, 195f, 0f);
                    Projectiles.SysFireProjectile("LavaRock", "none", POS4, velocity4, snowballColor4, 199, 100, 0f, false, false, false);


                    Vector3 POS5 = GorillaTagger.Instance.rightHandTransform.transform.position;
                    Vector3 velocity5 = GorillaTagger.Instance.bodyCollider.transform.forward * 9f;
                    Color snowballColor5 = new Color(255f, 195f, 0f);
                    Projectiles.SysFireProjectile("Snowball", "none", POS5, velocity5, snowballColor5, 154, 133, 0f, false, false, false);
                }
            }
        }
    }
}



 



                
        

