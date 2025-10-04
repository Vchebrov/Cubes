using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _buttonIdentificator = 0;

    public event Action<bool> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonIdentificator))
        {            
                Clicked?.Invoke(true);                     
        }
    }
}
