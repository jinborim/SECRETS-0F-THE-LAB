using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Alarm_OkBtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Alarm alarm;
    


    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Left))
        {
            this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            alarm.is_alarm = false;
            alarm.Alarm_Base.SetActive(false);
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
        alarm = GameObject.FindObjectOfType<Alarm>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
