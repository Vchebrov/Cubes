using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Raycaster), typeof(Spawner), typeof(Explosion))]
public class InteractionController : MonoBehaviour
{
    private Raycaster _raycaster;
    private Spawner _spawner;
    private Explosion _explosion;    

    private void Awake()
    {
        _raycaster = GetComponent<Raycaster>();
        _spawner = GetComponent<Spawner>();
        _explosion = GetComponent<Explosion>();
    }

    private void OnEnable()
    {        
        _raycaster._cubeInfo += OnClick;
        _spawner.BarrelsAdded += OnExplode;
    }

    private void OnDisable()
    {
        _raycaster._cubeInfo -= OnClick;
        _spawner.BarrelsAdded -= OnExplode;
    }

    private void OnClick(CubeInfo cubeInfo)
    {        
        _spawner.OnCreate(cubeInfo);
    }

    private void OnExplode(List<Rigidbody> _cubes, Vector3 position, GameObject obj)
    {        
        _explosion.OnExplode(_cubes, position, obj);
    }
}
