using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using RespawnPositions;

public class GameManager : MonoBehaviour
{
    int playerLevel = 0;
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
    List<SavePoint.Saving> savings;


    public GameObject audioManagerPrefab;
    public AudioManager audioManager;
    void Start()
    {
        _cameraobj = GameObject.FindWithTag("MainCamera");
        _camCtrl = _cameraobj.GetComponent<CamCtrl>();
        points = GetComponent<SavePoint>().pointVectors;
        savings = GetComponent<SavePoint>().levelVectors;

        audioManager = Instantiate(audioManagerPrefab).GetComponent<AudioManager>();
        ResetObject();
    }

    public void ResetObject()
    {
        playerLevel = 0;
        TagCatcher("Enemy");
        TagCatcher("Bullet");
        Destroy(GameObject.FindWithTag("Player"));
        foreach (SavePoint.Point container in points)
        {
            GameObject Zo = Instantiate(container.gameobj, container.ogjpositions.position, Quaternion.identity);
            if (Zo.CompareTag("Player"))
            {
                Zo.name = "Player";
                _camCtrl.SetPlayerPosition(Zo);
                PlayerManager.Instance.nowHealth = PlayerManager.Instance.maxHealth;
                PlayerManager.Instance.UpdateHealth();
            }
        }
    }

    void TagCatcher(string tag)
    {
        foreach (GameObject temp in GameObject.FindGameObjectsWithTag(tag))
            Destroy(temp);
    }

    public Vector3 NextLevel()
    {
        playerLevel++;
        print("進入第" + playerLevel + 1 + "關");
        return savings[playerLevel].playerPositions.position;
    }

    public Vector3 ReturnLevel()
    {
        return savings[playerLevel].playerPositions.position;
    }
}