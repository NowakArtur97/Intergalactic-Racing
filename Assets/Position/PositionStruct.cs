namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionStruct
    {
        public int PassedCheckpoints { get; private set; }
        public float LastCheckpointTime { get; private set; }

        public PositionStruct(int passedCheckpoints, float lastCheckpointTime)
        {
            PassedCheckpoints = passedCheckpoints;
            LastCheckpointTime = lastCheckpointTime;
        }

        public void CheckpointPassed(float time)
        {
            PassedCheckpoints++;
            LastCheckpointTime = time;
        }
    }
}
