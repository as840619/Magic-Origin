using System.Collections.Generic;
using UnityEngine;

namespace RespawnPositions
{
    public class SavePoint : MonoBehaviour
    {
        [System.Serializable]
        public struct Point
        {
            public GameObject gameobj;
            public Transform ogjpositions;
        }
        [System.Serializable]
        public struct Saving
        {
            public Transform playerPositions;
        }
        public List<Point> pointVectors = new();
        public List<Saving> levelVectors = new();
    }
}