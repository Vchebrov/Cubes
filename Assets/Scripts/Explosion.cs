using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interface))]
public class Explosion : MonoBehaviour
{   
    private Interface _interface;

    [SerializeField] private float _explosionRadius = 100;
    [SerializeField] private float _explosionForce = 10;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _upwardsModifier = 0.1f;

    private void OnEnable()
    {        
        _interface = GetComponent<Interface>();
        _interface.Explose += OnExplode;        
    }

    private void OnDisable()
    {        
        _interface.Explose -= OnExplode;
    }

    private void OnExplode(List<Rigidbody> cubesToBeExploded, Vector3 position, GameObject obj)
    {
        if (obj != null)
        {
            var effectInstance = Instantiate(_effect, position, Quaternion.identity);
            
            foreach (Rigidbody cube in cubesToBeExploded)
            {
                effectInstance.Play();
                cube.AddExplosionForce(_explosionForce, position, _explosionRadius, _upwardsModifier, ForceMode.Impulse);
            }

            Destroy(effectInstance.gameObject, effectInstance.main.duration);
        }
    }
}