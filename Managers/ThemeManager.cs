using PinkMenu.Classes;
using PinkMenu.Helpers;
using PinkMenu.Menu;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;

namespace PinkMenu.Managers

{

    public static class ThemeManager
    {
        private static int CurrentTheme = 0;
        private static Theme[] Themes = {
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(SigmaColors.deepPink, 0f),
                new GradientColorKey(SigmaColors.hotPink, 0.5f),
                new GradientColorKey(SigmaColors.deepPink, 1f)
            }
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.hotPink)
        }
    },
    TextColors = new Color[] {
        ThemesColors.white,
        Color.green
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.hotPink) // Disabled
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.deepPink) // Enabled
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.deepPink)
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.hotPink)
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.orange)
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.darkOrange)
        }
    },
    TextColors = new Color[] {
        Color.blue,
        Color.red
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(Color.red) // Disabled
        },
        new ExtGradient {
            colors = GetSolidGradient(Color.blue) // Enabled
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.orange)
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.darkOrange)
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.midnightBlue)
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.darkBlue)
        }
    },
    TextColors = new Color[] {
        ThemesColors.white,
        ThemesColors.white
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.darkpurple)
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.purple)
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.midnightBlue)
        },
        new ExtGradient {
            colors = GetSolidGradient(SigmaColors.darkBlue)
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.orange)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.orange2)
        }
    },
    TextColors = new Color[] {
        ThemesColors.white,
        ThemesColors.white
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.ButtonColor)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.ButtonColor2)
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.orange)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.orange2)
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.grey)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.darkGrey)
        }
    },
    TextColors = new Color[] {
        ThemesColors.white,
        ThemesColors.white
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.ButtonColorGrey)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.ButtonColorDarkGrey)
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.grey)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.darkGrey)
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.neonPink)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.electricBlue)
        }
    },
    TextColors = new Color[] {
        ThemesColors.white,
        ThemesColors.white
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.neonGreen)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.electricBlue)
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.neonPink)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.electricBlue)
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.deepGreen)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.lightGreen)
        }
    },
    TextColors = new Color[] {
        ThemesColors.white,
        ThemesColors.white
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.brown)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.deepGreen)
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.deepGreen)
        },
        new ExtGradient {
            colors = GetSolidGradient(ThemesColors.lightGreen)
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.945f, 0.769f, 0.059f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.118f, 0.565f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(0.0f, 0.0f, 0.545f),
        new Color(0.0f, 0.0f, 0.545f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 1.0f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.945f, 0.769f, 0.059f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.945f, 0.769f, 0.059f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.118f, 0.565f, 1.0f))
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 0.847f, 0.902f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 1.0f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(0.0f, 0.0f, 0.545f),
        new Color(0.0f, 0.0f, 0.545f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 0.847f, 0.902f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.0f, 0.545f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 0.847f, 0.902f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 1.0f, 1.0f))
        }
    }
},
new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(1.0f, 0.0f, 1.0f), 0f),
                new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 0.5f),
                new GradientColorKey(new Color(1.0f, 0.0f, 1.0f), 1f),
            }
        },
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 0f),
                new GradientColorKey(new Color(1.0f, 0.0f, 1.0f), 0.5f),
                new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 1f)
            }
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(1.0f, 1.0f, 1.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(0.0f, 0.0f, 0.0f), 0f),
                new GradientColorKey(new Color(0.0f, 0.0f, 0.0f), 1f)
            }
        },
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(0.0f, 0.0f, 0.0f), 0f),
                new GradientColorKey(new Color(0.0f, 0.0f, 0.0f), 1f)
            }
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(1.0f, 0.0f, 1.0f), 0f),
                new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 1f)
            }
        },
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(0.0f, 1.0f, 1.0f), 0f),
                new GradientColorKey(new Color(0.0f, 0.0f, 1.0f), 1f)
            }
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(0.678f, 1.0f, 0.847f), 0f),
                new GradientColorKey(new Color(0.678f, 1.0f, 0.933f), 1f)
            }
        },
        new ExtGradient {
            colors = new GradientColorKey[] {
                new GradientColorKey(new Color(0.678f, 1.0f, 0.933f), 0f),
                new GradientColorKey(new Color(0.678f, 1.0f, 0.847f), 1f)
            }
        }
    },
    TextColors = new Color[] {
        new Color(0.0f, 0.0f, 0.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 1.0f, 0.847f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.4f, 0.8f, 0.6f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 1.0f, 0.847f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 1.0f, 0.933f))
        }
    }
},


new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.5f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.0f, 0.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.0f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.5f, 0.0f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.5f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.0f, 0.0f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.0f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.0f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 1.0f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.0f, 1.0f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.502f, 0.0f, 0.502f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.502f, 0.0f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.502f, 0.0f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.502f, 0.0f, 0.502f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.502f, 0.0f, 0.502f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.502f, 0.0f, 1.0f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.5f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.5f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.0f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.5f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 1.0f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.843f, 0.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.843f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 1.0f, 0.0f))
        }
    },
    BoardColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 1.0f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.843f, 0.0f))
        }
    }
}


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
        internal ExtGradient[] BoardColors;

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

        public ExtGradient GetBoard(bool enabled)
        {
            if (enabled)
            {
                return BoardColors[1];
            }

            return BoardColors[0];
        }
    }
}