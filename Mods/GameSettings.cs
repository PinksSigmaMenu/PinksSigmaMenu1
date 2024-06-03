using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PinkMenu.Mods
{
    internal class GameSettings
    {
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

        public static void DisableRain()
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



        public static void DisablePrefabsUnderPath(string parentPath = null)
        {
            GameObject rootObject = GameObject.Find(parentPath);
            if (rootObject == null)
            {
                Debug.LogError("CustomEnvironment: Root object not found. Please check the provided path: " + parentPath);
                return;
            }

            Transform[] groups = rootObject.GetComponentsInChildren<Transform>(true);
            foreach (Transform group in groups)
            {
                if (group.name.ToLower().Contains("group"))
                {
                    DisableAllPrefabs(group);
                }
            }
        }

        private static void DisableAllPrefabs(Transform group)
        {
            foreach (Transform child in group)
            {
                if (child.CompareTag("SmallTrees"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        public static void DisableCampfire(string parentPath = null)
        {
            GameObject rootObject = GameObject.Find(parentPath);
            if (rootObject == null)
            {
                Debug.LogError("CustomEnvironment: Root object not found. Please check the provided path: " + parentPath);
                return;
            }

            DisableCampfire(rootObject.transform);
        }

        private static void DisableCampfire(Transform parentTransform)
        {
            foreach (Transform child in parentTransform)
            {
                if (child.CompareTag("Campfire"))
                {
                    // Disable the campfire
                    child.gameObject.SetActive(false);
                }
                else
                {
                    DisableCampfire(child);
                }
            }
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


 



