using UnityEngine;
using System.Linq;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class WheelSmokePartcileHandler : MonoBehaviour
    {
        [SerializeField] private float _emissionTime = 5.0f;

        private bool _shouldEmit;
        private float _particleEmissionRate;

        private ParticleSystem.EmissionModule[] _particleSystemEmissionModules;

        private void Awake()
        {
            _particleSystemEmissionModules = GetComponentsInChildren<ParticleSystem>().Select(particleSystem => particleSystem.emission).ToArray();

            SetEmissionRate(0);
        }

        public void Update()
        {
            _particleEmissionRate = Mathf.Lerp(_particleEmissionRate, 0, Time.deltaTime * _emissionTime);
            _particleSystemEmissionModules.ToList().ForEach(emissionModule => emissionModule.rateOverTime = _particleEmissionRate);
        }

        public void SetEmissionRate(float emissionRate) => _particleEmissionRate = emissionRate;
    }
}
