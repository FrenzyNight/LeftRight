using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Sprite[] LeftRight;
    public int MaxHp;
    private int NowHp;

    public Text HpText;

    List<int> TargetList = new List<int>();

    public Image Target;
    public Image[] list;

    public Image TimeBar;

    public float TimeLimit;

    private float TimeLeft;

    void Awake()
    {
        for(int i=0;i<6;i++)
        {
           TargetList.Add(Random.Range(0,2));
        }
        
        NowHp = MaxHp;
    }
    // Start is called before the first frame update
    void Start()
    {
        ListUpdate();
    }

    void Update()
    {
        TimeBar.fillAmount = TimeLeft / TimeLimit;
        TimeLeft -= Time.deltaTime;
        if(TimeLeft < 0)
        {
            ButtonCheck(-1);
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
        HpText.text = "HP : " + NowHp.ToString() + " / " + MaxHp.ToString();
    }

    public void ButtonCheck(int lr)
    {
        if(lr != TargetList[0])
        {
            NowHp -= 10;
        }

        TargetList.RemoveAt(0);
        TargetList.Add(Random.Range(0,2));

        ListUpdate();
    }
}
