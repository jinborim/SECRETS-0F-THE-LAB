using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DecomBtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Description_base Desc;
    public Alarm alarm;
    public bool is_decomp=false;


    void Start()
    {
        Desc = GameObject.FindObjectOfType<Description_base>();
        alarm = GameObject.FindObjectOfType<Alarm>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if((eventData.button == PointerEventData.InputButton.Left))
        {
            is_decomp = true;
            alarm.Alarm_Base.SetActive(true);
            alarm.Alarm_Decomp(Desc.Decomp_item);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(140, 255, 220, 255);

        if ((Desc.Decomp_item!=null) &&(Desc.Decomp_item.itemType == Item.ItemType.Decomp)) 
        {
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        if ((Desc.Decomp_item != null) && (Desc.Decomp_item.itemType == Item.ItemType.Decomp))
        {
            
        }
    }

}
