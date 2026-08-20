using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_igame : MonoBehaviour
{

    private GameObject TextPanel;
    private Text ObjectText;

    // Start is called before the first frame update
    void Start()
    {
        TextPanel = GameObject.Find("TextPanel");
        ObjectText = GameObject.Find("ObjectText").GetComponent<Text>();
        TextPanel.SetActive(false);
    }

    public void NPCChatEnter(string text)
    {
        ObjectText.text = text;
        TextPanel.SetActive(true);
    }

    public void NPCChatExit()
    {
        ObjectText.text = "";
        TextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
            }
        }

        //if (hit.transform.gameObject.tag == "Mirror")
        //{

        //}
    }
}
