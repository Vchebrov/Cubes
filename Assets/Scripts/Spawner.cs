using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CubeInteractor))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeInfo _prefab;

    private List<Rigidbody> _cubesToBeExploded = new();   

    private float _verticalMax = 3f;
    private float _horizontalMax = 9f;
    private float _verticalMin = 1f;
    private float _horizontalMin = 1f;
    private float _hueMin = 0f;
    private float _hueMax = 1f;
    private float _saturationMin = 0.6f;
    private float _saturationMax = 1f;
    private float _valueMin = 0.6f;
    private float _valueMax = 1f;

    private int _minCubeNumber = 2;
    private int _maxCubeNumber = 6;
    private int _scaleModificator = 2;   

    public List<Rigidbody>  CreateCubesBodies(CubeInfo cubeInfo)
    {
        _cubesToBeExploded.Clear();

        int cubeCount = Random.Range(_minCubeNumber, _maxCubeNumber + 1);

        var objScale = cubeInfo.transform.localScale;

        for (int i = 0; i < cubeCount; i++)
        {
            CubeInfo newCube = Instantiate(cubeInfo, InitiateCubePosition(), Quaternion.identity);

            newCube.transform.localScale = objScale / _scaleModificator;   
            newCube.RecalculateExplosionModificators();            

            if (newCube.TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV(
                    _hueMin, _hueMax,
                    _saturationMin, _saturationMax,
                    _valueMin, _valueMax
                );                
            }
            else
            {
                Debug.LogWarning($"{newCube.name}: Renderer не найден, цвет не изменён.");
            }

            _cubesToBeExploded.Add(newCube.Body);
        }

        return _cubesToBeExploded;
    }

    private Vector3 InitiateCubePosition()
    {
        float x = Random.Range(_horizontalMin, _horizontalMax);
        float y = Random.Range(_verticalMin, _verticalMax);
        float z = Random.Range(_horizontalMin, _horizontalMax);

        return new Vector3(x, y, z);
    }
}
