using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComb_Test : MonoBehaviour
{

    public Combinationable comb;     // 조합 가능 여부 확인
    public Description_base Desc;    // 아이템 설명 UI
    public Inventory theInventory;   // 아이템 획득 처리를 위한 인벤토리 참조
    public ITEM_LIST item_list;      // 모든 아이템 정보가 담긴 데이터 리스트
    public Item result_item;         // 조합 결과물을 임시 저장할 변수


    // Start is called before the first frame update
    void Start()
    {
        // 씬 내에서 필요한 객체들을 자동으로 찾아 할당
        Desc = GameObject.FindObjectOfType<Description_base>();
        theInventory = GameObject.FindObjectOfType<Inventory>();
        item_list = GetComponent<ITEM_LIST>();
        
    }

    // 입력받은 두 아이템의 이름을 대조하여 조합 레시피가 있는지 확인
    public Item Item_Combination(Item item_one, Item Item_two)
    {
        //Debug.Log(item_one.name+" 와 "+ Item_two.name);
        switch (item_one.itemName) //합성하려는 아이템 1
        {
            case "Red":
                switch (Item_two.itemName)
                {
                    case "Blue":
                        Combed_Item_Compare("Purple");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Blue":
                switch (Item_two.itemName)
                {
                    case "Red":
                        Combed_Item_Compare("Purple");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Wastepaper":
                switch (Item_two.itemName)
                {
                    case "Knif":
                        Combed_Item_Compare("Hint");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Knif":
                switch (Item_two.itemName)
                {
                    case "Wastepaper":
                        Combed_Item_Compare("Hint");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Purple":
                switch (Item_two.itemName)
                {
                    case "Capsule":
                        Combed_Item_Compare("Key");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "Capsule":
                switch (Item_two.itemName)
                {
                    case "Purple":
                        Combed_Item_Compare("Key");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
        }
        return result_item;
    }

    // 문자열 이름을 기반으로 전체 아이템 리스트에서 실제 Item 객체를 찾음
    public void Combed_Item_Compare(string item_name)
    {
        for(int i=0; i<item_list.items.Length; i++)
        {
            if (item_name == item_list.items[i].itemName)
            {
                result_item = item_list.items[i]; // 일치하는 아이템 발견
                break;
            }
            else
            {
                result_item = null; //검색 실패 시 null 처리
            }
        }
    }
}
