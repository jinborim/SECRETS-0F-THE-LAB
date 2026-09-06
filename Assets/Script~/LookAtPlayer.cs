using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LookAtPlayer : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "head")
        {
            transform.LookAt(other.transform);
        }
 
    }
}
 
