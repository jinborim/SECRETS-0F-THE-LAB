using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Read_Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Description_base Desc;
    public Item item;
    public Text Read_Text;
    public Outline outline;

    public string Desc_text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            outline.effectColor = new Color32(255, 130, 140, 255); //핑크
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
            outline.effectColor = new Color32(255, 255, 255, 255);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                Clear_DESC();
                Open_DESC();
            }
            else if (item == null)
            {
                Clear_DESC();
                Desc.DSC_Base.SetActive(false); //설명창이 켜져있을 때 빈 슬롯을 누르면 꺼지도록
            }
            
        }
    }

    public void Open_DESC()
    {

        Desc.DSC_Base.SetActive(true);
        Desc.Item_DSC.SetActive(false);
        Desc.Read_Dsc.SetActive(true);
        //DSC 창에 책이나 서류 내용 띄우기
        Desc.Read_DSC_text.text = Desc_text;
        

    }

    public void Clear_DESC()
    {
        Desc.Read_DSC_text.text = null;

    }

    public void Get_Text(string text)
    {
        Desc_text = null;
        Desc_text = text;
    }


    // Start is called before the first frame update
    void Start()
    {
        Desc = GameObject.FindObjectOfType<Description_base>();
        Read_Text = transform.gameObject.GetComponentInChildren<Text>();
        outline = GetComponent<Outline>();
    }


    

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        Read_Text.text = item.itemName;
        //원래 색: 100,100,100,255 >>회색
        outline.effectColor = new Color(255, 255, 255, 255);

    }

    public void ClearSlot()
    {
        item = null;
        Desc_text = null;
        Read_Text.text= null;
        //SetColor(0);

        
        //go_CountImage.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
