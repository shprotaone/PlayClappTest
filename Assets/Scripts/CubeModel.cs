using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeModel
{
    private float _speed;
    private float _distance;

    public float Speed => _speed;
    public float Distance => _distance;

    public CubeModel(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
    }
}
