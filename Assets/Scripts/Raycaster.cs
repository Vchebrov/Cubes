using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Raycaster : MonoBehaviour
{
    private InputReader _inputReader;

    public event Action<CubeInfo> _cubeInfo;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }
    private void OnEnable()
    {        
        _inputReader.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= OnClicked;
    }

    private void OnClicked(bool isClicked)
    {
        if (isClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.TryGetComponent(out CubeInfo info))
            {
                _cubeInfo?.Invoke(info);
            }
        }
    }    
}
