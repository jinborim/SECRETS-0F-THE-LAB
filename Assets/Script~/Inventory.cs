using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool invectoryActivated = false;

    [SerializeField]
    private GameObject go_InventoryBase; //Inventory의 베이스가 되는 이미지(검은 바탕)
    [SerializeField]
    public GameObject Item_SlotParent;
    [SerializeField]
    public GameObject Read_SlotParent;
    [SerializeField]
    public Description_base Desc;

    [SerializeField]
    public CombBtn comb;
    private Alarm alarm;

    private Slot[] slots;
    private Read_Slot[] read_Slots;

    public string Temp_Text;
    public static bool inventory_able=true;

    // Start is called before the first frame update
    void Start()
    {
        inventory_able = true;
        go_InventoryBase.SetActive(false);
        slots = Item_SlotParent.GetComponentsInChildren<Slot>();
        read_Slots=Read_SlotParent.GetComponentsInChildren<Read_Slot>();
        //comb = GameObject.FindObjectOfType<CombBtn>();
        alarm = GameObject.FindObjectOfType<Alarm>();
    }

    private void TryOpenInventory()
    {
        if ((alarm.is_alarm != true)&&(inventory_able==true))
        {
            if (Input.GetKeyDown(KeyCode.I)) 
            {
                invectoryActivated = !invectoryActivated;

                if (invectoryActivated)
                {
                    OpenInventory();


                }

                else
                {

                    //Desc.DSC_Base.SetActive(false);
                    CloseInventory();
                }


            }
        }
        
    }

    private void OpenInventory()
    {
        InventoryReset();
        go_InventoryBase.SetActive(true);
        Read_SlotParent.SetActive(false);
        
    }

    private void CloseInventory()
    {
        if ((go_InventoryBase.activeSelf == true))
        {
            go_InventoryBase.SetActive(false);
        }
        Desc.DSC_Base.SetActive(false);

    }

    public void InventoryReset()
    {
        //인벤토리 관련된 모든 기능 한 번 리셋
        if (Item_SlotParent.activeSelf == false)
        {
            Item_SlotParent.SetActive(true);
        }
        if (comb!=null&&comb.is_Comb == true)
        {
            comb.is_Comb = false;
            comb.UnlockCombinationMode();
        }
    }


    // Update is called once per frame
    void Update()
    {
        TryOpenInventory();
    }

    public void Temp_Readable_Text(string text)
    {
        Temp_Text = null;
        Temp_Text = text;
    }


    public void AcquireItem(Item _item, int _count = 1)
    {
        //Debug.Log("������ �׵�");

        if (_item.itemType != Item.ItemType.Read)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)  // null �̶�� slots[i].item.itemName �� �� ��Ÿ�� ���� ����
                {
                    if (slots[i].item.itemName == _item.itemName) // ��� ������ �˻��ؼ� � ���Կ� �� �����۰� ���� ������ �������� ������..
                    {
                        slots[i].SetSlotCount(_count); //���� _count=1�̹Ƿ� slot�� SetSlotCount���� ������ ī��Ʈ�� 1��ŭ ���� �÷���
                        return;
                    }
                }
                else if (slots[i].item == null)//���� ���Ժ��� ���ʷ� �˻��ؼ� �� ������ ���� ��
                {
                    slots[i].AddItem(_item, _count); // �ش� ���Կ� �������� �־���
                    return;
                }

            }
        }
        else if(_item.itemType == Item.ItemType.Read)
        {
            for(int j=0; j<read_Slots.Length; j++)
            {
                if (read_Slots[j].item == null)
                {
                    read_Slots[j].AddItem(_item);
                    read_Slots[j].Get_Text(Temp_Text);
                    return;
                }
            }
        }

        
        


    }



}
