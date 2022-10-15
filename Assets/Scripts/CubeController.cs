using UnityEngine;

public class CubeController : MonoBehaviour
{
    private Vector3 _startPoint;

    private float _speed;
    private float _distance;

    private void Update()
    {        
        Movement();
    }

    public void InitCube(CubeModel cubeModel)
    {
        _speed = cubeModel.Speed;
        _distance = cubeModel.Distance;
    }

    private void Movement()
    {
        bool distanceOver = Vector3.Distance(_startPoint, transform.position) < _distance;

        if (distanceOver)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        else
        {           
            this.gameObject.SetActive(false);
        }        
    }

    private void ResetCube()
    {
        transform.position = Vector3.zero;
    }

    private void OnDisable()
    {
        ResetCube();
    }
}
