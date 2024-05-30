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
                        colors = GetSolidGradient(SigmaColors.darkpurple) // Disabled
                    },
                    new ExtGradient {
                        colors = GetSolidGradient(SigmaColors.purple) // Enabled
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
                        colors = GetSolidGradient(SigmaColors.purple) // Enabled
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
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.679f, 0.867f, 0.902f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.678f, 0.678f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 0.0f, 1.0f),
        new Color(1.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.753f, 0.796f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.0f, 0.0f))
        }
    }
    //theme suggested by "Simply Meepo ✞"
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.749f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.498f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.498f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.0f, 1.0f))
        }
    }
 },

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.843f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.647f, 0.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.647f, 0.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.843f, 0.0f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.498f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.749f, 0.498f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.749f, 0.498f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.498f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.686f, 0.686f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.878f, 0.686f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.878f, 0.686f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.949f, 0.686f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.478f, 0.0f, 0.921f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.819f, 1.0f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 0.819f, 1.0f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(0.0f, 1.0f, 0.439f))
        }
    }
},

new Theme {
    MenuColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.686f, 0.478f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.819f, 0.478f))
        }
    },
    TextColors = new Color[] {
        new Color(1.0f, 1.0f, 1.0f),
        new Color(0.0f, 0.0f, 0.0f)
    },
    ButtonColors = new ExtGradient[] {
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.819f, 0.478f))
        },
        new ExtGradient {
            colors = GetSolidGradient(new Color(1.0f, 0.905f, 0.478f))
        }
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
