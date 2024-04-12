using PinkMenu.Helpers;
using System;
using UnityEngine;

namespace StupidTemplate.Classes
{
    public class ExtGradient
    {
        public GradientColorKey[] colors = new GradientColorKey[]
        {
            new GradientColorKey(SigmaColors.deepPink, 0f),
            new GradientColorKey(SigmaColors.lightPink, 0.5f),
            new GradientColorKey(SigmaColors.deepPink, 1f)
        };

        public bool isRainbow = false;
        public bool copyRigColors = false;
    }
}
