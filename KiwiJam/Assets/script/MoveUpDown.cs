using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float amplitude = 1f; // The height of the oscillation
    public float frequency = 5000f; // The speed of the oscillation

    private Vector3 startPosition;

    public GameObject child;

    public Transform parent;

    void Start()
    {
        // Record the starting position of the ball
        startPosition = transform.localPosition;
    }

    void Update()
    {
        // Calculate the new Y position
        float newY = Mathf.Sin(frequency * Time.time) * amplitude;
        // Debug.LogError($"newY={newY}");
        // Update the ball's position
        transform.localPosition = new Vector3(0, newY, 0);
        // OnTriggerEnter();
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     newY
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Jump")
        {
            // Sets "newParent" as the new parent of the child GameObject.
            // child.transform.SetParent(other);

            // Get its parent and make parent disappear
            // String name = child.transform.root;
            // Debug.Log($"Current parent={child.transform.root}");
            // Destroy(child.transform.parent.gameObject);

            Renderer rend = child.transform.parent.GetComponent<Renderer>();
            Debug.Log($"Renderer status={rend}");
            rend.enabled = false;

            // Same as above, except worldPositionStays set to false
            // makes the child keep its local orientation rather than
            // its global orientation.
            child.transform.SetParent(other.transform, false);



            // Setting the parent to ‘null’ unparents the GameObject
            // and turns child into a top-level object in the hierarchy
            // child.transform.SetParent(null);
            Debug.Log($"Triggered by New jump parent={other}");
        }
    }
}