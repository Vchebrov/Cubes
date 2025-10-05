using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Raycaster), typeof(Spawner))]
public class Interface : MonoBehaviour
{
    private Raycaster _raycaster;
    private Spawner _spawner;

    public event Action<CubeInfo> Create;
    public event Action<List<Rigidbody>, Vector3, GameObject> Explose;

    private void OnEnable()
    {
        _raycaster = GetComponent<Raycaster>();
        _spawner = GetComponent<Spawner>();
        _raycaster._cubeInfo += OnClick;
        _spawner.BarrelsAdded += OnExplose;
    }

    private void OnClick(CubeInfo cubeInfo)
    {
        Create?.Invoke(cubeInfo);
    }

    private void OnExplose(List<Rigidbody> _cubes, Vector3 position, GameObject obj)
    {
        Explose?.Invoke(_cubes, position, obj);
    }
}
