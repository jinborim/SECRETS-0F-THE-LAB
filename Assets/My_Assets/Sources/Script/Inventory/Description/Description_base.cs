using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description_base : MonoBehaviour
{
    [SerializeField]
    public GameObject DSC_Base;
    [SerializeField]
    public GameObject Item_DSC;
    [SerializeField]
    public GameObject Read_Dsc;
    [SerializeField]
    public Text DSC_text;
    [SerializeField]
    public Image DSC_Img;
    [SerializeField]
    public Text Read_DSC_text;
    [SerializeField]
    public Alarm alarm;


    public Item item_one;
    public Item item_two;
    public Item Decomp_item;

    // Start is called before the first frame update
    void Start()
    {
        DSC_Base.gameObject.SetActive(false);
    }

    public void SetColor(float _alpha)
    {
        Color color = DSC_Img.color;
        color.a = _alpha;
        DSC_Img.color = color;
    }

    

    public void Call_CombAlarm(Item second_item)
    {
        item_two = second_item;
        //Debug.Log(item_two);
        alarm.Alarm_Base.SetActive(true);
        alarm.Alarm_Comb(item_one, item_two);

    }

}
