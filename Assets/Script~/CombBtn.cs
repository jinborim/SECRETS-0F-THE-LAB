using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombBtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject SlotParent;
    
    private Slot[] slots;
    public Description_base Desc;
    public Combinationable combinationable;
    public Alarm alarm;

    public bool is_Comb=false;


    void Start()
    {
        slots = SlotParent.GetComponentsInChildren<Slot>();
        Desc = GameObject.FindObjectOfType<Description_base>();
        alarm = GameObject.FindObjectOfType<Alarm>();
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(140, 255, 220, 255);

        if ((Desc.item_one!=null) &&(Desc.item_one.itemType == Item.ItemType.Comb))
        {
            
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        
        if (is_Comb!=true)
        {
            this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Left))
        {  //조합 가능한 아이템인 경우에만 조합 버튼 활성화
            
            if(Desc.item_one != null)
            {
                if ((Desc.item_one.itemType == Item.ItemType.Comb))
                {
                    if (is_Comb != true)
                    {
                        is_Comb = true;
                        combinationable = Desc.item_one.itemPrefab.GetComponent<Combinationable>();
                        CombinationMode();
                    }
                    else if (is_Comb == true)
                    {
                        is_Comb = false;
                        UnlockCombinationMode();
                    }



                }
                else if ((Desc.item_one.itemType != Item.ItemType.Comb))
                {
                    alarm.Alarm_Warning("Comb");
                }
            }
            else if ((Desc.item_one == null)&&(Desc.Decomp_item!=null))
            {
                alarm.Alarm_Warning("Comb");
            }
            
            
        }
        

    }

    public void CombinationMode()
    {
        this.transform.GetComponent<Image>().color = new Color32(140, 255, 220, 255);

        for (int i = 0; i < slots.Length; i++)
        {
            for (int j = 0; j < combinationable.combinationableItem.Length; j++)
            {
                //Debug.Log(combinationable.combinationableItem[j]);
                if (slots[i].item == combinationable.combinationableItem[j].transform.GetComponent<ItemPickup>().item)
                {
                    //Debug.Log("활");
                    slots[i].is_combItem = true;
                    //slots[i].inactive.SetActive(false);
                }
                else if ((slots[i].item != combinationable.combinationableItem[j].transform.GetComponent<ItemPickup>().item)||slots[i].item==null)
                {
                    
                    //Debug.Log("비활");
                    slots[i].is_combItem = false;
                    //slots[i].inactive.SetActive(true);
                }
            }
        }
    }

    public void UnlockCombinationMode()
    {
        this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        //조합 활성화 상태에서 한번 더 누르면 다시 조합 비활성화 시키기
        for (int i=0; i<slots.Length; i++)
        {
            //slots[i].inactive.SetActive(false);
            slots[i].is_combItem = false;
        }
    }
}
