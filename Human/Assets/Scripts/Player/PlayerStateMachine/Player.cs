using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }

    public Animator PlayerAnimator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D Rigidbody { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private Vector2 _workspace;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, _playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, _playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, _playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, _playerData, "land");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, _playerData, "wallSlide");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, _playerData, "wallGrab");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, _playerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, _playerData, "inAir");
    }

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Rigidbody = GetComponent<Rigidbody2D>();

        FacingDirection = 1;

        StateMachine.Init(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = Rigidbody.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        _workspace.Set(velocity, CurrentVelocity.y);
        Rigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void SetVelocityY(float velocity)
    {
        _workspace.Set(CurrentVelocity.x, velocity);
        Rigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        _workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        Rigidbody.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _playerData.GroundCheckRadius, _playerData.GroundLayer);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection, _playerData.WallCheckDistance, _playerData.GroundLayer);
    }

    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * -FacingDirection, _playerData.WallCheckDistance, _playerData.GroundLayer);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
            Flip();
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
}
