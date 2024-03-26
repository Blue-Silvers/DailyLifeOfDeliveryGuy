using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivraisonCarMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float horizontalSpeed;

    bool isRunning = false;
    private Vector2 input;
    [SerializeField] Rigidbody rigidbody;

    private bool isGrounded = true;

    [SerializeField] GameObject player;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        else
        {
            speed = walkSpeed;
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(player, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {


        Vector3 desireRotation = new Vector3(0, input.x * horizontalSpeed * Time.deltaTime, 0);
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(desireRotation));


        Vector3 movement = new Vector3(transform.forward.x * input.y * speed * Time.deltaTime, 0, transform.forward.z * input.y * speed * Time.deltaTime);
        rigidbody.MovePosition(transform.position + movement);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
}
