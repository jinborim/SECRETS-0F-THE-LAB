using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject inactive;
    public Description_base Desc;
    [SerializeField]
    public CombBtn combBtn;
    [SerializeField]
    public DecomBtn decomBtn;
    public Alarm alarm;


    public Item item;
    public int itemCount;
    public Image itemImage;

    public bool is_combItem=false;

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    [SerializeField]
    Transform Parent_transform;
    

    public void OnPointerEnter(PointerEventData eventData)
    {

        Parent_transform.GetChild(0).transform.Find("Slot_Activate").gameObject.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Parent_transform.GetChild(0).transform.Find("Slot_Activate").gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) //아이템 사용
    {

        if (combBtn.is_Comb != true)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if ((item != null)&&(item.Usable==true))
                {
                    //ItemUse(item);
                    Debug.Log(item.itemName + " 을 사용했습니다.");
                    SetSlotCount(-1);
                }
            }

            if (eventData.button == PointerEventData.InputButton.Left)
            {
                
                if (item != null)
                {
                    Clear_DESC();
                    Open_DESC();
                    //Debug.Log(item.itemPrefab.transform)
                }
                else if (item == null && Desc.DSC_Base.activeSelf == true)
                {
                    Clear_DESC();
                    Desc.DSC_Base.SetActive(false); // 설명창이 켜져 있을때 빈 슬롯을 누르면 꺼지도록
                }
            }
        }
        else if(combBtn.is_Comb == true) //조합 버튼이 눌렸을 때
        {
            if ((item != null)&& (item != Desc.item_one)) //아이템이 비어있는 슬롯이 아니고, 선택된 슬롯의 아이템이 처음 선택된 슬롯의 아이템과 다를 때
            {
                if (is_combItem == true)  // 해당 슬롯의 아이템이 조합 가능할 때
                {
                   //DESC에 아이템 
                    Desc.Call_CombAlarm(item);
                }
                else if (is_combItem != true)  //해당 슬롯의 아이템이 조합가능한 아이템이 아닐 때
                {
                    //alarm.Alarm_Base.SetActive(true); 
                    alarm.Alarm_Warning("Comb"); // 알람의 경고 함수로 조합 가능한 아이템이 아님을 알림
                    

                }
            }
            
            
            
            
        }
        


    }

    public void Open_DESC()
    {

        Desc.DSC_Base.SetActive(true);
        Desc.Item_DSC.SetActive(true);
        Desc.Read_Dsc.SetActive(false);
        Clear_DESC();
        //Btn_Color(item);
        //����â�� ���� ����
        Desc.DSC_Img.sprite = item.ItemImage;
        Desc.SetColor(1);
        //������ ä���
        Desc.DSC_text.text = item.item_exp;
        //Desc�� ������ ���� �����صα�
        if (item.itemType == Item.ItemType.Comb)
        {
            Desc.item_one = item;
        }
        else if (item.itemType == Item.ItemType.Decomp)
        {
            Desc.Decomp_item = item;
        }

        

    }

    public void Clear_DESC()
    {
        Desc.DSC_Img.sprite = null;
        Desc.SetColor(0);
        Desc.DSC_text.text = null;
        Desc.item_one = null;
        Desc.item_two = null;
        Desc.Decomp_item = null;
    }

    public void Btn_Color(Item item)
    {
        if (item.itemType == Item.ItemType.Comb)
        {
            combBtn.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if(item.itemType != Item.ItemType.Comb)
        {
            combBtn.transform.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        }
        
        if(item.itemType == Item.ItemType.Decomp)
        {
            decomBtn.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if(item.itemType != Item.ItemType.Decomp)
        {
            decomBtn.transform.GetComponent<Image>().color = new Color32(180, 180, 180, 255);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {

            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
            DragSlot.instance.SetColor(1);

        }
    }

    // ���콺 �巡�� ���� �� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {

        if (item != null)
        {

            DragSlot.instance.transform.position = eventData.position;


        }

    }

    // ���콺 �巡�װ� ������ �� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {

        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();

        }

    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        go_CountImage.SetActive(false);
        Parent_transform.GetChild(0).transform.Find("Slot_Activate").gameObject.SetActive(false);
        inactive = Parent_transform.GetChild(0).transform.Find("Inactive").gameObject;
        inactive.SetActive(false); //���߿� ������ ����/�и� �����ؼ� �Ⱦ��� ���� ������
        Desc = GameObject.FindObjectOfType<Description_base>();
        alarm = GameObject.FindObjectOfType<Alarm>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // �κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.ItemImage;

        go_CountImage.SetActive(true);
        text_Count.text = itemCount.ToString();



        SetColor(1);
    }

    // �ش� ������ ������ ���� ������Ʈ
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }

    }

    // �ش� ���� �ϳ� ����
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }


    public void ItemUse(Item item_)
    {
        switch (item_.itemType)
        {
            case Item.ItemType.Comb:
                break;
            default:
                break;
        }
    }

}
