using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponSO _weaponData;

    protected Animator attackAnimator;

    protected PlayerAttackState playerAttackState;

    protected int attackCounter;

    protected virtual void Start()
    {
        attackAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= _weaponData.MovementSpeed.Length)
            attackCounter = 0;

        attackAnimator.SetBool("attack", true);
        attackAnimator.SetInteger("attackCounter", attackCounter);
    }

    public virtual void ExitWeapon()
    {
        attackAnimator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    public virtual void StartAnimationMovementTrigger()
    {
        playerAttackState.SetPlayerVelocity(_weaponData.MovementSpeed[attackCounter]);
    }

    public virtual void StopAnimationMovementTrigger()
    {
        playerAttackState.SetPlayerVelocity(0f);
    }

    public virtual void AnimationFinishTrigger()
    {
        playerAttackState.AnimationFinishTrigger();
    }

    public virtual void AnimationTurnOnFlip()
    {
        playerAttackState.SetFlipCheck(true);
    }

    public virtual void AnimationTurnOffFlip()
    {
        playerAttackState.SetFlipCheck(false);
    }

    public void InitWeapon(PlayerAttackState state)
    {
        playerAttackState = state;
    }
}
