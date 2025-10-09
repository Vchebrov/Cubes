using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(InteractionController))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeInfo _prefab;

    private List<Rigidbody> _cubesToBeExploded = new();

    private float _verticalMax = 3f;
    private float _horizontalMax = 9f;
    private float _verticalMin = 1f;
    private float _horizontalMin = 1f;
    private float hueMin = 0f;
    private float hueMax = 1f;
    private float saturationMin = 0.6f;
    private float saturationMax = 1f;
    private float valueMin = 0.6f;
    private float valueMax = 1f;

    private int _minCubeNumber = 2;
    private int _maxCubeNumber = 6;
    private int _scaleModificator = 2;       

    public (List<Rigidbody> cubes, Vector3 position, Transform parent) OnCreate(CubeInfo cubeInfo)
    {
        _cubesToBeExploded.Clear();

        int cubeCount = Random.Range(_minCubeNumber, _maxCubeNumber + 1);

        var objScale = cubeInfo.transform.localScale;

        for (int i = 0; i < cubeCount; i++)
        {
            CubeInfo newCube = Instantiate(_prefab, InitiateCubePosition(), Quaternion.identity);

            newCube.transform.localScale = objScale / _scaleModificator;

            newCube.GetComponent<Renderer>().material.color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);

            _cubesToBeExploded.Add(newCube.Body);
        }        

        Destroy(cubeInfo.gameObject);

        return (_cubesToBeExploded, cubeInfo.transform.position, cubeInfo.transform);
    }

    private Vector3 InitiateCubePosition()
    {
        float x = Random.Range(_horizontalMin, _horizontalMax);
        float y = Random.Range(_verticalMin, _verticalMax);
        float z = Random.Range(_horizontalMin, _horizontalMax);

        return new Vector3(x, y, z);
    }
}
