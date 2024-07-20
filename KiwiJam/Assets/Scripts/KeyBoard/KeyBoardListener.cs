using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyBoardListener : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Listen for the space key and change the color of the object
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Renderer>().material.color = Color.red;
            // wait for 0.1 seconds
            StartCoroutine(holdForSomeTime(0.1f, () => {
                // Change back to the original color
                GetComponent<Renderer>().material.color = Color.white;
            }));
        
        }
        
    }
    private IEnumerator holdForSomeTime(float seconds, Action callback = null)
    {
        yield return new WaitForSeconds(seconds);
        if (callback != null)
        {
            callback();
        }
    }
}
