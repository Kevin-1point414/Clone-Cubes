using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded = true;
    private new Collider2D collider;
    private GameObject cameraGameObject;
    [SerializeField] private float JumpPower;
    [SerializeField] private float PlayerPower;
    [SerializeField] private float PlayerPowerInAir;
    [SerializeField] private float MaxSpeed;

    void Start()
    {
        cameraGameObject = Camera.main.gameObject;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    
    void FixedUpdate()
    {
        if (!GetComponent<PlayerClone>().selected)
            return;

        List<ContactPoint2D> contacts = new();
        collider.GetContacts(contacts);

        grounded = false;
        int cournersTouching = 0;
        foreach(ContactPoint2D contact in contacts)
        {
            if (contact.point.y < transform.position.y
                && contact.point.x < transform.position.x + 0.5f * transform.localScale.x
                && contact.point.x > transform.position.x - 0.5f * transform.localScale.x)
            {
                grounded = true;
            }
            if (contact.point.y < transform.position.y
                && contact.point.x <= transform.position.x + 0.5f * transform.localScale.x + 0.01f
                && contact.point.x >= transform.position.x - 0.5f * transform.localScale.x - 0.01f)
            {
                cournersTouching++;
            }
        }
        if (cournersTouching >= 2)
        {
            grounded = true;
        }

        cameraGameObject.transform.position = new Vector3(transform.position.x, transform.position.y
            ,cameraGameObject.transform.position.z);
        if ((Input.GetAxis("Vertical") > 0.3 || Input.GetKey(KeyCode.Space)) && grounded
            && rb.velocity.y < 0.1f) 
        {
            rb.AddForce(new Vector2(0, JumpPower));
        }
        float power;
        if (grounded)
        {
            power = PlayerPower;
        }
        else
        {
            power = PlayerPowerInAir;
        }
        if (MaxSpeed >= Mathf.Abs(rb.velocity.x))
        {
            rb.AddForce(new Vector2(power * Input.GetAxis("Horizontal")
                * Mathf.Max(Mathf.Min(MaxSpeed - Mathf.Abs(rb.velocity.x), 1), -1), 0));
        }
    }
}
