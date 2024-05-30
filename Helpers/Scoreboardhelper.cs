using UnityEngine;

namespace PinkMenu.Helpers
{
    internal class ScoreboardHelper
    {

        public static void UpdateBoardColor()
        {
            Material pinkMaterial = new Material(Shader.Find("Standard"));
            pinkMaterial.color = SigmaColors.hotPink;

            bool hasFoundAllBoards = false;

            try
            {
                Debug.Log("Looking for boards");
                bool found1 = false;
                int index1 = 0;
                for (int i = 0; i < GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.childCount; i++)
                {
                    GameObject childObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.GetChild(i).gameObject;
                    if (childObject.name.Contains("forestatlas"))
                    {
                        index1++;
                        if (index1 == 1)
                        {
                            found1 = true;
                            childObject.GetComponent<Renderer>().material = pinkMaterial;
                        }
                    }
                }

                bool found2 = false;
                int index2 = 0;
                for (int i = 0; i < GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").transform.childCount; i++)
                {
                    GameObject childObject = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").transform.GetChild(i).gameObject;
                    if (childObject.name.Contains("forestatlas"))
                    {
                        index2++;
                        if (index2 == 8)
                        {
                            Debug.Log("Board found");
                            found2 = true;
                            childObject.GetComponent<Renderer>().material = pinkMaterial;
                        }
                    }
                }

                if (found1 && found2)
                {
                    string[] boards = new string[] {
                        "canyon",
                        "cosmetics",
                        "cave",
                        "forest",
                        "skyjungle"
                    };
                    foreach (string name in boards)
                    {
                        GameObject board = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitor" + name);
                        if (board != null)
                        {
                            board.GetComponent<Renderer>().material = pinkMaterial;
                            try
                            {
                                GorillaLevelScreen levelScreen = board.GetComponent<GorillaLevelScreen>();
                                if (levelScreen != null)
                                {
                                    levelScreen.goodMaterial = pinkMaterial;
                                    levelScreen.badMaterial = pinkMaterial;
                                }
                            }
                            catch { }
                        }
                    }
                    hasFoundAllBoards = true;
                    Debug.Log("Found all boards");
                }
            }
            catch (System.Exception exception)
            {
                Debug.LogError($"PinkMenu <b>COLOR ERROR</b>: {exception.Message}\n{exception.StackTrace}");
                hasFoundAllBoards = false;
            }

            try
            {
                GameObject computerMonitor = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen");
                if (computerMonitor != null)
                {
                    computerMonitor.GetComponent<Renderer>().material = pinkMaterial;
                }
            }
            catch { }

            try
            {
                if (!disableBoardColor)
                {
                    pinkMaterial.color = GetBGColor(0f);
                }
                else
                {
                    pinkMaterial.color = new Color32(0, 53, 2, 255);
                }
            }
            catch { }
        }

        private static Color GetBGColor(float value)
        {
            return Color.white;
        }
    }
}
