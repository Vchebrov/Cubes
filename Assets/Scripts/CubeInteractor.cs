using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Raycaster), typeof(Spawner), typeof(Explosion))]
public class CubeInteractor : MonoBehaviour
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
        if (cubeInfo == null) 
            return;

        if (cubeInfo.CanSplit())
        {
            cubeInfo.RecalculateChance();
            List<Rigidbody> cubeBodies = _spawner.CreateCubesBodies(cubeInfo);
        }
        else
        {
            _explosion.Explode(cubeInfo);
            Destroy(cubeInfo.gameObject);
        }
    }
}
