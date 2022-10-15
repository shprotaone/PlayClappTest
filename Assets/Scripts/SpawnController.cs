using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    private const string spawnName = "SPAWN";
    private const string stopName = "STOP";  

    [SerializeField] private InputController _inputController;
    [SerializeField] private CameraController _camController;
    [SerializeField] private CubePool _cubePool;

    [SerializeField] private Button _spawnButton;
    [SerializeField] private TMP_Text _spawnButtonText;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    
    private bool _isSpawning;

    private void Start()
    {
        _spawnButton.onClick.AddListener(SpawnToggle);
        _cubePool.CubePoolSetUp(_cubePrefab, 20, _spawnPoint);
    }

    private void SpawnToggle()
    {
        _camController.ResetCamera();
        StopAllCoroutines();

        if (_isSpawning)
        {
            StopSpawning();  
        }         
        else
        {
            if (_inputController.IsFilled)
            {
                _isSpawning = true;
                _spawnButtonText.text = stopName;
                StartCoroutine(Spawn());
            }
        }       
    }

    private IEnumerator Spawn()
    {
        float delay = _inputController.Delay;
        float speed = _inputController.Speed;
        float distance = _inputController.Distance;
            
        _camController.ChangeSizeCamera(distance);

        CubeModel cubeModel = new CubeModel(speed,distance);
        
        while (_isSpawning)
        {
            GameObject cube = _cubePool.GetCube();
            cube.GetComponent<CubeController>().InitCube(cubeModel);

            yield return new WaitForSeconds(delay);
        }

        yield break;
    }

    private void StopSpawning()
    {
        _isSpawning = false;
        _spawnButtonText.text = spawnName;

        foreach (var cube in _cubePool.Pool)
        {
            cube.SetActive(false);
        }
    }
}   
