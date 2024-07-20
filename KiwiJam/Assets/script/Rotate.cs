using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float degree;
    public Transform target;
    public float rotationSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0f, 0f, 1f);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
