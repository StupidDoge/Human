using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troglodit : Entity
{
    public TrogloditIdleState IdleState { get; private set; }
    public TrogloditMoveState MoveState { get; private set; }

    [SerializeField] private MoveStateData _moveStateData;
    [SerializeField] private IdleStateData _idleStateData;

    public override void Start()
    {
        base.Start();

        MoveState = new TrogloditMoveState(this, StateMachine, "move", _moveStateData, this);
        IdleState = new TrogloditIdleState(this, StateMachine, "idle", _idleStateData, this);

        StateMachine.Init(MoveState);
    }
}
