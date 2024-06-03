using UnityEngine;

namespace PinkMenu.Helpers
{
    internal static class GetBGColors
    {
        public static Color GetBackgroundColor(float alpha)
        {
            return new Color(0.5f, 0.5f, 0.5f, alpha);
        }
    }
}
