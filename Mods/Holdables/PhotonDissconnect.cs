using Photon.Pun;
using System;
using System.Reflection;

namespace AdvancedPhotonNetwork
{
    internal static class ExpertPhotonNetwork
    {
        public static void DisconnectPhotonNetwork()
        {
            Type photonNetworkType = typeof(PhotonNetwork);
            string methodName = "Disconnect";

            MethodInfo disconnectMethod = photonNetworkType.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            if (disconnectMethod != null)
            {
                object photonNetworkInstance = null; 

                disconnectMethod.Invoke(photonNetworkInstance, null);

            }
            else
            {
                throw new MissingMethodException($"Method '{methodName}' not found in type '{photonNetworkType.FullName}'.");
            }
        }
    }
}
