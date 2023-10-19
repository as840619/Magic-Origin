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
        public List<Point> pointVectors = new List<Point>();
    }
}