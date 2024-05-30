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
using PinkMenu.Classes;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static PinkMenu.Menu.Buttons;
using static PinkMenu.Config;
using Steamworks;
using Photon;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using PinkMenu.Menu;
using PinkMenu.Patches;
using System.IO;
using System.Net.Sockets;
using System.Net;
using PinkMenu.Helpers;
using UnityEngine.ProBuilder.MeshOperations;


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

        public static void RightTriggerDisconnect()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void LeftTriggerDisconnect()
        {
            if (ControllerInputPoller.instance.leftGrab)
            {
                PhotonNetwork.Disconnect();
            }
        }

        public static void ConnectToUS()
        {
            PhotonNetwork.ConnectToRegion("us");
        }

        public static void ConnectToUSW()
        {
            PhotonNetwork.ConnectToRegion("usw");
        }

        public static void ConnectToEU()
        {
            PhotonNetwork.ConnectToRegion("eu");
        }

        public static void DisableNetworkTriggers()
        {
            GameObject Triggers = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab");
            if (Triggers)
            {
                Triggers.SetActive(false);
            }
            else
            {
                GameObject Triggers2 = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab");

                Triggers2.SetActive(true);
            }
        }
        public static void ControllerDisableNetworkTriggers()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GameObject Triggers = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab");

                Triggers.active = false;

                NotifiLib.SendNotification("Network triggers disabled");
            }
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GameObject Triggers = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab");

                Triggers.active = true;

                NotifiLib.SendNotification("Network triggers enabled");
            }
        }
        public static void SetMaster()
        {
            if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
            {
                PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            }
            else
            {
                NotifiLib.SendNotification("Master Client Set");

                Main.RPCProtection();

            }
        }
        public static void ExtraDisconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void Rain()
        {
            var rainingArray = Enumerable.Repeat(BetterDayNightManager.WeatherType.Raining, BetterDayNightManager.instance.weatherCycle.Length - 1).ToArray();

            Enumerable.Range(1, BetterDayNightManager.instance.weatherCycle.Length - 1)
                      .Zip(rainingArray, (index, weatherType) => new { index, weatherType })
                      .ToList()
                      .ForEach(pair =>
                      {
                          BetterDayNightManager.instance.weatherCycle[pair.index] = pair.weatherType;
                      });
        }

        public static void RainButtons()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                var rainingArray = Enumerable.Repeat(BetterDayNightManager.WeatherType.Raining, BetterDayNightManager.instance.weatherCycle.Length - 1).ToArray();

                Enumerable.Range(1, BetterDayNightManager.instance.weatherCycle.Length - 1)
                          .Zip(rainingArray, (index, weatherType) => new { index, weatherType })
                          .ToList()
                          .ForEach(pair =>
                          {
                              BetterDayNightManager.instance.weatherCycle[pair.index] = pair.weatherType;
                          });
            }

            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                bool isRainActive = false;
                for (int i = 1; i < BetterDayNightManager.instance.weatherCycle.Length; i++)
                {
                    if (BetterDayNightManager.instance.weatherCycle[i] == BetterDayNightManager.WeatherType.Raining)
                    {
                        isRainActive = true;
                        break;
                    }
                }
                if (isRainActive)
                {
                    for (int i = 1; i < BetterDayNightManager.instance.weatherCycle.Length; i++)
                    {
                        BetterDayNightManager.instance.weatherCycle[i] = BetterDayNightManager.WeatherType.None;
                    }
                }
            }
        }
    }
}
         
  













