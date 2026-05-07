using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Box : MonoBehaviour
{

    public bool OnBox;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            OnBox = true;
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            OnBox = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            OnBox = false;
        }
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        OnBox = false;
    }

}
