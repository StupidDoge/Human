using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public AttackState EnemyAttackState;

    private void TriggerAttack()
    {
        EnemyAttackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        EnemyAttackState.FinishAttack();
    }
}
