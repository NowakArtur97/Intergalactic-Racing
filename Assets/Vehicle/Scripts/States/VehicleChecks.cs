namespace NowakArtur97.IntergalacticRacing.Core
{
    public class VehicleChecks
    {
        private Vehicle _vehicle;

        public VehicleChecks(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public bool CheckIsMoving() => _vehicle.MovementInput.y != 0;

        public bool CheckIsMovingBackward() => _vehicle.MovementInput.y < 0;

        public bool CheckIsTurning() => _vehicle.MovementInput.x != 0;
    }
}
