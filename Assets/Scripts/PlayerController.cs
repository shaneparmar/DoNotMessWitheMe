using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables for movement speed
    public float walkSpeed = 5f;
    public float runSpeed = 7f;

    // Animator component reference
    private Animator animator;

    public GameObject bullet;

    bool haskey = false;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Set the movement vector based on input and speed
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Normalize movement vector to ensure consistent speed in all directions
        movement.Normalize();

        // Check if player is moving (magnitude greater than 0)
        bool isMoving = movement.magnitude > 0;

        // Set animator parameters based on player's movement
        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("Speed", isMoving ? 1 : 0);

        // Move the player based on input and speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Run
            transform.Translate(movement * runSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // Walk
            transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }

    void Fire()
    {
        var pos = transform.position + (transform.forward * 2);
        var rot = transform.rotation;
        Instantiate(bullet, pos, rot);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            haskey = true;
            Destroy(other.gameObject);
        }
    }
}

