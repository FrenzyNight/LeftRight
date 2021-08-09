using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;

    void Awake()
    {
        PlayerData.instance = this;
        PlayerTr = GetComponent<Transform>();
        animator = GetComponentInChildren<Animator>();
        WorkMotion();
    }

    public void LevelUP()
    {
        if(PlayerNowExp >= PlayerMaxExp)
        {
            GameObject effect = Instantiate(LevelUPEffect, new Vector2(PlayerTr.position.x, PlayerTr.position.y + 1.5f)  ,Quaternion.identity);
            Destroy(effect,1f);
            PlayerLevel += 1;
            PlayerDMG += 3;
            PlayerNowExp -=  PlayerMaxExp;
            PlayerMaxExp *= 1.1f;
            PlayerMaxHp += 10;
            PlayerNowHp = PlayerMaxHp;
        }
    }

    public bool DieCheck()
    {
        if(PlayerNowHp <= 0)
        {
            DeathMotion();

            return true;
        }

        return false;
    }

    public void AttackMotion()
    {
        animator.SetTrigger("Attack");
    }

    public void WorkMotion()
    {
        animator.SetFloat("RunState", 0.2f);
    }

    public void IdleMotion()
    {
        animator.SetFloat("RunState", 0);
    }

    public void DeathMotion()
    {
        animator.SetTrigger("Die");
    }

    Animator animator;
    public GameObject LevelUPEffect;

    public Transform PlayerTr;
    public float PlayerMaxHp;
    public float PlayerNowHp;

    public float PlayerMaxExp;
    public float PlayerNowExp;
    
    public int PlayerLevel;

    public float PlayerDMG;
}
