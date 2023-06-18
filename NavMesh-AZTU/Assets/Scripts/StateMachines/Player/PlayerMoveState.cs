using StateMachines.Player;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Detector.OnCoinDetect += OnCoinDetect;
    }

    private void OnCoinDetect(Transform obj)
    {
        Object.Destroy(obj.gameObject);
    }

    public override void Tick(float deltaTime)
    {
        StateMachine.transform.position += Vector3.forward * (3 * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateMachine.SwitchState(new PlayerJumpState(StateMachine));
        }
    }

    public override void Exit()
    {
        StateMachine.Detector.OnCoinDetect -= OnCoinDetect;
    }
}