using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private int _buttonIdentificator = 0;

    public event Action<CubeInfo> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonIdentificator))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.TryGetComponent(out CubeInfo info))
            {
                Clicked?.Invoke(hit.collider.GetComponent<CubeInfo>());
            }            
        }
    }
}
