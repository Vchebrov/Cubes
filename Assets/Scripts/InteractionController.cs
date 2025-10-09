using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _raycaster.GettingCube += OnClick;       
    }

    private void OnDisable()
    {
        _raycaster.GettingCube -= OnClick;        
    }   

    private void OnClick(CubeInfo cubeInfo)
    {
        if (cubeInfo == null) return;

        if (cubeInfo.InitiateSplitChance())
        {           
            var (cubes, position, parent) = _spawner.OnCreate(cubeInfo);
            _explosion.OnExplode(cubes, position, parent);
        }
        else
        {
            Destroy(cubeInfo.gameObject);
        }
    }

    private void OnExplode(List<Rigidbody> _cubes, Vector3 position, Transform parent)
    {        
        _explosion.OnExplode(_cubes, position, parent);
    }
}
