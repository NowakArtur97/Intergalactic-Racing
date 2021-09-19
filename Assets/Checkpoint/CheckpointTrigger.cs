using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CheckpointTrigger : MonoBehaviour
    {
        private CheckpointsManager _checkpointsManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Vehicle vehicle))
            {
                _checkpointsManager.VehicleDriveThroughCheckpoint(this, vehicle);
            }
        }

        public void SetCheckpointsManager(CheckpointsManager checkpointsManager) => _checkpointsManager = checkpointsManager;
    }
}
