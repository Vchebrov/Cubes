using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    [SerializeField] private float _chanceToSplit = 100f;
    [SerializeField] private float _explosionGain = 1f;    
    
    private int _maxChance = 101;
    private int _minChance = 0;
    private float _explosionModificator = 2f;

    private float _chanceModificator = 2f;

    public float ExplosionModificator => _explosionGain;

    public Rigidbody Body { get; private set;}
         
    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }   
    public bool CanSplit()
    { 
        Debug.Log($"Original chance = {_chanceToSplit}");

        bool pass = Random.Range(_minChance, _maxChance) <= _chanceToSplit;        

        return pass;        
    } 

    public void RecalculateExplosionModificators()
    {        
        _explosionGain *= _explosionModificator;        
    }

    public void RecalculateChance()
    {
        _chanceToSplit /= _chanceModificator;
    }

}
