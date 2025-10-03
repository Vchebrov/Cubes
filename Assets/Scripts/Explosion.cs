using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Explosion : MonoBehaviour
{
    private Spawner _spawner;

    [SerializeField] private float _explosionRadius = 100;
    [SerializeField] private float _explosionForce = 10;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _upwardsModifier = 0.1f;

    private void OnEnable()
    {
        _spawner = GetComponent<Spawner>();
        _spawner.BarrelsAdded += Explode;
    }

    private void OnDisable()
    {
        _spawner.BarrelsAdded -= Explode;
    }

    private void Explode(List<Rigidbody> cubesToBeExploded, Vector3 position, GameObject obj)
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