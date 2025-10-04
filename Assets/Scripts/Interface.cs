using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Raycaster))]
public class Interface : MonoBehaviour
{

    private Raycaster _raycaster;

    public event Action<bool> Create;
    public event Action<bool> Explose;

    private void OnEnable()
    {
        _raycaster = GetComponent<Raycaster>();
        _raycaster._cubeInfo += OnClick;
    }

    private void OnClick(CubeInfo cubeInfo)
    {

    }



}
