using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnife : MonoBehaviour
{
    [Header("Stats")]
    public float rollSpeed = 5f;
    public float hopSpeed = 2f;
    public Vector3 hopDirection;

    [Header("Handle nockback")]
    public float knockbackForce = 150f;
    public float knockbackTorque = 100f;

    [Header("Knife Parts")]
    public Collider handleCollider;
    public Collider bladeCollider;
    public Transform centerOfMass;

    [Header("Physics")]
    public float frontAngularDrag = 2f;
    public float backAngularDrag = 2f;

    Rigidbody body;
    private bool stuck; // When knife blade is stucked into an object
    private bool active = false;

    private GameplayController gameplay;
    public bool Active { get => active; set => active = value; }


    void Start()
    {
        if (!body) body = GetComponent<Rigidbody>();
        gameplay = GameObject.FindWithTag("GameController").GetComponent<GameplayController>();
    }

    void FixedUpdate()
    {
        body.angularVelocity = new Vector3(0, 0, body.angularVelocity.z);

        if (stuck)
        {
            body.useGravity = false;
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
        else
        {
            body.useGravity = true;
        }

        // Apply a higher drag if blade of knife is pointing to forward (X axis)
        body.angularDrag = transform.up.x > 0.71 ? frontAngularDrag : backAngularDrag;
    }

    public void PerformHop()
    {
        gameplay.OnPlayerInteraction();
        if (!Active) return;

        if (body)
        {
            body.velocity = hopDirection.normalized * hopSpeed;
            body.angularVelocity = new Vector3(0, 0, -rollSpeed);
            stuck = false;

            SendMessage("OnKnifeMove");
        }
    }

    public void Stuck()
    {
        body.Sleep();
        stuck = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.contacts[0].thisCollider == bladeCollider)
        {
            // Colliding with blade
            Stuck();
        }
        else
        {
            // Colliding with handle
            stuck = false;
            body.AddForce(other.contacts[0].normal * knockbackForce);
            body.AddTorque(knockbackTorque, 0f, 0f);
        }
    }

}
