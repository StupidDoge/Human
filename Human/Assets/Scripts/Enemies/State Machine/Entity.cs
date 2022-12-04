using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine StateMachine { get; private set; }
    public EntityData Data;

    public Rigidbody2D EnemyRigidbody { get; private set; }
    public Animator EnemyAnimator { get; private set; }
    public GameObject AliveGameObject { get; private set; }

    public int FacingDirection { get; private set; }

    [SerializeField] private Transform _wallCheck;
    [SerializeField] private Transform _ledgeCheck;

    private Vector2 _velocityWorkspace;

    public virtual void Start()
    {
        StateMachine = new FiniteStateMachine();
        FacingDirection = 1;

        AliveGameObject = transform.Find("Alive").gameObject;
        EnemyRigidbody = GetComponent<Rigidbody2D>();
        EnemyAnimator = AliveGameObject.GetComponent<Animator>();
    }

    public virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        _velocityWorkspace.Set(FacingDirection * velocity, EnemyRigidbody.velocity.y);
        EnemyRigidbody.velocity = _velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(_wallCheck.position, AliveGameObject.transform.right, Data.WallCheckDistance, Data.GroundLayer);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(_ledgeCheck.position, Vector2.down, Data.LedgeCheckDistance, Data.GroundLayer);
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        AliveGameObject.transform.Rotate(0, 180f, 0);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(_wallCheck.position, _wallCheck.position + (Vector3)(Vector2.right * FacingDirection * Data.WallCheckDistance));
        Gizmos.DrawLine(_ledgeCheck.position, _ledgeCheck.position + (Vector3)(Vector2.down * Data.LedgeCheckDistance));
    }
}
