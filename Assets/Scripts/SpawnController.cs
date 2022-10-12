using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    private const string spawnName = "SPAWN";
    private const string stopName = "STOP";

    [SerializeField] private Button _spawnButton;
    [SerializeField] private TMP_Text _spawnButtonText;

    [SerializeField] private TMP_InputField _distanceInput;
    [SerializeField] private TMP_InputField _speedInput;
    [SerializeField] private TMP_InputField _delayInstance;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _spawnPoint;
    
    private bool _isSpawning;

    private void Start()
    {
        _spawnButton.onClick.AddListener(SpawnToggle);
    }

    private void SpawnToggle()
    {
        if (_isSpawning)
        {
            _isSpawning = false;
            _spawnButtonText.text = spawnName;
            StopCoroutine(Spawn());           
        } 
        
        else
        {
            _isSpawning = true;
            _spawnButtonText.text = stopName;
            StartCoroutine(Spawn());
        }       
    }

    private IEnumerator Spawn()
    {
        float delay = (float.Parse(_delayInstance.text));
        CubeModel cubeModel = new CubeModel(float.Parse(_speedInput.text), float.Parse(_distanceInput.text));
        

        while (_isSpawning)
        {            
            GameObject cube = Instantiate(_cubePrefab,_spawnPoint);
            
            cube.GetComponent<CubeController>().InitCube(cubeModel);
            yield return new WaitForSeconds(delay);
        }

        yield break;
    }
}   
