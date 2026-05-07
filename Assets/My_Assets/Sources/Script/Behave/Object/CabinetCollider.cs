using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetCollider : MonoBehaviour
{
    public CabinetOpen cabinet_;


    /*private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(cabinet_.Open_Door());
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        cabinet_ = transform.parent.GetComponent<CabinetOpen>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(cabinet_.Open_Door());
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
