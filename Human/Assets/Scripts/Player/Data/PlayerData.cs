using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move state")]
    public float MovementVelocity = 10f;

    [Header("Jump state")]
    public float JumpVelocity = 15f;
    public int AmountOfJumps = 1;

    [Header("In Air state")]
    public float CoyoteTime = 0.2f;
    public float JumpHeightMultiplier = 0.5f;

    [Header("Check variables")]
    public float GroundCheckRadius = 0.3f;
    public LayerMask GroundLayer;
}
