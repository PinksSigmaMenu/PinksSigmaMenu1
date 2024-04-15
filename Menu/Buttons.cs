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
                new ButtonInfo { buttonText = "Disconnect", method =() => NetworkStuff.Disconnect(), isTogglable = false, toolTip = "Disconnects you"},
                new ButtonInfo { buttonText = "Reconnect", method =() => NetworkStuff.Reconnect(), isTogglable = false, toolTip = "Reconnects you"},
                new ButtonInfo { buttonText = "Join random", method =() => NetworkStuff.JoinRandom(), isTogglable = false, toolTip = "Joins random"},
                new ButtonInfo { buttonText = "Create Public Room", method =() => NetworkStuff.CreatePublic(), isTogglable = false, toolTip = "Creates the public room"},
                new ButtonInfo { buttonText = "Quit Game", method =() => NetworkStuff.Quitgame(), isTogglable = true, toolTip = "Creates the public room"},
            },


            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Guns", method =() => SettingsMods.GunSettings(), isTogglable = false, toolTip = "gun stuff"},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Projectile mods"},
                new ButtonInfo { buttonText = "Visuals", method =() => SettingsMods.VisuaSettings(), isTogglable = false, toolTip = "visual mods"},
                new ButtonInfo { buttonText = "Custom Holdables", method =() => SettingsMods.CustomHolds(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "OpStuff", method =() => SettingsMods.OPStuff(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "AntiReport", method =() => AntiCheat.AntiReport(), enabled = true, toolTip = "it makes you leave before you get reported"},
                 new ButtonInfo { buttonText = "Conduct Player IDS", method =() => Display22.ConductIDS(), enabled = true, toolTip = "Shows Player IDS on code of conduct boared"},
                 new ButtonInfo { buttonText = "MOTD", method =() => Display22.MOTDTXT(), enabled = true, toolTip = "Changes motd"},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Tag All", method =() => Guns.TagAll(),  enableMethod = Visuals.coolchamsforrigmods, isTogglable = true,  toolTip = "Tag All if tagged"},
                new ButtonInfo { buttonText = "TagAura", method =() => Visuals.TagAura(), isTogglable = true, toolTip = "Makes Beach ball fly arounf you"},
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.lilriftplats(), isTogglable = true, toolTip = "Normal Platforms"},
                new ButtonInfo { buttonText = "UpAndDown", method =() => Movement.UpAndDownsyndrome(), isTogglable = true, toolTip = "Makes you go up and down with right and left grip"},
                new ButtonInfo { buttonText = "InvisMonke", method =() => Movement.InvisMonke(), isTogglable = true, toolTip = "makes you invisable bitch"},
                new ButtonInfo { buttonText = "Spazzy Monkey", method =() => Movement.InsaneMonkey(), isTogglable = true, toolTip = "Makes you go insane"},
                new ButtonInfo { buttonText = "slow gliders", method =() => Movement.SlowGliders(), isTogglable = true, toolTip = "Slows gliders"},
                new ButtonInfo { buttonText = "Fast Gliders", method =() => Movement.FastGliders(), isTogglable = true, toolTip = "Fast gliders"},
                new ButtonInfo { buttonText = "GLider Orbit", method =() => Movement.OrbitGliders(), isTogglable = true, toolTip = "Orbit gliders"},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.FlyMode(), isTogglable = true, toolTip = "Makes you flyy!!"},
                new ButtonInfo { buttonText = "Hit the meanest griddy", method =() => Movement.HitTheMeanestGriddy(), isTogglable = true, toolTip = "Makes you hit the griddy"},
                new ButtonInfo { buttonText = "Fortnite move", method =() => Movement.fortnitemove(), isTogglable = true, toolTip = "Makes you T pose"},
                new ButtonInfo { buttonText = "Bug orbit", method =() => Movement.BugHalo(), isTogglable = true, toolTip = "Makes doug fly around you"},
                new ButtonInfo { buttonText = "Bat orbit", method =() => Movement.BatHalo(), isTogglable = true, toolTip = "Makes the bat fly around you"},
                new ButtonInfo { buttonText = "Beach Ball orbit", method =() => Movement.BeachBallHalo(), isTogglable = true, toolTip = "Makes Beach ball fly arounf you"},
                new ButtonInfo { buttonText = "Tagself", method =() => Movement.TagSelf(), isTogglable = true, toolTip = "Makes Beach ball fly arounf you"},


            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                 new ButtonInfo { buttonText = "SnowBall Spammer", method =() => Spammers.SnowBallSpammer(), isTogglable = true, toolTip = "Spams snow balls!"},
                 new ButtonInfo { buttonText = "Water Balloon Spammer", method =() => Spammers.WaterBalloonSpammer(), isTogglable = true, toolTip = "Spams snow Waterballoons!"},
                 new ButtonInfo { buttonText = "Lave Rock Spammer", method =() => Spammers.LavaRockSpammer(), isTogglable = true, toolTip = "Spams Lava rocks!"},
                 new ButtonInfo { buttonText = "Gift Spammer", method =() => Spammers.ThrowableGiftSpammer(), isTogglable = true, toolTip = "Spams Gifts!"},
                 new ButtonInfo { buttonText = "Candy Spammer", method =() => Spammers.ScienceCandySpammer(), isTogglable = true, toolTip = "Spams Candy!"},
                 new ButtonInfo { buttonText = "Food Spammer", method =() => Spammers.FishFoodSpammer(), isTogglable = true, toolTip = "Spams Food!"},
                 new ButtonInfo { buttonText = "Ultra Spam", method =() => Spammers.SuperSpam(), isTogglable = true, toolTip = "Spams Food!"},
            },

            new ButtonInfo[] { //Visual shit
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Capsule ESP", method =() => Visuals.CapsuleESPP(), isTogglable = true, toolTip = "Lets you see people threw walls"},
                new ButtonInfo { buttonText = "Snake ESP", method =() => Visuals.SnakeESP(), isTogglable = true, toolTip = "puts esp on players head and follows it"},
                 new ButtonInfo { buttonText = "Doug ESP", method =() => Visuals.BugESPP(), isTogglable = true, toolTip = "Makes it so you can see doug through walls"},
                 new ButtonInfo { buttonText = "Head ESP", method =() => Visuals.HeadESP(), isTogglable = true, toolTip = "Esp for head"},
                  new ButtonInfo { buttonText = "Tracers", method =() => Visuals.Tracers(), isTogglable = true, toolTip = "Puts tracers on your body"},
                new ButtonInfo { buttonText = "Hand Tracers", method =() => Visuals.HandTracers(), isTogglable = true, toolTip = "Puts tracers on your hands"},
                new ButtonInfo { buttonText = "Beacons", method =() => Visuals.Beaconss(), isTogglable = true, toolTip = "These are beacons to see players ha ha"},
                new ButtonInfo { buttonText = "Lilrift snake Chams", method =() => Visuals.lilriftsnakechams(), isTogglable = true, toolTip = "lilrift snake chams"},
                 new ButtonInfo { buttonText = "PeanSP", method =() => Visuals.PeenSP(), isTogglable = true, toolTip = "PeainSP"},
                new ButtonInfo { buttonText = "Shit ESP", method =() => Visuals.Sigma(), isTogglable = true, toolTip = "its the worst esp"},
                new ButtonInfo { buttonText = "Hunt ESP", method =() => Visuals.HuntBreadcrumbs(), isTogglable = true, toolTip = "Shows the person whos targeting you"},
                 new ButtonInfo { buttonText = "Bone ESP", method =() => Visuals.BoneESP(), isTogglable = true, toolTip = "Bone ESP"},
            },

           new ButtonInfo[] { //op stuff
               
               new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
               new ButtonInfo { buttonText = "set master [Modded]", method =() => OPStuff.SetMaster(), isTogglable = true, toolTip = "Sets Master"},
               new ButtonInfo { buttonText = "set master [M]", method =() => OPStuff.AcidAll(), isTogglable = true, toolTip = "Sets Master"},
               new ButtonInfo { buttonText = "Mat Spam [M]", method =() => OPStuff.MatAll(), isTogglable = true, toolTip = "Sets Master"},
               new ButtonInfo { buttonText = "Spaz Soda [M]", method =() => OPStuff.Spazsoda(), isTogglable = true, toolTip = "Sets Master"},
               new ButtonInfo { buttonText = "GoPro", method =() => Gopro.Camera(), isTogglable = true, toolTip = "Its a camera"},
            },
           new ButtonInfo[] { //Guns
               
               new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
               new ButtonInfo { buttonText = "Tag Gun", method =() => Gun.UpdateGun((WeHit) => Guns.InternalTag(WeHit)), isTogglable = true, toolTip = "Tag Gun"},

            },
           new ButtonInfo[] {//Custom holdables

               new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
               new ButtonInfo { buttonText = "KKK Hat", method =() => Holdables.KKKHat(), isTogglable = true, toolTip = "Opens the settings for the menu."},


            },



        };
    }
}
