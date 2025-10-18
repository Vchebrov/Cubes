using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] private float _chanceToSplit = 100f;

    private int _maxChance = 101;
    private int _minChance = 0;    

    private float _chanceModificator = 2f;

    public Rigidbody Body { get; private set;}
         
    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }   
    public bool CanSplit()
    { 
        Debug.Log($"Original chance = {_chanceToSplit}");

        bool pass = Random.Range(_minChance, _maxChance) <= _chanceToSplit;       
        _chanceToSplit /= _chanceModificator;

        return pass;        
    } 
}
