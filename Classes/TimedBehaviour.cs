using PinkMenu.Managers;
using UnityEngine;

namespace PinkMenu.Helpers
{
    internal class ScoreboardHelper
    {
        public static bool disableBoardColor = false;

        public static void UpdateBoardColor(Material pinkMaterial)
        {
            bool hasFoundAllBoards = false;

            try
            {
                Debug.Log("Looking for boards");

                GameObject treeRoom = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom");
                if (treeRoom != null)
                {
                    SearchAndChangeBoardColor(treeRoom, pinkMaterial);
                }

                // Search for boards in the Forest
                GameObject forest = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest");
                if (forest != null)
                {
                    SearchAndChangeBoardColor(forest, pinkMaterial);
                }

                hasFoundAllBoards = true;
                Debug.Log("Found all boards");
            }
            catch (System.Exception exception)
            {
                Debug.LogError($"PinkMenu <b>COLOR ERROR</b>: {exception.Message}\n{exception.StackTrace}");
                hasFoundAllBoards = false;
            }

            try
            {
                if (!disableBoardColor)
                {
                    pinkMaterial.color = ThemeManager.GetSolidGradient(true);
                }
                else
                {
                    pinkMaterial.color = new Color32(0, 53, 2, 255);
                }
            }
            catch { }
        }

        private static void SearchAndChangeBoardColor(GameObject parentObject, Material pinkMaterial)
        {
            foreach (Transform child in parentObject.transform)
            {
                if (child.name.Contains("forestatlas"))
                {
                    Renderer renderer = child.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        Material[] materials = renderer.materials;
                        for (int i = 0; i < materials.Length; i++)
                        {
                            materials[i] = pinkMaterial;
                        }
                        renderer.materials = materials;
                    }
                    try
                    {
                        GorillaLevelScreen levelScreen = child.GetComponent<GorillaLevelScreen>();
                        if (levelScreen != null)
                        {
                            levelScreen.goodMaterial = pinkMaterial;
                            levelScreen.badMaterial = pinkMaterial;
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
