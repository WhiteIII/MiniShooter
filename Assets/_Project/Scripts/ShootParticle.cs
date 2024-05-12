using System.Collections;
using UnityEngine;

namespace _Project
{
    public class ShootParticle : MonoBehaviour
    {
        [SerializeField] private Gun _gun;
        [SerializeField] private ParticleSystem _shootParticleSystem;
        [SerializeField] private float _playTime;

        private void Awake()
        {
            _gun.Shooting += PlayParticleSystem;
        }

        private void OnDestroy()
        {
            _gun.Shooting -= PlayParticleSystem;
        }

        private void PlayParticleSystem()
        {
            StartCoroutine(PlayingParticle());
        }

        private IEnumerator PlayingParticle()
        {
            _shootParticleSystem.Play();
            
            yield return new WaitForSeconds(_playTime);

            _shootParticleSystem.Stop();
        }
    }
}