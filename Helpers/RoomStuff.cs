using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinkMenu.Helpers
{
    internal class RoomStuff
    {
        public static bool IsModded()
        {
            return PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED");
        }
        public static bool IsMaster()
        {
            return PhotonNetwork.InRoom && PhotonNetwork.LocalPlayer.IsMasterClient;
        }
    }
}
