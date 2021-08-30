using UnityEngine;

[CreateAssetMenu(fileName = "D_", menuName = "Data/Vehicle")]
public class D_Vehicle : ScriptableObject
{
    public float forwardAccelerationFactor = 30.0f;
    public float forwardMaxSpeed = 20.0f;

    public float reverseAccelerationFactor = 20.0f;
    public float reverseMaxSpeed = 10.0f;

    public float turnAccelerationFactor = 30.0f;
    public float turnMaxSpeed = 20.0f;

    public float driftFactor = 0.95f;
    public float turnFactor = 3.5f;
    public float magnitudeDivider = 8.0f;

    public float dragAmount = 3.0f;
    public float dragTime = 3.0f;

    public float idleSpeed = 1.5f;
}
