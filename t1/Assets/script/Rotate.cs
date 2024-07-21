using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 1000f;
    public GameObject largerCircle; // Reference to the larger circle

    void Update()
    {
        if (enabled)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MoveUpDown ball = other.GetComponent<MoveUpDown>();
        if (ball != null && ball.parentCircle != this.gameObject)
        {
            // Hide the current parent of the ball if it exists
            if (ball.parentCircle != null)
            {
                Renderer rend = ball.parentCircle.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.enabled = false;
                }
            }

            // Set this object as the new parent circle
            ball.parentCircle = this.gameObject;

            // Make the ball a child of the new parent circle
            other.transform.SetParent(this.transform, false);

            // Make the new parent circle visible
            Renderer newRend = this.GetComponent<Renderer>();
            if (newRend != null)
            {
                newRend.enabled = true;
            }

            Debug.Log($"Ball triggered by new parent circle={this.gameObject.name}");
        }
    }
}