using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WOB_Alarm : MonoBehaviour
{
    [SerializeField]
    public Text textbox;
    [SerializeField]
    public Text Item_Use_Text;

    private void Start()
    {
        textbox.gameObject.SetActive(false);
        Item_Use_Text.gameObject.SetActive(false);
    }

}
