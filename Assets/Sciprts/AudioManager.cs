using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//參考:https://www.youtube.com/watch?v=0XI-JLcwhR8
public class AudioManager : MonoBehaviour
{
    public AudioClip bgmcity;
    public AudioClip bgmforest;
    public AudioClip sePlayerATK;
    public AudioClip sePlayerATK2;
    public AudioClip sePlayerWalk;
    public AudioClip sePlayerShield;
    public AudioClip seEnemyShoot;
    public AudioClip seEnemyDeath;
    public AudioClip seEnemyBoss;
    List<AudioSource> audios = new List<AudioSource>();

    private void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            var audio = this.gameObject.AddComponent<AudioSource>();//宣告變數存取Audio
            audios.Add(audio);
        }
    }
    void Start()
    {

    }

  public  void Play(int index, string name, bool isLoop)
    {
        var clip = GetAudioClip(name);
        if(clip != null)
        {
            var audio = audios[index];
            audios[index].clip = clip;
            audios[index].loop = isLoop;
            audio.Play();
        }
    }
    AudioClip GetAudioClip(string name)
    {
        switch (name)
        {
            case "bgmcity":
                return bgmcity;
            case "bgmforest":
                return bgmforest;
            case "sePlayerATK":
                return sePlayerATK;
            case "sePlayerATK2":
                return sePlayerATK2;
            case "sePlayerWalk":
                return sePlayerWalk;
            case "sePlayerShield":
                return sePlayerShield;
            case "seEnemyShoot":
                return seEnemyShoot;
            case "seEnemyDeath":
                return seEnemyDeath;
            case "seEnemyBoss":
                return seEnemyBoss;
        }
        return null;
    }
}
