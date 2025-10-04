using System.Collections.Generic;
using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] private int _chanceToSplit = 100;

    private int _maxChance = 101;
    private int _minChance = 0;

    private List<Rigidbody> _childCubes = new();

    private int _chanceModificator = 2;

    public Rigidbody Body { get; private set;}

    public List<Rigidbody> ChildCubes => _childCubes;        
   
    public bool Split()
    { 
        if (Random.Range(_minChance, _maxChance) <= _chanceToSplit)
        {
            _chanceToSplit /= _chanceModificator;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetChance()
    {
        _chanceToSplit = 100;
    }

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }
}
