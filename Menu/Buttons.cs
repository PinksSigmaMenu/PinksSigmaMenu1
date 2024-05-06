using DiscordRPC;
using PinkMenu.Mods;
using StupidTemplate.Classes;
using StupidTemplate.Helpers;
using StupidTemplate.Mods;
using StupidTemplate.Mods.Holdables;
using UnityEngine;
using static StupidTemplate.Config;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Projectile mods"},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Visuals", method =() => SettingsMods.VisuaSettings(), isTogglable = false, toolTip = "visual mods"},
                new ButtonInfo { buttonText = "Guns", method =() => SettingsMods.GunSettings(), isTogglable = false, toolTip = "gun stuff"},
                new ButtonInfo { buttonText = "Stuff", method =() => SettingsMods.Stuffimade(), isTogglable = false, toolTip = "its stuff"},
                
            },


            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                
            },

         

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "AntiReport", method =() => AntiCheat.AntiReport(), enabled = true, toolTip = "it makes you leave before you get reported"},
                new ButtonInfo { buttonText = "Conduct Player IDS", method =() => Display22.ConductIDS(), enabled = true, toolTip = "Shows Player IDS on code of conduct boared"},
                new ButtonInfo { buttonText = "MOTD", method =() => Display22.MOTDTXT(), enabled = true, toolTip = "Changes motd"},
                new ButtonInfo { buttonText = "Custom Sky", method =() => Custom_Sky.CustomSky(), enabled = true, toolTip = "Changes sky color"},
                new ButtonInfo { buttonText = "Wrist menu", method =() => WristMenuThing.WristMenu(), enabled = false, toolTip = "Its a menu for your wrist"},
                new ButtonInfo { buttonText = "ScoreBoard Changer", method =() => Display22.UpdateColors(), enabled = true, toolTip = "Changes sky color"},
            },


            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "UpAndDown", method =() => Movement.UpAndDownsyndrome(), isTogglable = true, toolTip = "Makes you go up and down with right and left grip"},
                new ButtonInfo { buttonText = "Invis Monke", method =() => Movement.ghostmonkeywithballs(), isTogglable = true, toolTip = "makes you invisable bitch"},
                new ButtonInfo { buttonText = "Spazzy Monkey", method =() => Movement.InsaneMonkey(), isTogglable = true, toolTip = "Makes you go insane"},
                new ButtonInfo { buttonText = "Bug orbit", method =() => Movement.BugHalo(), isTogglable = true, toolTip = "Makes doug fly around you"},
                new ButtonInfo { buttonText = "Bat orbit", method =() => Movement.BatHalo(), isTogglable = true, toolTip = "Makes the bat fly around you"},
                new ButtonInfo { buttonText = "Beach Ball orbit", method =() => Movement.BeachBallHalo(), isTogglable = true, toolTip = "Makes Beach ball fly arounf you"},
                new ButtonInfo { buttonText = "Loud Hand Taps", method =() => Movement.loudhandtaps(), isTogglable = true, toolTip = "Makes your hand taps loud!"},
                new ButtonInfo { buttonText = "Quiet Hand Taps", method =() => Movement.quiethandtaps(), isTogglable = true, toolTip = "Makes your hand taps quiet!"},
                new ButtonInfo { buttonText = "No Hand Taps", method =() => Movement.nohandtaps(), isTogglable = true, toolTip = "makes it so there is no sound to handtaps!"},
                new ButtonInfo { buttonText = "Right grab Disconnect", method =() => Movement.RightTriggerDisconnect(), isTogglable = true, toolTip = "disconnects you when you press right grab"},
                new ButtonInfo { buttonText = "Left grab Disconnect", method =() => Movement.LeftTriggerDisconnect(), isTogglable = true, toolTip = "disconnects you when you press left grab"},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), isTogglable = true, toolTip = "Makes you fly"},
                new ButtonInfo { buttonText = "NoClip Fly", method =() => FlyingController.NoClipFly(), isTogglable = true, toolTip = "Makes you fly with noclip"},
                new ButtonInfo { buttonText = "Trigger Fly", method =() => Movement.TriggerFly(), isTogglable = true, toolTip = "Makes you fly with Trigger"},
                new ButtonInfo { buttonText = "Spazzy Hands", method =() => Movement.SpazzyHands(), isTogglable = true, toolTip = "Spazzes hands"},
             // new ButtonInfo { buttonText = "WASD Fly", method =() => Movement.UpdateFlyControls(), isTogglable = true, toolTip = "Makes you fly with WASD"},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "SnowBall Spammer", method =() => Spammers.SnowBallSpammer(), isTogglable = true, toolTip = "Spams snow balls!"},
                new ButtonInfo { buttonText = "Water Balloon Spammer", method =() => Spammers.WaterBalloonSpammer(), isTogglable = true, toolTip = "Spams snow Waterballoons!"},
                new ButtonInfo { buttonText = "Lave Rock Spammer", method =() => Spammers.LavaRockSpammer(), isTogglable = true, toolTip = "Spams Lava rocks!"},
                new ButtonInfo { buttonText = "Gift Spammer", method =() => Spammers.ThrowableGiftSpammer(), isTogglable = true, toolTip = "Spams Gifts!"},
                new ButtonInfo { buttonText = "Candy Spammer", method =() => Spammers.ScienceCandySpammer(), isTogglable = true, toolTip = "Spams Candy!"},
                new ButtonInfo { buttonText = "Food Spammer", method =() => Spammers.FishFoodSpammer(), isTogglable = true, toolTip = "Spams Food!"},
                new ButtonInfo { buttonText = "Ultra Spam", method =() => Spammers.SuperSpam(), isTogglable = true, toolTip = "Spams Food!"},
            },

            new ButtonInfo[] { //Visual shit
                new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Capsule ESP", method =() => Visuals.CapsuleESPP(), isTogglable = true, toolTip = "Lets you see people threw walls"},
                new ButtonInfo { buttonText = "Snake ESP", method =() => Visuals.SnakeESP(), isTogglable = true, toolTip = "puts esp on players head and follows it"},
                new ButtonInfo { buttonText = "Doug ESP", method =() => Visuals.BugESPP(), isTogglable = true, toolTip = "Makes it so you can see doug through walls"},
                new ButtonInfo { buttonText = "Head ESP", method =() => Visuals.HeadESP(), isTogglable = true, toolTip = "Esp for head"},
                new ButtonInfo { buttonText = "Tracers", method =() => Visuals.Tracers(), isTogglable = true, toolTip = "Puts tracers on your body"},
                new ButtonInfo { buttonText = "Hand Tracers", method =() => Visuals.HandTracers(), isTogglable = true, toolTip = "Puts tracers on your hands"},
                new ButtonInfo { buttonText = "Beacons", method =() => Visuals.Beaconss(), isTogglable = true, toolTip = "These are beacons to see players ha ha"},
                new ButtonInfo { buttonText = "PeanSP", method =() => Visuals.PeenSP(), isTogglable = true, toolTip = "PeainSP"},
                new ButtonInfo { buttonText = "Shit ESP", method =() => Visuals.Sigma(), isTogglable = true, toolTip = "its the worst esp"},
                new ButtonInfo { buttonText = "Hunt ESP", method =() => Visuals.HuntBreadcrumbs(), isTogglable = true, toolTip = "Shows the person whos targeting you"},
                //new ButtonInfo { buttonText = "Wireframe BoxESP", method =() => Visuals.BoxESP2(), isTogglable = true, toolTip = "Shows the person whos targeting you"},
                //new ButtonInfo { buttonText = "Bone ESP", method =() => Visuals.BoneESP(), isTogglable = true, toolTip = "Bone ESP"},
            },



          

           new ButtonInfo[] { //Stuff
               new ButtonInfo { buttonText = "Return", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
               new ButtonInfo { buttonText = "Pink User Preset", method =() => Stuff.PinkUseridentityPreset(), isTogglable = true, toolTip = "Pink User Preset"},
               new ButtonInfo { buttonText = "Spazzy Names", method =() => Stuff.SpazzyNames(), isTogglable = true, toolTip = "Spazzes Name"},
               new ButtonInfo { buttonText = "RightGrab Change idenity", method =() => Stuff.rightgrabchangeidentity(), isTogglable = true, toolTip = "Changes idenity with right grab"},
               new ButtonInfo { buttonText = "Cube Hands", method =() => Stuff.SquareHands(), isTogglable = true, toolTip = "Cube Hands"},
               new ButtonInfo { buttonText = "Sphere Hands", method =() => Stuff.SphereHands(), isTogglable = true, toolTip = "Sphere Hands"},
               new ButtonInfo { buttonText = "Dress", method =() => Stuff.Dress(), isTogglable = true, toolTip = "Gives you dress"},
               new ButtonInfo { buttonText = "Angry Gorillas", method =() => Stuff.AngryGorillas(), isTogglable = true, toolTip = "Makes you disconnect when a gorilla touches you"},
               //new ButtonInfo { buttonText = "Grab Rig", method =() => Stuff.AngryGorillas(), isTogglable = true, toolTip = "Grabs your rig"},

            },


           new ButtonInfo[] { //Guns
               
               new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
               new ButtonInfo { buttonText = "Tag Gun", method =() => Gun.UpdateGun((WeHit) => Guns.InternalTag(WeHit)), isTogglable = true, toolTip = "Tag Gun"},
                

            },


        





        };
    }
}





