using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float amplitude = 1f; // The height of the oscillation
    public float frequency = 5000f; // The speed of the oscillation
    [HideInInspector] public GameObject parentCircle;
    [HideInInspector] public bool hasTriggered = false;

    private Vector3 startPosition;

    public GameObject child;

    public Transform parent;

    //For juming game
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    void Start()
    {
        // Record the starting position of the ball
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        // if (Input.GetButtonDown("Jump"))
        // {
        //     player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        // }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Jump!!!");
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        // Debug.LogError($"newY={newY}");
        // Update the ball's position
        // OnTriggerEnter();
        //         if (Input.GetKeyDown(KeyCode.Space))
        //         {
        //             amplitude = amplitude + 0.05f
        // ;
        //         }

    }

    // void CheckEdgeAndSwitch()
    // {
    //     if (parentCircle != null)
    //     {
    //         float distanceToParentCenter = Vector2.Distance(transform.position, parentCircle.transform.position);
    //         CircleCollider2D parentCollider = parentCircle.GetComponent<CircleCollider2D>();

    //         if (parentCollider != null)
    //         {
    //             float parentRadius = parentCollider.radius * parentCircle.transform.localScale.x;

    //             if (Mathf.Abs(distanceToParentCenter - parentRadius) < 0.1f)
    //             {
    //                 SwitchToLargerCircle();
    //             }
    //         }
    //     }
    // }

    // void SwitchToLargerCircle()
    // {
    //     Rotate parentCircleScript = parentCircle.GetComponent<Rotate>();
    //     if (parentCircleScript != null && parentCircleScript.largerCircle != null)
    //     {
    //         // Hide the current parent circle
    //         parentCircle.SetActive(false);

    //         // Set the larger circle as the new parent
    //         parentCircle = parentCircleScript.largerCircle;
    //         transform.SetParent(parentCircle.transform, false);

    //         // Make the new parent circle visible
    //         parentCircle.SetActive(true);

    //         Debug.Log($"Switched to larger circle: {parentCircle.name}");
    //     }
    // }
}