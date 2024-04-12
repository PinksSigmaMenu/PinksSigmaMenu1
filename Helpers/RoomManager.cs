using ExitGames.Client.Photon;
using HarmonyLib;
using Oculus.Platform;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StupidTemplate.Helpers
{

    public class RoomManager
    {
        public static int CurrentRoomState = 0;
        public static int CurrentGamemode = 0;
        //public static Action<Photon.Realtime.Player>[] OnPlayerJoinedEvent = new Action<Photon.Realtime.Player>[] { };
        //public static Action<Photon.Realtime.Player>[] OnPlayerLeftEvent = new Action<Photon.Realtime.Player>[] { };
        public static Dictionary<int, Action<Photon.Realtime.Player>> OnPlayerJoinedEvent = new Dictionary<int, Action<Photon.Realtime.Player>>();
        public static Dictionary<int, Action<Photon.Realtime.Player>> OnPlayerLeftEvent = new Dictionary<int, Action<Photon.Realtime.Player>>();

        public enum RoomState : int
        {
            Pending = 0,
            Disconnected = 1,
            Connected = 2
        }
        public enum Gamemode : int
        {
            None = 0,
            Casual = 1,
            Hunt = 2,
            Paintbrawl = 3,
            Infection = 4
        }
        public static void FindGamemode(Photon.Realtime.Room CurrentRoom)
        {
            object GameModeValue = CurrentRoom.CustomProperties["gameMode"];

            if (GameModeValue != null)
            {
                string gameMode = GameModeValue.ToString();
                if (gameMode.Contains("CASUAL"))
                    CurrentGamemode = (int)Gamemode.Casual;
                else if (gameMode.Contains("INFECTION"))
                    CurrentGamemode = (int)Gamemode.Infection;
                else if (gameMode.Contains("HUNT"))
                    CurrentGamemode = (int)Gamemode.Hunt;
                else if (gameMode.Contains("BATTLE"))
                    CurrentGamemode = (int)Gamemode.Paintbrawl;
            }
        }

    }
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    internal class JoinEventHook : MonoBehaviour
    {
        private static Photon.Realtime.Player LastPlayer;
        private static void Prefix(Photon.Realtime.Player newPlayer)
        {
            if (newPlayer != LastPlayer)
            {
                LastPlayer = newPlayer;
                for (int i = 0; i < RoomManager.OnPlayerJoinedEvent.Count; i++)
                {

                    if (RoomManager.OnPlayerJoinedEvent.TryGetValue(i, out Action<Photon.Realtime.Player> ToCall))
                    {
                        ToCall.Invoke(newPlayer);
                    }
                }
            }
        }
    }
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    internal class LeaveEventHook : MonoBehaviour
    {
        private static Photon.Realtime.Player LastPlayer;
        private static void Prefix(Photon.Realtime.Player otherPlayer)
        {
            if (otherPlayer != LastPlayer)
            {
                LastPlayer = otherPlayer;
                for (int i = 0; i < RoomManager.OnPlayerLeftEvent.Count; i++)
                {

                    if (RoomManager.OnPlayerLeftEvent.TryGetValue(i, out Action<Photon.Realtime.Player> ToCall))
                    {
                        ToCall.Invoke(otherPlayer);
                    }
                }
            }
        }
    }


    [HarmonyPatch(typeof(GorillaNetworking.PhotonNetworkController))]
    [HarmonyPatch("OnJoinedRoom", MethodType.Normal)]
    public class JoinedRoom
    {
        public static void Postfix()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                RoomManager.FindGamemode(PhotonNetwork.CurrentRoom);
                RoomManager.CurrentRoomState = (int)RoomManager.RoomState.Connected;
            }

        }
    }

    [HarmonyPatch(typeof(GorillaNetworking.PhotonNetworkController))]
    [HarmonyPatch("OnDisconnected", MethodType.Normal)]
    public class LeftRoom
    {
        public static void Postfix()
        {
            if (PhotonNetwork.CurrentRoom == null)
            {
                RoomManager.CurrentGamemode = (int)RoomManager.Gamemode.None;
                RoomManager.CurrentRoomState = (int)RoomManager.RoomState.Disconnected;
            }
            else
            {
                RoomManager.CurrentRoomState = (int)RoomManager.RoomState.Pending;
            }
        }
    }
}
