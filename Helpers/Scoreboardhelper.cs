using PinkMenu.Classes;
using PinkMenu.Managers;
using UnityEngine;

namespace PinkMenu.Helpers
{
    internal class ScoreboardHelper
    {
        public static bool disableBoardColor = false;

        public static void UpdateBoardColor(Theme theme = null)
        {
            if (theme == null)
            {
                theme = ThemeManager.GetTheme();
            }

            ExtGradient boardGradient = theme.GetBoard(true);
            Material pinkMaterial = new Material(Shader.Find("GorillaTag/UberShader"))
            {
                color = boardGradient.colors[0].color 
            };

            bool hasFoundAllBoards = false;

            try
            {
                Debug.Log("Looking for boards");
                bool found1 = false;
                int index1 = 0;
                Transform treeRoomTransform = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform;

                for (int i = 0; i < treeRoomTransform.childCount; i++)
                {
                    GameObject childObject = treeRoomTransform.GetChild(i).gameObject;
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
                Transform forestTransform = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").transform;

                for (int i = 0; i < forestTransform.childCount; i++)
                {
                    GameObject childObject = forestTransform.GetChild(i).gameObject;
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
                        GameObject board = GameObject.Find($"Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitor{name}");
                        if (board)
                        {
                            board.GetComponent<Renderer>().material = pinkMaterial;
                            try
                            {
                                GorillaLevelScreen levelScreen = board.GetComponent<GorillaLevelScreen>();
                                if (levelScreen)
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
                if (computerMonitor)
                {
                    computerMonitor.GetComponent<Renderer>().material = pinkMaterial;
                }
            }
            catch { }

            try
            {
                if (!disableBoardColor)
                {
                    pinkMaterial.color = GetBGColor(boardGradient);
                }
                else
                {
                    pinkMaterial.color = new Color32(0, 53, 2, 255);
                }
            }
            catch { }
        }

        private static Color GetBGColor(ExtGradient boardGradient)
        {
            return boardGradient.colors[0].color;
        }
    }
}

//MOST CREDITS GOTO IIDK FOR MAKING THIS 
//SOME GOTO ME FOR BUSTING MY ASS TRYING TO MAKE THIS WORK
