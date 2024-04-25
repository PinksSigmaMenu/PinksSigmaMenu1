using GorillaLocomotion;
using GTAG_NotificationLib;
using BepInEx;
using ExitGames.Client.Photon;
using Fusion;
using g3;
using static StupidTemplate.Classes.RigManager;
using GorillaNetworking;
using GorillaTag;
using HarmonyLib;
using Meta.WitAi.Events;
using Photon.Pun;
using PlayFab;
using POpusCodec.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using Valve.Newtonsoft.Json.Converters;
using Valve.VR;
using static Unity.Burst.Intrinsics.Arm;
using Photon.Realtime;
using System.Text.RegularExpressions;


namespace StupidTemplate.Mods
{
    internal class OPStuff
    {
        private static float spamtagdelay;

        public static void SetMaster()
        {
            if (!Movement.isMaster())
            {
                if (PhotonNetwork.InRoom)
                {
                    if (PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().ToLower().Contains("modded"))
                    {
                        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                    }
                    else
                    {
                        NotifiLib.SendNotification("You are not in a modded room.");
                    }
                }
            }
            else
            {
                NotifiLib.SendNotification("You are already master client.");
            }
        }
        //sigam add me back later
        public static void AntiBan()
        {
            {
                Photon.Realtime.Player DADDYPINK = PhotonNetwork.LocalPlayer;
                ExitGames.Client.Photon.Hashtable hash = new ExitGames.Client.Photon.Hashtable
                {
                    { "gameMode", PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Replace(GorillaComputer.instance.currentQueue, GorillaComputer.instance.currentQueue + "MODDEDMODDED") }
                };
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                PhotonNetwork.CurrentRoom.SetCustomProperties(hash);
                PlayFabClientAPI.ExecuteCloudScript(new PlayFab.ClientModels.ExecuteCloudScriptRequest
                {
                    FunctionName = "RoomClosed",
                    FunctionParameter = new
                    {
                        GameId = PhotonNetwork.CurrentRoom.Name,
                        Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                        UserId = DADDYPINK.UserId,
                        ActorNr = DADDYPINK.ActorNumber,
                        ActorCount = PhotonNetwork.ViewCount,
                        AppVersion = PhotonNetwork.AppVersion
                    },
                }, result =>
                {
                }, null);
            }
        }
        public static void Spazsoda()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                {
                    SetMaster();
                }
            }
            else
            {
                ScienceExperimentManager controller = ScienceExperimentManager.instance;
                System.Type type = controller.GetType();

                FieldInfo fieldInfo = type.GetField("reliableState", BindingFlags.NonPublic | BindingFlags.Instance);

                object reliableState = fieldInfo.GetValue(controller);

                FieldInfo stateFieldInfo = reliableState.GetType().GetField("state");
                if (spazsodaType)
                {
                    stateFieldInfo.SetValue(reliableState, ScienceExperimentManager.RisingLiquidState.Full);
                }
                else
                {
                    stateFieldInfo.SetValue(reliableState, ScienceExperimentManager.RisingLiquidState.Drained);
                }
                spazsodaType = !spazsodaType;

                FieldInfo stateFieldInfo2 = reliableState.GetType().GetField("stateStartTime");
                stateFieldInfo2.SetValue(reliableState, PhotonNetwork.Time + UnityEngine.Random.Range(0f, -20f));

                fieldInfo.SetValue(controller, reliableState);
                SpazSpeed = 10;

            }
        }
        public static int SpazSpeed = 3;
        private static bool spazsodaType;

        public static void MatAll()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                {
                    SetMaster();
                }
            }
            else
            {
                if (Time.time > spamtagdelay)
                {
                    spamtagdelay = Time.time + 0f;
                    foreach (GorillaTagManager tagman in GameObject.FindObjectsOfType<GorillaTagManager>())
                    {
                        foreach (Photon.Realtime.Player v in PhotonNetwork.PlayerList)
                        {
                            if (tagman.currentInfected.Contains(v))
                            {
                                tagman.currentInfected.Remove(v);
                                tagman.currentInfected.Remove(v);
                                tagman.currentInfected.Remove(v);
                                tagman.currentInfected.Remove(v);
                            }
                            else
                            {
                                tagman.currentInfected.Add(v);
                                tagman.currentInfected.Add(v);
                                tagman.currentInfected.Add(v);
                                tagman.currentInfected.Add(v);
                            }
                        }
                    }
                }
            }
        }
        public static void AcidAll()
        {
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                if (!PhotonNetwork.IsMasterClient)
                {
                    {
                        OPStuff.SetMaster();
                    }
                }
                else
                {
                    Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerCount").SetValue(10);
                    ScienceExperimentManager.PlayerGameState[] states = new ScienceExperimentManager.PlayerGameState[10];
                    for (int i = 0; i < 10; i++)
                    {
                        states[i].touchedLiquid = true;
                        states[i].playerId = PhotonNetwork.PlayerList[i] == null ? 0 : PhotonNetwork.PlayerList[i].ActorNumber;
                    }
                    Traverse.Create(ScienceExperimentManager.instance).Field("inGamePlayerStates").SetValue(states);
                    Movement.RpcFlush();
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>ERROR</color><color=grey>]</color> <color=white>You are not master.</color>");
            }
        }
    }
}

    

