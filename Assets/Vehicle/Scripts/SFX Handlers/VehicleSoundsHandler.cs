using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class VehicleSoundsHandler : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource _engineSource;
        [SerializeField] private AudioSource _tiresScreechingSource;
        [SerializeField] private AudioSource _hitSource;

        [SerializeField] private float _desiredEnginePitch = 0.5f;
        private float _tiresScreechingPitch;

        public void UpdateEngineSFX(float velocityMagnitude)
        {
            float desiredEngineVolume = velocityMagnitude * 0.05f;
            desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);
            _engineSource.volume = Mathf.Lerp(_engineSource.volume, desiredEngineVolume, Time.deltaTime * 10);

            _desiredEnginePitch = velocityMagnitude * 0.2f;
            _desiredEnginePitch = Mathf.Clamp(_desiredEnginePitch, 0.5f, 2.0f);
            _engineSource.pitch = Mathf.Lerp(_engineSource.pitch, _desiredEnginePitch, Time.deltaTime * 1.5f);
        }

        public void UpdateTiresScreechingSFX(float lateralVelocity, bool isScreeching, bool isBraking)
        {
            if (isScreeching)
            {
                if (isBraking)
                {
                    _tiresScreechingSource.volume = Mathf.Lerp(_tiresScreechingSource.volume, 1.0f, Time.deltaTime * 10);
                    _tiresScreechingPitch = Mathf.Lerp(_tiresScreechingSource.volume, 1.0f, Time.deltaTime * 10);
                }
                else
                {
                    _tiresScreechingSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                    _tiresScreechingPitch = Mathf.Abs(lateralVelocity) * 0.1f;
                }
                _tiresScreechingSource.pitch = _tiresScreechingPitch;
            }
            else
            {
                _tiresScreechingSource.volume = Mathf.Lerp(_tiresScreechingSource.volume, 0, Time.deltaTime * 10);
            }
        }
    }
}
