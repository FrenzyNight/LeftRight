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
    }

    public void LevelUP()
    {
        if(PlayerNowExp >= PlayerMaxExp)
        {
            GameObject effect = Instantiate(LevelUPEffect,gameObject.GetComponent<Transform>().position ,Quaternion.identity);
            Destroy(effect,1f);
            PlayerLevel += 1;
            PlayerDMG += 3;
            PlayerNowExp -=  PlayerMaxExp;
            PlayerMaxExp *= 1.1f;
            PlayerMaxHp += 10;
            PlayerNowHp = PlayerMaxHp;
        }
    }

    public GameObject LevelUPEffect;

    public Transform PlayerTr;
    public float PlayerMaxHp;
    public float PlayerNowHp;

    public float PlayerMaxExp;
    public float PlayerNowExp;
    
    public int PlayerLevel;

    public float PlayerDMG;
}
