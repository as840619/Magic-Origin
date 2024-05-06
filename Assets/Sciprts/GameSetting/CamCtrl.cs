using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    [Header("基本數據")]
    [SerializeField] GameObject _idle;
    [SerializeField] float _offset;
    [SerializeField] float _offsetSmoothing;
    [SerializeField] Vector3 _cameraPosition;

    //public Transform target;
    void Start()
    {
        //_cameraPosition = new Vector3(6, 0.6882281f, -10f);
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        _cameraPosition = new Vector3(_idle.transform.position.x, _idle.transform.position.y, transform.position.z);

        if (CameraLimit(_cameraPosition.x, _cameraPosition.y))
        {
            if (_idle.transform.localScale.x > 0f)
            {
                if (CameraLimit(_cameraPosition.x + _offset, _cameraPosition.y))
                {
                    _cameraPosition = new Vector3(_cameraPosition.x + _offset, _cameraPosition.y, _cameraPosition.z);
                }
            }
            else
            {
                if (CameraLimit(_cameraPosition.x - _offset, _cameraPosition.y))
                {
                    _cameraPosition = new Vector3(_cameraPosition.x - _offset, _cameraPosition.y, _cameraPosition.z);
                }
            }
            transform.position = Vector3.Lerp(transform.position, _cameraPosition, _offsetSmoothing * Time.deltaTime);
        }
        if (LeftBorderReturn(_cameraPosition.x, _idle.transform.position.x))
        {
            transform.position = new Vector3(6f, _cameraPosition.y, _cameraPosition.z);
        }
        else if (RightBorderReturn(_cameraPosition.x, _idle.transform.position.x))
        {
            transform.position = new Vector3(52.5f, _cameraPosition.y, _cameraPosition.z);
        }
        else if (TopBorderReturn(_cameraPosition.y, _idle.transform.position.y))
        {
            transform.position = new Vector3(transform.position.x, 2.4f, _cameraPosition.z);
        }
        //else if (DeepBorderReturn)



    }

    bool CameraLimit(float x, float y)
    {
        if (x >= 6f || x <= 60f || y <= 2.4f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    bool LeftBorderReturn(float cx, float px)
    {
        if (cx < 6f && px > -2f)
        {
            return true;
        }
        return false;
    }
    bool RightBorderReturn(float cx, float px)
    {
        if (cx > 52.5f && px < 60f)
        {
            return true;
        }
        return false;
    }
    bool TopBorderReturn(float cy, float py)
    {
        if (cy > 2.4f && py < 6f)
        {
            return true;
        }
        return false;
    }
    bool DeepBorderReturn(float cy, float py)
    {
        if (cy > 2.4f && py < 6f)
        {
            return true;
        }
        return false;
    }

    public void SetPlayerPosition(GameObject playerobj)
    {
        _idle = playerobj;
    }
}
