using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static float time;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static IEnumerator Time_Count(float MAX)
    {
        do
        {
            time += Time.deltaTime;
            yield return new WaitForSeconds(0);
        } while (time==MAX);

        time = 0;

    }
}
