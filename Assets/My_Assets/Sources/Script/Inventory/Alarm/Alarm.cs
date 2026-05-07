using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour
{
    [SerializeField]
    public GameObject Alarm_Base;
    [SerializeField]
    public GameObject Yes_No_Base;
    [SerializeField]
    public GameObject Alarm_Ok;
    [SerializeField]
    public GameObject Alarm_yes;
    [SerializeField]
    public GameObject Alarm_no;
    [SerializeField]
    public Text Alarm_Text;

    public bool is_alarm=false;

    // Start is called before the first frame update
    void Start()
    {
        Alarm_Base.SetActive(false);
    }

    public void Alarm_Comb(Item item_one, Item item_two)
    {
        if (Alarm_Base.activeSelf != true) // 함수가 불렸을 때 알림창이 켜있지 않으면 알림창부터 켜줌
        {
            Alarm_Base.SetActive(true);
        }
        is_alarm = true;
        Alarm_Text.text = null; //부를때마다 한 번 초기화
        if (item_one && item_two != null)
        {
            Alarm_BTN(false);
            Alarm_Text.text = "정말로 " + item_one.itemName + "와(과) " + item_two.itemName + "을(를)\n조합하시겠습니까?";
            
        }
        else if(item_one||item_two==null)
        {
            Alarm_Warning("Comb");
        }
    }

    public void Alarm_Decomp(Item _item)
    {
        if (Alarm_Base.activeSelf != true)
        {
            Alarm_Base.SetActive(true);
        }
        is_alarm = true;
        Alarm_Text.text = null; //부를때마다 한 번 초기화
        if (_item != null)
        {
            Alarm_BTN(false);
            Alarm_Text.text = "정말로 " + _item.itemName + "을(를) 분해하시겠습니까?";

        }
        else
        {
            Alarm_Warning("Decomp");
        }
    }

    public void Alarm_Warning(string what)
    {
        if (Alarm_Base.activeSelf != true)
        {
            Alarm_Base.SetActive(true);
        }
        
        Alarm_BTN(true);
        is_alarm = true;
        Alarm_Text.text = null; //부를때마다 한 번 초기화
        if (what == "Comb")
        {
            Alarm_Text.text = "조합 가능한 아이템이 아닙니다.";
        }
        else if (what == "Decomp")
        {
            Alarm_Text.text = "분해 가능한 아이템이 아닙니다.";
        }
    }
    
    public void Alarm_BTN(bool is_Warn)
    {
        if (is_Warn==true)
        {
            Yes_No_Base.SetActive(false);
            Alarm_Ok.SetActive(true);
        }
        else if (is_Warn != true)
        {
            Alarm_Ok.SetActive(false);
            Yes_No_Base.SetActive(true);
            
        }
    }

}
