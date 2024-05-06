using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Play(int index, string name, bool isLoop)
    {
        var clip = GetAudioClip(name);
        if (clip != null)
        {
            var audio = audios[index];
            audios[index].clip = clip;
            audios[index].loop = isLoop;
            audio.Play();
        }
    }

    AudioClip GetAudioClip(string name)
    {
        return name switch
        {
            "bgmcity" => bgmcity,
            "bgmforest" => bgmforest,
            "sePlayerATK" => sePlayerATK,
            "sePlayerATK2" => sePlayerATK2,
            "sePlayerWalk" => sePlayerWalk,
            "sePlayerShield" => sePlayerShield,
            "seEnemyShoot" => seEnemyShoot,
            "seEnemyDeath" => seEnemyDeath,
            "seEnemyBoss" => seEnemyBoss,
            _ => null,
        };
    }
}