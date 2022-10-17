using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected float startTime;

    private string _animationName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        _animationName = animationName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.PlayerAnimator.SetBool(_animationName, true);
        startTime = Time.time;
        Debug.Log(_animationName);
    }

    public virtual void Exit()
    {
        player.PlayerAnimator.SetBool(_animationName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
