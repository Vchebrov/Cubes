using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

[RequireComponent(typeof(CubeInteractor))]
public class Explosion : MonoBehaviour
{    
    [SerializeField] private float _radius = 10f;
    [SerializeField] private float _explosionForce = 10;
    [SerializeField] private ParticleSystem _effect;    

    public void Explode(CubeInfo cubeInfo)
    {
        var effectInstance = Instantiate(_effect, cubeInfo.transform.position, Quaternion.identity);
        effectInstance.Play();

        var hits = Physics.OverlapSphere(cubeInfo.transform.position, _radius);
        Debug.Log($"Explosion force = {_explosionForce * cubeInfo.ExplosionModificator}");

        foreach (var cube in hits)
        {

            if (!cube.attachedRigidbody)
                continue;

            var rb = cube.attachedRigidbody;
            rb.AddExplosionForce(_explosionForce * cubeInfo.ExplosionModificator, cubeInfo.transform.position, _radius, 0f, ForceMode.Impulse);

        }

        Destroy(effectInstance.gameObject, effectInstance.main.duration);

    } 
}