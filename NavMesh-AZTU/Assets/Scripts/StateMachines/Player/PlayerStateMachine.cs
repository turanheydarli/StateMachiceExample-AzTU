using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public LayerMask GroundLayer { get; set; }
    public Rigidbody Physics { get; private set; }
    public Detector Detector { get; private set; }

    private void Awake()
    {
        Physics = GetComponent<Rigidbody>();
        Detector = GetComponentInChildren<Detector>();

        SwitchState(new PlayerMoveState(this));
    }
}