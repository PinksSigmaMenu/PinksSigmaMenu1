using PinkMenu.Mods;
using PinkMenu.Classes;
using PinkMenu.Helpers;
using PinkMenu.Mods;
using PinkMenu.Mods.Holdables;
using UnityEngine;
using static PinkMenu.Config;
using PinkMenu.Managers;
using StupidTemplate.Mods;

namespace PinkMenu.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Guns", method =() => SettingsMods.GunSettings(), isTogglable = false, toolTip = "gun stuff"},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "NetWorking Mods", method =() => SettingsMods.NetWorkingStuff(), isTogglable = false, toolTip = "networking mods"},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Projectile mods"},
                new ButtonInfo { buttonText = "Stuff", method =() => SettingsMods.Stuffimade(), isTogglable = false, toolTip = "its stuff"},
                new ButtonInfo { buttonText = "Visuals", method =() => SettingsMods.VisuaSettings(), isTogglable = false, toolTip = "visual mods"},
            },


            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Change Theme", method =() => ThemeManager.NextTheme(), isTogglable = false, toolTip = "Changes theme"},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "AntiReport", method =() => AntiReport.Check(), enabled = true, toolTip = "it makes you leave before you get reported"},
                new ButtonInfo { buttonText = "InfoHut", method =() => ModIndo.MenuInfo(), enabled = true, toolTip = "Shows Player IDS on code of conduct boared"},
                new ButtonInfo { buttonText = "Custom Sky", method =() => Custom_Sky.CustomSky(), enabled = true, toolTip = "Changes sky color"},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "MOTD", method =() => Display22.MOTDTXT(), enabled = true, toolTip = "Changes motd"},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "ScoreBoard Changer", method =() => ScoreboardHelper.UpdateBoardColor(), enabled = true, toolTip = "changes scoreboards"},
                new ButtonInfo { buttonText = "Wrist menu", method =() => WristMenuThing.WristMenu(), enabled = false, toolTip = "Its a menu for your wrist"},
                 new ButtonInfo { buttonText = "Wrist menu", method =() => Display22.ConductIDS(), enabled = false, toolTip = "Its a menu for your wrist"},

            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Bat orbit", method =() => Movement.BatHalo(), isTogglable = true, toolTip = "Makes the bat fly around you"},
               // new ButtonInfo { buttonText = "Platforms", method =() => Movement.Plats(), isTogglable = true, toolTip = "Its platforms"},
                new ButtonInfo { buttonText = "Beach Ball orbit", method =() => Movement.BeachBallHalo(), isTogglable = true, toolTip = "Makes Beach ball fly arounf you"},
                new ButtonInfo { buttonText = "Bug orbit", method =() => Movement.BugHalo(), isTogglable = true, toolTip = "Makes doug fly around you"},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), isTogglable = true, toolTip = "Makes you fly"},
                new ButtonInfo { buttonText = "Invis Monke", method =() => Movement.ghostmonkeywithballs(), isTogglable = true, toolTip = "makes you invisable bitch"},
                new ButtonInfo { buttonText = "Loud Hand Taps", method =() => Movement.loudhandtaps(), isTogglable = true, toolTip = "Makes your hand taps loud!"},
                new ButtonInfo { buttonText = "No Hand Taps", method =() => Movement.nohandtaps(), isTogglable = true, toolTip = "makes it so there is no sound to handtaps!"},
                new ButtonInfo { buttonText = "Quiet Hand Taps", method =() => Movement.quiethandtaps(), isTogglable = true, toolTip = "Makes your hand taps quiet!"},
                new ButtonInfo { buttonText = "Spazzy Monkey", method =() => Movement.InsaneMonkey(), isTogglable = true, toolTip = "Makes you go insane"},
                new ButtonInfo { buttonText = "Spazzy Hands", method =() => Movement.SpazzyHands(), isTogglable = true, toolTip = "Spazzes hands"},
                new ButtonInfo { buttonText = "Trigger Fly", method =() => Movement.TriggerFly(), isTogglable = true, toolTip = "Makes you fly with Trigger"},
                new ButtonInfo { buttonText = "UpAndDown", method =() => Movement.UpAndDownsyndrome(), isTogglable = true, toolTip = "Makes you go up and down with right and left grip"},
                new ButtonInfo { buttonText = "Rotate Head Y", method =() => TrollStuff.RotateHeadY(), isTogglable = true, toolTip = "Rotates Head in the Y axis"},
                new ButtonInfo { buttonText = "Rotate Head Z", method =() => TrollStuff.RotateHeadZ(), isTogglable = true, toolTip = "Rotates Head in the Z axis"},
                new ButtonInfo { buttonText = "Rotate Head X", method =() => TrollStuff.RotateHeadX(), isTogglable = true, toolTip = "Rotates Head in the X axis"},
                new ButtonInfo { buttonText = "Fix Head Position", method =() => TrollStuff.FixHeadRotation(), isTogglable = true, toolTip = "Fixes Head Rotaion"},
                new ButtonInfo { buttonText = "Fast Hand Taps", method =() => TrollStuff.FastHandTaps(), isTogglable = true, toolTip = "Makes your hand taps fast"},


            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Candy Spammer", method =() => Spammers.ScienceCandySpammer(), isTogglable = true, toolTip = "Spams Candy!"},
                new ButtonInfo { buttonText = "Food Spammer", method =() => Spammers.FishFoodSpammer(), isTogglable = true, toolTip = "Spams Food!"},
                new ButtonInfo { buttonText = "Gift Spammer", method =() => Spammers.ThrowableGiftSpammer(), isTogglable = true, toolTip = "Spams Gifts!"},
                new ButtonInfo { buttonText = "Lave Rock Spammer", method =() => Spammers.LavaRockSpammer(), isTogglable = true, toolTip = "Spams Lava rocks!"},
                new ButtonInfo { buttonText = "SnowBall Spammer", method =() => Spammers.SnowBallSpammer(), isTogglable = true, toolTip = "Spams snow balls!"},
                new ButtonInfo { buttonText = "Ultra Spam", method =() => Spammers.SuperSpam(), isTogglable = true, toolTip = "Spams Food!"},
               // new ButtonInfo { buttonText = "Water Balloon Spammer", method =() => Spammers.WaterBalloonSpammer(), isTogglable = true, toolTip = "Spams snow Waterballoons!"},
            },

            new ButtonInfo[] { // Visual shit
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Beacons", method =() => Visuals.Beaconss(), isTogglable = true, toolTip = "These are beacons to see players ha ha"},
                new ButtonInfo { buttonText = "Full Chams", method =() => Visuals.Tracers(), isTogglable = true, toolTip = "Puts Chams Around The local Gorilla"},
                new ButtonInfo { buttonText = "Capsule ESP", method =() => Visuals.CapsuleESPP(), isTogglable = true, toolTip = "Lets you see people threw walls"},
                new ButtonInfo { buttonText = "Head ESP", method =() => Visuals.HeadESP(), isTogglable = true, toolTip = "Esp for head"},
                new ButtonInfo { buttonText = "Hunt ESP", method =() => Visuals.HuntBreadcrumbs(), isTogglable = true, toolTip = "Shows the person whos targeting you"},
                new ButtonInfo { buttonText = "PeanSP", method =() => Visuals.PeenSP(), isTogglable = true, toolTip = "PeainSP"},
                new ButtonInfo { buttonText = "Shit ESP", method =() => Visuals.Sigma(), isTogglable = true, toolTip = "its the worst esp"},
                new ButtonInfo { buttonText = "Snake ESP", method =() => Visuals.SnakeESP(), isTogglable = true, toolTip = "puts esp on players head and follows it"},
                new ButtonInfo { buttonText = "Tracers", method =() => Visuals.Tracers(), isTogglable = true, toolTip = "Puts tracers on your body"},
                new ButtonInfo { buttonText = "Hand Tracers", method =() => Visuals.HandTracers(), isTogglable = true, toolTip = "Puts tracers on your hands"},
                new ButtonInfo { buttonText = "BoneESP", method =() => Visuals.BoneESP(), isTogglable = true, toolTip = "Its bone esp"},
                new ButtonInfo { buttonText = "TracersV2", method =() => Visuals.HoldableTracers(), isTogglable = true, toolTip = "Cool Tracers"},

            },

            new ButtonInfo[] { // Stuff
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Angry Gorillas", method =() => Stuff.AngryGorillas(), isTogglable = true, toolTip = "Makes you disconnect when a gorilla touches you"},
                new ButtonInfo { buttonText = "Cube Hands", method =() => Stuff.SquareHands(), isTogglable = true, toolTip = "Cube Hands"},
                new ButtonInfo { buttonText = "Dress", method =() => Stuff.Dress(), isTogglable = true, toolTip = "Gives you dress"},
                new ButtonInfo { buttonText = "Pink User Preset", method =() => Stuff.PinkUseridentityPreset(), isTogglable = true, toolTip = "Pink User Preset"},
                new ButtonInfo { buttonText = "RightGrab Change idenity", method =() => Stuff.rightgrabchangeidentity(), isTogglable = true, toolTip = "Changes idenity with right grab"},
                new ButtonInfo { buttonText = "Sphere Hands", method =() => Stuff.SphereHands(), isTogglable = true, toolTip = "Sphere Hands"},
                new ButtonInfo { buttonText = "Spazzy Names", method =() => Stuff.SpazzyNames(), isTogglable = true, toolTip = "Spazzes Name"},
                
            },

            new ButtonInfo[] { // Guns
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Tag Gun", method =() => Gun.UpdateGun((WeHit) => Guns.InternalTag(WeHit)), isTogglable = true, toolTip = "Tag Gun"},
                new ButtonInfo { buttonText = "Glider Gun", method =() => Gun.UpdateGun((WeHit) => Guns.GliderGun(WeHit)), isTogglable = true, toolTip = "Puts gliders on guns"},

            },

            new ButtonInfo[] { // NetWorking Stuff
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Extra Disconnect", method =() => NetworkStuff.ExtraDisconnect(), isTogglable = false, toolTip = "Disconnects you from the server"},
                new ButtonInfo { buttonText = "Connect to EU", method =() => NetworkStuff.ConnectToEU(), isTogglable = false, toolTip = "Connects you to eu servers"},
                new ButtonInfo { buttonText = "Connect to US", method =() => NetworkStuff.ConnectToUS(), isTogglable = false, toolTip = "Connects you to us servers"},
                new ButtonInfo { buttonText = "Connect to USW", method =() => NetworkStuff.ConnectToUSW(), isTogglable = false, toolTip = "Connects you to usw servers"},
                new ButtonInfo { buttonText = "Left grab Disconnect", method =() => NetworkStuff.LeftTriggerDisconnect(), isTogglable = true, toolTip = "disconnects you when you press left grab"},
                new ButtonInfo { buttonText = "Right grab Disconnect", method =() => NetworkStuff.RightTriggerDisconnect(), isTogglable = true, toolTip = "disconnects you when you press right grab"},
                new ButtonInfo { buttonText = "Set Master", method =() => NetworkStuff.SetMaster(), isTogglable = false, toolTip = "Sets Master"},
                new ButtonInfo { buttonText = "Disable network triggers", method =() => NetworkStuff.DisableNetworkTriggers(), isTogglable = false, toolTip = "Disables network triggers"},
                new ButtonInfo { buttonText = "Right Button Network triggers", method =() => NetworkStuff.ControllerDisableNetworkTriggers(), isTogglable = true, toolTip = "Enables and Disables"},
                new ButtonInfo { buttonText = "Right Button Network triggers", method =() => NetworkStuff.ControllerDisableNetworkTriggers(), isTogglable = true, toolTip = "Enables and Disables"},
                new ButtonInfo { buttonText = "Make Rain", method =() => NetworkStuff.Rain(), isTogglable = false, toolTip = "Makes it rain"},
                new ButtonInfo { buttonText = "Button Rain", method =() => NetworkStuff.RainButtons(), isTogglable = true, toolTip = "Use Right Primary to enable and right secondary to disable"},

             // new ButtonInfo { buttonText = "Thing", method =() => OpCrashAll.ProcessButtonAction(), isTogglable = false, toolTip = "Its a thing"},
            },

        };
    }
}
