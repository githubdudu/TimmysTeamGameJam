using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public LayerMask AttractionLayer;
    public float gravity = -10;
    [SerializeField] private float Radius = 10;
    public List<Collider2D> AttractedObjects = new List<Collider2D>();
    [HideInInspector] public Transform attractorTransform;

    void Awake()
    {
        attractorTransform = GetComponent<Transform>();
    }

    void Update()
    {
        SetAttractedObjects();
    }

    void FixedUpdate()
    {
        RotateToCenter();
        AttractObjects();
    }

    void SetAttractedObjects()
    {
        AttractedObjects = Physics2D.OverlapCircleAll(attractorTransform.position, Radius + 3, AttractionLayer).ToList();
    }

    void AttractObjects()
    {
        for (int i = 0; i < AttractedObjects.Count; i++)
        {
            Attractable attractable = AttractedObjects[i].GetComponent<Attractable>();
            if (attractable.currentAttractor == null)
            {
                attractable.Attract(this);
            }
        }
    }

    void RotateToCenter() //������ת
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 30));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
