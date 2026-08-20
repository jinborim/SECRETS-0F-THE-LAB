using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo_bath : MonoBehaviour
{
    public Combinationable comb;
    public Description_base Desc;
    public Inventory theInventory;

    public ITEM_LIST item_list;
    public Item result_item;



    // Start is called before the first frame update
    void Start()
    {
        Desc = GameObject.FindObjectOfType<Description_base>();
        theInventory = GameObject.FindObjectOfType<Inventory>();

    }

    public Item Item_Combination(Item item_one, Item Item_two)
    {
        //Debug.Log(item_one.name+" 와 "+ Item_two.name);
        switch (item_one.itemName) //합성하려는 아이템 1
        {
            case "ToiletRoll":
                switch (Item_two.itemName)
                {
                    case "knif":
                        Combed_Item_Compare("tissupaper");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
            case "knif":
                switch (Item_two.itemName)
                {
                    case "ToiletRoll":
                        Combed_Item_Compare("tissupaper");
                        //Debug.Log(result_item.name);
                        theInventory.AcquireItem(result_item);
                        break;
                }
                break;
        }
        return result_item;
    }

    public void Combed_Item_Compare(string item_name)
    {
        for (int i = 0; i < item_list.items.Length; i++)
        {
            if (item_name == item_list.items[i].itemName)
            {
                result_item = item_list.items[i];
                break;
            }
            else
            {
                result_item = null;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
