using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using RespawnPositions;


public class GameManager : MonoBehaviour
{
    GameObject _cameraobj;
    CamCtrl _camCtrl;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            return instance;
        }
    }
    List<SavePoint.Point> points;

    /*[Header("")]
    public static int enemyInfectorFarHP;
    public static int enemyInfectorNearHP;
    public static int enemyInfectorBossHP;
    public static int enemyHP;
    [Header("")]
    [SerializeField] Text _enemyInfectorFarHPText;
    [SerializeField] Text _enemyInfectorNearHPText;
    [SerializeField] Text _enemyInfectorBossHPText;*/

    void Start()
    {
        _cameraobj = GameObject.FindWithTag("MainCamera");
        _camCtrl = _cameraobj.GetComponent<CamCtrl>();
        points = GetComponent<SavePoint>().pointVectors;
    }

    public void ResetObject()
    {
        TagCatcher("Enemy");
        TagCatcher("Bullet");
        Destroy(GameObject.FindWithTag("Player"));
        foreach (SavePoint.Point container in points)
        {
            GameObject Zo = Instantiate(
                container.gameobj, container.ogjpositions.position, Quaternion.identity);
            if (Zo.CompareTag("Player"))
            {
                Zo.name = "Player";
                _camCtrl.SetPlayerPosition(Zo);
            }
        }
    }

    void TagCatcher(string tag)
    {
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag(tag))
        {
            Destroy(temp);
        }
    }

}
