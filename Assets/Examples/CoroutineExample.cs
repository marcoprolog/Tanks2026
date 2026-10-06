using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Coroutine c = StartCoroutine(myCoroutine());
        StartCoroutine(myCoroutine());
        //StartCoroutine(myCoroutine());
        //StopCoroutine(c);
    }

    IEnumerator myCoroutine()
    {
        while (true)
        {
            Debug.Log("start coroutine");
            yield return null; // pause and continue next frame
            Debug.Log("waited 1 frame");
            yield return new WaitForSeconds(5);
            Debug.Log("waited 5 seconds");
            if (Time.time > 20)
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
