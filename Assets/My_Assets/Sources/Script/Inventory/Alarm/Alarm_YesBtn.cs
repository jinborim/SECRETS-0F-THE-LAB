using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Alarm_YesBtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Description_base Desc;
    [SerializeField]
    public Alarm alarm;
    [SerializeField]
    public CombBtn combBtn;
    [SerializeField]
    public DecomBtn decomBtn;
    public ItemComb_Test itemComb;
    public ItemDecomp_Test itemDecomp;

    [SerializeField]
    private GameObject SlotParent;
    private Slot[] slots;

    public Item item_one;
    public Item item_two;
    public Item Decomp_item;

    public void OnPointerClick(PointerEventData eventData)
    {
        if((eventData.button == PointerEventData.InputButton.Left))
        {
            this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255); // 다음에 킬 때 색깔이 원상태로

            if ((combBtn.is_Comb == true)) // 조합 모드인 경우
            {
                item_one = Desc.item_one;
                item_two = Desc.item_two;
                Slot_Clear(item_one, item_two); // 해당 아이템의 슬롯에서 아이템을 하나씩 제거하는 함수
                itemComb.Item_Combination(item_one,item_two); // 아이템 합성
                combBtn.is_Comb = false; // 조합 모드 끄기
                item_one = null; // 아이템 1 초기화
                item_two = null; // 아이템 2 초기화
                Desc.DSC_Base.SetActive(false); // 설명창 끄기
                combBtn.UnlockCombinationMode(); // 조합모드 중 변하는 기능들 전부 끄기
                alarm.Alarm_Base.SetActive(false); //알림창 끄기
            }
            else if (decomBtn.is_decomp == true) // 분해 모드인 경우
            {
                //Debug.Log("분해모드 시작");
                Decomp_item = Desc.Decomp_item;
                for(int i=0; i<slots.Length; i++)
                {
                    if (slots[i].item == Decomp_item)
                    {
                        slots[i].SetSlotCount(-1);
                        break;
                    }
                }
                itemDecomp.Item_Decomposition(Decomp_item);
                Decomp_item = null;
                Desc.DSC_Base.SetActive(false);
                alarm.Alarm_Base.SetActive(false);

            }
            alarm.is_alarm = false; //알람 모드 끄기
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(140, 255, 220, 255);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }


    // Start is called before the first frame update
    void Start()
    {
        itemComb = GameObject.FindObjectOfType<ItemComb_Test>();
        itemDecomp = GameObject.FindObjectOfType<ItemDecomp_Test>();
        slots = SlotParent.GetComponentsInChildren<Slot>();
    }

    public void Slot_Clear(Item item_one, Item item_two)
    {
        for(int i=0; i<slots.Length; i++)
        {
            if (slots[i].item == item_one)
            {
                slots[i].SetSlotCount(-1);
                break;
            }
            else if (slots[i].item != item_one)
            {
                //Debug.Log("1 아님");
            }

        }

        for (int j = 0; j < slots.Length; j++)
        {
            if (slots[j].item == item_two)
            {
                slots[j].SetSlotCount(-1);
                break;
            }
            else if (slots[j].item != item_two)
            {
                //Debug.Log("2 아님");
            }

        }

    }

}
