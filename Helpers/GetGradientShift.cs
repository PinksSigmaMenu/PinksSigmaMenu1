using UnityEngine;

namespace PinkMenu.Helpers
{
    internal static class ThemeHelper
    {
        public static Color[] GetGradientShift(Color startColor, Color endColor, float step)
        {
            int count = 10;
            Color[] colors = new Color[count];
            for (int i = 0; i < count; i++)
            {
                float t = Mathf.PingPong(i * step, 1f);
                colors[i] = Color.Lerp(startColor, endColor, t);
            }
            return colors;
        }
    }
}
