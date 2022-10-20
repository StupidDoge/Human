using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int _xInput;
    private bool _isGrounded;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _xInput = player.InputHandler.NormalizedInputX;

        if (_isGrounded && player.CurrentVelocity.y < 0.01f)
            stateMachine.ChangeState(player.LandState);
        else
        {
            player.CheckIfShouldFlip(_xInput);
            player.SetVelocityX(playerData.MovementVelocity * _xInput);

            player.PlayerAnimator.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.PlayerAnimator.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
