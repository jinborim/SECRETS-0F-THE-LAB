using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mirror : MonoBehaviour, IPointerClickHandler
{
    public Mirror mirror;



    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.name == "Mirror")
            {

                StartCoroutine(Text_Effect.Typing(GameObject.FindObjectOfType<WOB_Alarm>().textbox, new string[] { "거울...? 어딘가 위화감이 든다." }, "N"));
                

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mirror = GameObject.FindObjectOfType<Mirror>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
