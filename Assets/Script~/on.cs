using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class on : MonoBehaviour
{
    public string transferMapName;
    
    private void OnTriggerEnter(Collider collision)
    {

        if(collision.gameObject.name == "head")

        {
            SceneManager.LoadScene(transferMapName);

        }

    }
}
