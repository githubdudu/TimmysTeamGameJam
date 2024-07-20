using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public int frame;
    public Renderer rendering;

    public int tempo = 120;

    private float[] scale =
    { 1f, 1.05f, 1.1f, 1.15f, 1.2f, 1.15f, 1.1f, 1.05f, 
    1f, 1.05f, 1.1f, 1.15f, 1.2f, 1.15f, 1.1f, 1.05f, 
    1f, 1.05f, 1.1f, 1.15f, 1.2f, 1.15f, 1.1f, 1.05f,
    1f, 1.1f, 1.2f, 1.4f, 1.5f, 1.4f, 1.2f, 1.1f,};

    void Start()
    {    
        // 60 seconds in a minute, 120 beats per minute, 2 beats per   second, 8 frames per beat.
        float step = 60f / tempo / 2f / 8;  
        InvokeRepeating("ChangeScale", 0f, step);
    }

    void ChangeScale()
    {
        rendering.transform.localScale = new Vector3(scale[frame], scale[frame], 1);
        
        frame = (frame + 1) % scale.Length;
    }
}
