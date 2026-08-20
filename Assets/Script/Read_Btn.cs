using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Read_Btn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public Inventory theinventory;

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(255, 130, 140, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            
            theinventory.Item_SlotParent.gameObject.SetActive(false);
            theinventory.Read_SlotParent.gameObject.SetActive(true);
            if (theinventory.Desc.DSC_Base.gameObject.activeSelf == true)
            {
                theinventory.Desc.DSC_Base.gameObject.SetActive(false);
            }
            

        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
