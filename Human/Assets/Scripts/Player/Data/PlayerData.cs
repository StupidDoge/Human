using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float MovementVelocity = 10f;

    [Header("Jump State")]
    public float JumpVelocity = 15f;
    public int AmountOfJumps = 1;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("In Air State")]
    public float CoyoteTime = 0.2f;
    public float JumpHeightMultiplier = 0.5f;

    [Header("Wall Slide State")]
    public float WallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float WallClimbVelocity = 3f;

    [Header("Ledge Climb State")]
    public Vector2 StartOffset;
    public Vector2 StopOffset;

    [Header("Check variables")]
    public float GroundCheckRadius = 0.3f;
    public float WallCheckDistance = 0.5f;
    public LayerMask GroundLayer;
}
