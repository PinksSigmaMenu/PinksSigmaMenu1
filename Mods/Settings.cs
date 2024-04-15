using static StupidTemplate.Menu.Main;
using static StupidTemplate.Config;
using GTAG_NotificationLib;

namespace StupidTemplate.Mods
{
    internal class SettingsMods
    {
        public static void EnterSettings()
        {
            buttonsType = 1;
        }

        public static void MenuSettings()
        {
            buttonsType = 2;
        }

        public static void MovementSettings()
        {
            buttonsType = 3;
        }

        public static void ProjectileSettings()
        {
            buttonsType = 4;
        }

        public static void VisuaSettings()
        {
            buttonsType = 5;
        }


        public static void OPStuffin()
        {
            buttonsType = 6;            
            
                                
        }

        public static void Stuffimade()
        {
            buttonsType = 7;

         
        }
        public static void GunSettings()
        {
            buttonsType = 8;
        }

        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableFPSCounter()
        {
            fpsCounter = true;
        }

        public static void DisableFPSCounter()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = true;
        }
    }
}
