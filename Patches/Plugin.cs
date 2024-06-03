using BepInEx;
using HarmonyLib;
using PinkMenu.Menu;
using System.ComponentModel;
using System.Reflection;

namespace PinkMenu.Patches
{
    [Description(PinkMenu.PluginInfo.Description)]
    [BepInPlugin(PinkMenu.PluginInfo.GUID, PinkMenu.PluginInfo.Name, PinkMenu.PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        public static bool IsPatched { get; private set; }
        private static Harmony instance;

        private void OnEnable()
        {
            if (!IsPatched)
            {
                if (instance == null)
                {
                    instance = new Harmony(PinkMenu.PluginInfo.GUID);
                }
                instance.PatchAll(Assembly.GetExecutingAssembly());
                IsPatched = true;
            }
        }
        void OnGUI()
        {
            if (IsPatched)
            {
                Menu.UI.DrawGUI();
            }
        }

        private void OnDisable()
        {
            if (instance != null && IsPatched)
            {
                IsPatched = false;
            }
        }
    }
}
