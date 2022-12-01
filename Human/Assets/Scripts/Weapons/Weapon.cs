using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Animator attackAnimator;

    protected PlayerAttackState playerAttackState;

    protected virtual void Start()
    {
        attackAnimator = GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        attackAnimator.SetBool("attack", true);
    }

    public virtual void ExitWeapon()
    {
        attackAnimator.SetBool("attack", false);

        gameObject.SetActive(false);
    }

    public virtual void AnimationFinishTrigger()
    {
        playerAttackState.AnimationFinishTrigger();
    }

    public void InitWeapon(PlayerAttackState state)
    {
        playerAttackState = state;
    }
}
