using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeInteractor))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 100;
    [SerializeField] private float _explosionForce = 10;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _upwardsModifier = 0.1f;
    
    public void Explode(List<Rigidbody> cubesToBeExploded, Vector3 position, Transform parent)
    {
        if (parent != null)
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