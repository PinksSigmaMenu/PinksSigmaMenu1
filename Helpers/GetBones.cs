using UnityEngine;

namespace PinkMenu.Helpers
{
    internal class GetBones
    {
        public static int[] GetBoneIndices()
        {
            int[] boneIndices = new int[32];
            for (int i = 0; i < 32; i++)
            {
                boneIndices[i] = i;
            }
            return boneIndices;
        }
    }
}
