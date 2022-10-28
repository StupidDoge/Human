using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityY(-playerData.WallSlideVelocity);

        if (yInput == 0 && grabInput)
            player.StateMachine.ChangeState(player.WallGrabState);
        else if (yInput == 1 && grabInput)
            player.StateMachine.ChangeState(player.WallClimbState);
    }
}
