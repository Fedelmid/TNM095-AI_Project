﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float health = 100f;
    public ThirdPersonMovement player;

    public float damageSpeed = 1f;
    public float damageGain = 3f;
    public float healSpeed = 1.5f;
    public float healGain = 1.5f;

    bool isAttacking = false;
    bool isHealing = false;

    private void OnTriggerEnter(Collider other)
    {

        switch(other.tag)
        {
            case "Attack":
                if (!isAttacking)
                {
                    Debug.Log("ATTACK!");
                    StartCoroutine("AttackPlayer");
                }
                break;

            case "Speed":
                if (!player.speedBoost)
                {
                    Debug.Log("SPEED!");
                    player.StartCoroutine("SpeedBoost");
                }
                break;

            case "Heal":
                if (!isHealing)
                {
                    Debug.Log("HEAL!");
                    StartCoroutine("HealPlayer");
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            health -= damageGain;
            Debug.Log("Player Health is: "+health);
            yield return new WaitForSeconds(damageSpeed);
            isAttacking = false;
        }
    }

    private IEnumerator HealPlayer()
    {
        if (!isHealing)
        {
            isHealing = true;
            health += healGain;
            Debug.Log("Player Health is: " + health);
            yield return new WaitForSeconds(healSpeed);
            isHealing = false;
        }
    }
}
