using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveWeapon : Weapon
{
    protected AgressiveWeaponSO agressiveWeaponData;

    private List<IDamageable> _detectedDamageables = new List<IDamageable>();

    protected override void Awake()
    {
        base.Awake();

        if (weaponData.GetType() == typeof(AgressiveWeaponSO))
            agressiveWeaponData = (AgressiveWeaponSO)weaponData;
        else
            Debug.LogError("Wrong data for the weapon");
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = agressiveWeaponData.AttackDetails[attackCounter];

        foreach (IDamageable item in _detectedDamageables)
        {
            item.Damage(details.DamageAmount);
        }
    }

    private void AddToDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
            _detectedDamageables.Add(damageable);
    }

    private void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
            _detectedDamageables.Remove(damageable);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFromDetected(collision);
    }
}
