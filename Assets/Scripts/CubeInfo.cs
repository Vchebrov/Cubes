using System.Collections.Generic;
using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] private int _chanceToSplit = 100;

    private List<Rigidbody> _childCubes = new();

    private int _chanceModificator = 2;

    public List<Rigidbody> ChildCubes => _childCubes;
   
    public bool Split()
    { 
        if (UnityEngine.Random.Range(0, 101) <= _chanceToSplit)
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
}
