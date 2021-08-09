using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float EnemyMaxHp;
    public float EnemyNowHp;

    public float EnemyDMG;

    public Text EnemyHpText;

    
    // Start is called before the first frame update
    void Start()
    {
        EnemyHpText = GameObject.Find("Text_EnemyHp").GetComponent<Text>();
        EnemyNowHp = EnemyMaxHp;
        int r = Random.Range(0,256);
        int g = Random.Range(0,256);
        int b = Random.Range(0,256);

        GetComponent<SpriteRenderer>().color = new Color(r/255f, g/255f, b/255f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHpText.text = "EnemyHp : " + EnemyNowHp.ToString() + " / " + EnemyMaxHp.ToString();
    }

    public bool DeathCheck()
    {
        if(EnemyNowHp <= 0)
        {
            EnemyHpText.text = "";
            PlayerData.instance.PlayerNowExp += 10;
            DataManager.Instance.money += 10;
            Destroy(gameObject);

            return true;
        }

        return false;
    }
}
