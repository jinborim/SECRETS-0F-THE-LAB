using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    public GameObject FlashLight;

    private void Awake()
    {
        FlashMake();
    }

    void FlashMake()
    {
        Instantiate(FlashLight, transform.position, transform.rotation);
    }
}
