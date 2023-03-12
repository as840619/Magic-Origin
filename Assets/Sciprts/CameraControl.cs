using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] GameObject _idle;
    [SerializeField] float _offset;
    [SerializeField] float _offsetSmoothing;
    [SerializeField] Vector3 _cameraPosition;

    public Transform target;
    void Start()
    {
        _cameraPosition = new Vector3(4, 0.6882281f, -10f);
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        _cameraPosition = new Vector3(_idle.transform.position.x, _idle.transform.position.y + 2, transform.position.z);
        if (_idle.transform.localScale.x > 0f)
        {
            _cameraPosition = new Vector3(_cameraPosition.x + _offset, _cameraPosition.y, _cameraPosition.z);
        }
        else
        {
            _cameraPosition = new Vector3(_cameraPosition.x - _offset, _cameraPosition.y, _cameraPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, _cameraPosition, _offsetSmoothing * Time.deltaTime);
    }
}
