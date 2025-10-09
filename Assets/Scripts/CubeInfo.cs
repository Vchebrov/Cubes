using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    static private int _chanceToSplit = 100;

    private int _maxChance = 101;
    private int _minChance = 0;    

    private int _chanceModificator = 2;

    public Rigidbody Body { get; private set;}
         
    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }
   
    public bool InitiateSplitChance()
    { 
        Debug.Log(_chanceToSplit);

        bool pass = Random.Range(_minChance, _maxChance) <= _chanceToSplit;
        _chanceToSplit /= _chanceModificator;

        return pass;        
    }    
}
