using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private int _buttonIdentificator = 0;

    public event Action<Vector3> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonIdentificator))
        {
            var pointer = Input.mousePosition;
            Clicked?.Invoke(pointer);
        }
    }
}
