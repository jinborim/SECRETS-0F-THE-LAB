using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Alarm_NoBtn : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public Alarm alarm;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.button == PointerEventData.InputButton.Left))
        {
            this.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255); // 이거 안하면 다시 창 떴을 때 활성화 된 상태됨..
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
