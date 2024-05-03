using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSkillDetails : MonoBehaviour
{
    [System.Serializable]
    public struct Skills
    {
        public string name;
        public int damage;
        public bool addOrNot;
        public string addition;
    }
    public List<Skills> SkillList = new();
}
