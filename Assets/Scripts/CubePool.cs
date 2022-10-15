using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private bool AutoExpand;
    [SerializeField] private Transform _container;
    
    private GameObject _cubePrefab;
    
    private List<GameObject> _pool;

    public List<GameObject> Pool => _pool;

    public void CubePoolSetUp(GameObject prefab, float count, Transform container)
    {
        _cubePrefab = prefab;
        _container = container;
        CreatePool(count);
    }

    private void CreatePool(float count)
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            CreateCube();
        }
    }

    public bool HasFreeElement(out GameObject cube)
    {
        foreach (var currentCube in _pool)
        {
            if (!currentCube.activeInHierarchy)
            {
                cube = currentCube;
                cube.SetActive(true);
                return true;
            }
        }

        cube = null;
        return false;
    }

    private GameObject CreateCube(bool isActiveDefault = false)
    {
        var createCube = Instantiate(_cubePrefab, _container);
        createCube.SetActive(isActiveDefault);

        _pool.Add(createCube);
        return createCube;

    }

    public GameObject GetCube()
    {
        if(HasFreeElement(out GameObject cube))
        {
            return cube;
        }

        if (AutoExpand)
        {
            return CreateCube(true);
        }

        throw new System.Exception("Нет свободных элементов");
    }
}
