using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float standartSize = 10;
   
    [SerializeField] private Transform _cameraBox;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;        
    }

    public void ChangeSizeCamera(float distance)
    {
        if (distance > 15)
        {
            _camera.orthographicSize = distance;
            _cameraBox.transform.position += new Vector3(0, distance/2, 0);          
        }
        else
        {
            ResetCamera();
        }
    }

    public void ResetCamera()
    {
        _camera.orthographicSize = standartSize;
        _cameraBox.transform.position = Vector3.zero;
    }
}
