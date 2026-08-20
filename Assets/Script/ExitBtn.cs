using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitBtn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public CombBtn comb;
    [SerializeField]
    public DecomBtn decomp;

    public Description_base Desc;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (comb.is_Comb == true)
            {
                comb.is_Comb = false;
                comb.UnlockCombinationMode();
            }
            if (decomp.is_decomp == true)
            {
                decomp.is_decomp = false;
            }
            Desc.DSC_Base.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Desc = GameObject.FindObjectOfType<Description_base>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
