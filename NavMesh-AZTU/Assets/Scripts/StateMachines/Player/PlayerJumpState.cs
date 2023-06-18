using UnityEngine;

namespace StateMachines.Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            StateMachine.Physics.AddForce(Vector3.up * 10f, ForceMode.Impulse);

            StateMachine.Detector.OnDetectGround += OnDetectGround;
        }

        private void OnDetectGround()
        {
            StateMachine.SwitchState(new PlayerMoveState(StateMachine));
        }

        public override void Tick(float deltaTime)
        {
        }

        public override void Exit()
        {
            StateMachine.Detector.OnDetectGround -= OnDetectGround;
        }
    }
}