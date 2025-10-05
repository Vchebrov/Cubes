using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionController))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeInfo _prefab;

    private float _verticalMax = 3f;
    private float _horizontalMax = 9f;
    private float _verticalMin = 1f;
    private float _horizontalMin = 1f;
    private float _colorMin = 0.3f;
    private float _colorMax = 0.7f;

    private int _minCubeNumber = 2;
    private int _maxCubeNumber = 6;
    private int _scaleModificator = 2;    

    public event Action<List<Rigidbody>, Vector3, GameObject> BarrelsAdded;       

    public void OnCreate(CubeInfo cubeInfo)
    {
        var obj = cubeInfo.gameObject;

        List<Rigidbody> _cubesToBeExpoded = new();

        if (cubeInfo.Split())
        {
            int cubeCount = UnityEngine.Random.Range(_minCubeNumber, _maxCubeNumber + 1);

            var objScale = obj.transform.localScale;

            for (int i = 0; i <= cubeCount; i++)
            {                
                CubeInfo newCube = Instantiate(_prefab, new Vector3(UnityEngine.Random.Range(_horizontalMin, _horizontalMax),
                    UnityEngine.Random.Range(_verticalMin, _verticalMax),
                    UnityEngine.Random.Range(_horizontalMin, _horizontalMax)), Quaternion.identity);
                              
                newCube.ResetChance();

                newCube.transform.localScale = objScale / _scaleModificator;

                newCube.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(_colorMin, _colorMax),
                    UnityEngine.Random.Range(_colorMin, _colorMax),
                    UnityEngine.Random.Range(_colorMin, _colorMax));
                
                obj.GetComponent<CubeInfo>().ChildCubes.Add(newCube.Body);
            }
        }
        else
        {
            BarrelsAdded?.Invoke(obj.GetComponent<CubeInfo>().ChildCubes, obj.transform.position, obj);
            Destroy(obj);
            _cubesToBeExpoded.Clear();
        }
    }     
}
