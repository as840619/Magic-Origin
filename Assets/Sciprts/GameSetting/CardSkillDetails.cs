using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSkillDetails : MonoBehaviour
{
    [System.Serializable]
    public struct Skills
    {
        public int damage;
        public bool addOrNot;
        public string addition;
    }

    public List<Skills> Attack = new();
    public List<Skills> Slash = new();
    public List<Skills> Smash = new();
    public List<Skills> SplitSlash = new();
    public List<Skills> Spin = new();
    public List<Skills> QuickStab = new();
    public List<Skills> DashBlock = new();
    public List<Skills> GloryShield = new();
    public List<Skills> IronCastle = new();
    public List<Skills> Block = new();
}
