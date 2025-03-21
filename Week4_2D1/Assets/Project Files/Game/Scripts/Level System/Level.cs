using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watermelon.JellyMerge
{
    [CreateAssetMenu(fileName = "Level", menuName = "Data/Level System/Level")]
    [System.Serializable]
    public class Level : ScriptableObject
    {
        [LevelEditorSetting] public Vector2Int size;

        [LevelEditorSetting] public IntArray[] items;

        [System.Serializable]
        public struct IntArray
        {
            public int[] ints;

            public IntArray(int[] list)
            {
                ints = list;
            }
        }

    }
}