using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Attractable : MonoBehaviour
{
    [SerializeField] private bool rotateToCenter = true;
    [SerializeField] public Attractor currentAttractor;
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
        rigdibody.gravityScale = 0;

    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     m_rigdibody.velocity = Vector2.up * flapStrength;
        // }
        if (currentAttractor != null)
        {
            if (!currentAttractor.AttractedObjects.Contains(GetComponent<Collider2D>()))
            {
                Debug.LogError("Remove currentAttractor");
                currentAttractor = null;
                // transform.SetParent(null, true);
                return;
            }
            if (rotateToCenter) RotateToCenter();
            //rigdibody.gravityScale = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // 计算从当前物体到引力源的方向
                Vector3 direction = currentAttractor.transform.position - transform.position;
                // 归一化方向向量，使其长度为1
                direction.Normalize();
                Debug.Log($"Jump!!!");
                //rigdibody.velocity = new Vector2(rigdibody.velocity.x, jumpSpeed);

                // 改了这里。
                rigdibody.velocity = new Vector2(direction.x, direction.y) * -1f * jumpSpeed;
                //rigdibody.AddForce(new Vector2(direction.x, direction.y) * -1f * jumpSpeed, ForceMode2D.Impulse);
            }

        }
        else
        {
            //rigdibody.gravityScale = 1;
        }
    }

    // 改了这里。
    void FixedUpdate()
    {
        if (currentAttractor != null)
        {
            // 计算从当前物体到引力源的方向
            Vector3 direction = currentAttractor.transform.position - transform.position;
            // 归一化方向向量，使其长度为1
            direction.Normalize();
            // 应用吸引力
            UnityEngine.Physics2D.gravity = direction;
            rigdibody.gravityScale = 1;
        }
        else
        {
            rigdibody.gravityScale = 0;
        }
    }



    public void Attract(Attractor attractorObj)
    {
        //Vector2 attractionDir = ((Vector2)attractorObj.attractorTransform.position - rigdibody.position).normalized;
        //rigdibody.AddForce(attractionDir.normalized * -attractorObj.gravity * gravityStrength * Time.fixedDeltaTime);

        if (currentAttractor == null)
        {
            Debug.LogError("Add currentAttractor");
            currentAttractor = attractorObj;
            rigdibody.velocity = Vector2.zero;
            transform.SetParent(currentAttractor.transform, true);
        }

        if(currentAttractor.tag =="Win"){
            SceneManager.LoadScene("WinResult");
        }
    }

    void RotateToCenter() //圍著中心轉
    {
        //if (currentAttractor != null)
        //{
        //    //Vector2 distanceVector = (Vector2)currentAttractor.attractorTransform.position - (Vector2)transform.position;
        //    //float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        //    //transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        //    currentAttractor.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 10));

        //    // rigdibody.velocity = Vector2.up * flapStrength;   
        //    // rigdibody.velocity = new Vector2(distanceVector.x, distanceVector.y) * flapStrength;
        //}
    }
}
