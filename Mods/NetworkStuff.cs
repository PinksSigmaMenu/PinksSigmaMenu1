using GorillaNetworking;
using Oculus.Platform;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;
using BepInEx;
using ExitGames.Client.Photon;
using HarmonyLib;
using iiMenu.Mods.Spammers;
using Photon.Realtime;
using StupidTemplate.Classes;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static StupidTemplate.Menu.Buttons;
using static StupidTemplate.Config;
using Steamworks;
using System.Diagnostics;


namespace PinkMenu.Mods
{
    internal class NetworkStuff
    {
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void Reconnect()
        {
            PhotonNetwork.Reconnect();
        }
        public static void JoinRandom()
        {
            PhotonNetwork.JoinRandomRoom();
        }
        public static void CreatePublic()
        {
            PhotonNetwork.CreateRoom("Run Im in your skin", null, null, null);
        }
        public static void Quitgame()
        {
            UnityEngine.Application.Quit();
        }

        public static void SetNight()
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
        }

        public static void SetAfternoon()
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }

        public static void SetDay()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }


    }
}
        

 




