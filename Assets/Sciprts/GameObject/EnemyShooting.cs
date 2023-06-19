using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform _bulletPos;
    private GameObject _playerPos;
    private float _timer;
    void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, _playerPos.transform.position);
        Debug.Log(distance);
        if(distance < 10)//�g���d�� Shooting Range setup
        {
            _timer += Time.deltaTime;
            if (_timer > 2)
            {
                _timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet,_bulletPos.position,Quaternion.identity);
    }
}
