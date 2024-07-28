using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public GameObject ball; // Reference to the ball
    public List<GameObject> circles; // List of circles to manage
    private int currentCircleIndex = 0; // Index to track the current circle

    private Rotate currentRotateComponent; // Reference to the current Rotate script component

    void Start()
    {
        if (circles.Count > 0)
        {
            // Initially disable rotation for all circles
            foreach (var circle in circles)
            {
                Rotate rotateComponent = circle.GetComponent<Rotate>();
                if (rotateComponent != null)
                {
                    rotateComponent.enabled = false;
                }
            }

            // Set the current circle to the first one
            SetCurrentCircle(circles[currentCircleIndex]);
        }
    }

    void Update()
    {
        if (ball != null && circles.Count > 0)
        {
            // Check if the ball is touching the edge of the current circle
            CheckEdgeAndActivateRotation();
        }
    }

    void CheckEdgeAndActivateRotation()
    {
        if (currentRotateComponent != null)
        {
            float distanceToParentCenter = Vector2.Distance(ball.transform.position, transform.position);
            CircleCollider2D parentCollider = currentRotateComponent.GetComponent<CircleCollider2D>();

            if (parentCollider != null)
            {
                float parentRadius = parentCollider.radius * transform.localScale.x;

                if (Mathf.Abs(distanceToParentCenter - parentRadius) < 0.1f)
                {
                    // Enable the Rotate script if the ball touches the edge
                    currentRotateComponent.enabled = true;

                    // Move to the next circle if available
                    SwitchToNextCircle();
                }
            }
        }
    }

    void SwitchToNextCircle()
    {
        if (currentCircleIndex < circles.Count - 1)
        {
            // Deactivate the current circle
            SetCurrentCircle(null);

            // Move to the next circle
            currentCircleIndex++;
            SetCurrentCircle(circles[currentCircleIndex]);
        }
    }

    void SetCurrentCircle(GameObject circle)
    {
        if (currentRotateComponent != null)
        {
            currentRotateComponent.enabled = false;
        }

        if (circle != null)
        {
            currentRotateComponent = circle.GetComponent<Rotate>();
            if (currentRotateComponent != null)
            {
                currentRotateComponent.enabled = false; // Ensure it's initially disabled
            }
        }
    }
}
