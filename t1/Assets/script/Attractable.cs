using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractable : MonoBehaviour
{
    [SerializeField] private bool rotateToCenter = true;
    [SerializeField] private Attractor currentAttractor;
    [SerializeField] private float gravityStrength = 100;
    public float flapStrength; //每次跳的高度

    //For juming game
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    // private Rigidbody2D player;

    Transform transform;
    Collider2D collider;
    Rigidbody2D rigdibody;

    private void Start()
    {
        transform = GetComponent<Transform>();
        collider = GetComponent<Collider2D>();
        rigdibody = GetComponent<Rigidbody2D>();
        // rigdibody.velocity = new Vector3(1, 0, 1) * flapStrength;


    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     m_rigdibody.velocity = Vector2.up * flapStrength;
        // }
        if (currentAttractor != null)
        {
            if (!currentAttractor.AttractedObjects.Contains(collider))
            {
                currentAttractor = null;
                return;
            }
            if (rotateToCenter) RotateToCenter();
            rigdibody.gravityScale = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"Jump!!!");
                rigdibody.velocity = new Vector2(rigdibody.velocity.x, jumpSpeed);
            }

        }
        else
        {
            rigdibody.gravityScale = 1;
            
        }
    }

    public void Attract(Attractor attractorObj)
    {
        Vector2 attractionDir = ((Vector2)attractorObj.attractorTransform.position - rigdibody.position).normalized;
        rigdibody.AddForce(attractionDir.normalized * -attractorObj.gravity * gravityStrength * Time.fixedDeltaTime);

        if (currentAttractor == null)
        {
            currentAttractor = attractorObj;
        }

    }

    void RotateToCenter() //圍著中心轉
    {
        if (currentAttractor != null)
        {
            Vector2 distanceVector = (Vector2)currentAttractor.attractorTransform.position - (Vector2)transform.position;
            float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            // rigdibody.velocity = Vector2.up * flapStrength;   
            // rigdibody.velocity = new Vector2(distanceVector.x, distanceVector.y) * flapStrength;

        }
    }
}
