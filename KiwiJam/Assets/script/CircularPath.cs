using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPath : MonoBehaviour
{
    public Transform target;

    public float speed = 2f;
    public float radius = 1f;
    public float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // float x = target.position.x + Mathf.Cos(angle) * radius;
        // float y = target.position.y + Mathf.Sin(angle) * radius;
        // float z = target.position.z;

        // transform.position = new Vector3(x, y, z);

        // angle += speed * Time.deltaTime;

    }
}
