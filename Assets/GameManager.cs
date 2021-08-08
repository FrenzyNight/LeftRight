using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public Sprite[] LeftRight;

    //플레이어 정보 : 체럭, 레벨
    public Text HpText;
    public Text LevelText;

    List<int> TargetList = new List<int>();

    public Image Target;
    public Image[] list;

    public Image TimeBar;

    public float TimeLimit;

    private float TimeLeft;

    public Text ComboText;
    private int combo = 0;

    // 적 스폰
    public GameObject EnemyPrefab;

    private Enemy Enemy;

    public Vector2 SpawnPoint;

    // 공격 효과
    public GameObject AttacEffect;

    public GameObject DeathEffect;

    void Awake()
    {
        for(int i=0;i<6;i++)
        {
           TargetList.Add(Random.Range(0,2));
        }
        
        PlayerData.instance.PlayerNowHp = PlayerData.instance.PlayerMaxHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        ListUpdate();
        Enemy = (Instantiate(EnemyPrefab, SpawnPoint, Quaternion.identity)).GetComponent<Enemy>();
    }

    void Update()
    {
        TimeBar.fillAmount = TimeLeft / TimeLimit;
        TimeLeft -= Time.deltaTime;
        if(TimeLeft < 0)
        {
            ButtonCheck(-1);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ButtonCheck(0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            ButtonCheck(1);
        }
    }

    void ListUpdate()
    {
        Target.sprite = LeftRight[TargetList[0]];
        
        for(int i=0;i<5;i++)
        {
            list[i].sprite = LeftRight[TargetList[i+1]];
        }

        TimeLeft = TimeLimit;
        TimeBar.fillAmount = 1f;
        ComboText.text = combo.ToString() + " Combo!";
        LevelText.text = "Lv. " + PlayerData.instance.PlayerLevel.ToString();
        HpText.text = "HP : " + PlayerData.instance.PlayerNowHp.ToString() + " / " + PlayerData.instance.PlayerMaxHp.ToString();
    }

    public void ButtonCheck(int lr)
    {
        if(lr != TargetList[0])
        {
            PlayerData.instance.PlayerNowHp -= Enemy.EnemyDMG;
            GameObject effect = Instantiate(AttacEffect, new Vector2(PlayerData.instance.PlayerTr.position.x, PlayerData.instance.PlayerTr.position.y + 1f), Quaternion.identity);
            Destroy(effect, 0.5f);
            combo = 0;
        }
        else
        {
            PlayerData.instance.AttackMotion();
            combo += 1;
            Enemy.EnemyNowHp -= PlayerData.instance.PlayerDMG;
            GameObject effect = Instantiate(AttacEffect, SpawnPoint, Quaternion.identity);
            Destroy(effect, 0.5f);
            if(Enemy.DeathCheck())
            {
                GameObject Deffect = Instantiate(DeathEffect, SpawnPoint, Quaternion.identity);
                Destroy(Deffect, 0.5f);
                Enemy = (Instantiate(EnemyPrefab, SpawnPoint, Quaternion.identity)).GetComponent<Enemy>();
            }
            PlayerData.instance.LevelUP();
        }


        TargetList.RemoveAt(0);
        TargetList.Add(Random.Range(0,2));

        
        ListUpdate();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(SpawnPoint, 0.1f);
    }
}
