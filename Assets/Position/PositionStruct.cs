namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionStruct
    {
        public int PassedCheckpoints { get; private set; }
        public double LastCheckpointTime { get; private set; }

        public PositionStruct(int passedCheckpoints, float lastCheckpointTime)
        {
            PassedCheckpoints = passedCheckpoints;
            LastCheckpointTime = lastCheckpointTime;
        }

        public void CheckpointPassed(double time)
        {
            PassedCheckpoints++;
            LastCheckpointTime = time;
        }
    }
}
