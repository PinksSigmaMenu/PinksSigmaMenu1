using PinkMenu.Classes;
using PinkMenu.Helpers;
using PinkMenu.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PinkMenu.Managers

{
    public class ThemeManager
    {
        private static int CurrentTheme = 0;
        private static Theme[] Themes = {
            new Theme{
                MenuColors = new ExtGradient[]
                {
                    new ExtGradient{colors = new GradientColorKey[] {
                        new GradientColorKey(SigmaColors.deepPink, 0f),
                        new GradientColorKey(SigmaColors.hotPink, 0.5f),
                        new GradientColorKey(SigmaColors.deepPink, 1f)
                    }},

                    new ExtGradient{colors = GetSolidGradient(allshadesofpink.mediumPink)}

                },
                TextColors = new Color[]
                {
                    Color.white,
                    Color.green,
                },
                ButtonColors = new ExtGradient[]
                {
                    new ExtGradient{colors = GetSolidGradient(SigmaColors.hotPink)}, // Disabled
                    new ExtGradient{colors = GetSolidGradient(SigmaColors.deepPink)} // Enabled
                }

            },
            new Theme{
                MenuColors = new ExtGradient[]
                {
                    new ExtGradient{colors = GetSolidGradient(SigmaColors.orange)},
                    new ExtGradient{colors = GetSolidGradient(SigmaColors.darkOrange)}

                },
                TextColors = new Color[]
                {
                    Color.blue,
                    Color.red,
                },
                ButtonColors = new ExtGradient[]
                {
                    new ExtGradient{colors = GetSolidGradient(Color.red)}, // Disabled
                    new ExtGradient{colors = GetSolidGradient(Color.blue)} // Enabled
                }

            },
        };

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }

        public static int GetThemeIndex()
        {
            return CurrentTheme;
        }
        public static void NextTheme(string buttonText = "")
        {
            if ((Themes.Length - 1) <= CurrentTheme)
            {
                CurrentTheme = 0;
            }
            else
            {
                CurrentTheme++;
            }
            if (buttonText != "")
            {
                ButtonInfo Button = Main.GetIndex(buttonText);
                Button.overlapText = Button.buttonText + CurrentTheme;
            }
        }
        public static void LastTheme(string buttonText = "")
        {
            if (0 >= CurrentTheme)
            {
                CurrentTheme = (Themes.Length - 1);
            }
            else
            {
                CurrentTheme--;
            }

            if (buttonText != "")
            {
                ButtonInfo Button = Main.GetIndex(buttonText);
                Button.overlapText = Button.buttonText + CurrentTheme;
            }
        }
        public static Theme GetTheme()
        {
            return Themes[CurrentTheme];
        }
    }
    public class Theme
    {
        internal ExtGradient[] MenuColors;
        internal Color[] TextColors;
        internal ExtGradient[] ButtonColors;

    public ExtGradient GetBackground()
        {
            return MenuColors[0];
        }
        public ExtGradient GetOutline()
        {
            return MenuColors[1];
        }
        public Color GetText(bool enabled)
        {
            if (enabled)
            {
                return TextColors[1];
            }

            return TextColors[0];
        }
        public ExtGradient GetButton(bool enabled)
        {
            if (enabled)
            {
                return ButtonColors[1];
            }

            return ButtonColors[0];
        }
    }
}
