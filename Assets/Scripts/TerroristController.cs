using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerroristController : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    public float moveSpeed = 2f; // Adjust the speed as needed
    private Transform target; // Target position to move towards

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        // Check if the player GameObject is found
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = player.transform.position;
        // Check if the target is assigned
        if (target != null)
        {
            // Get the direction to the player
            Vector3 direction = target.position - transform.position;

            // Check if the direction vector is not zero
            if (direction.magnitude > 0.001f) // Adjust the threshold as needed
            {
                // Calculate the new position with Y set to the ground level
                Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

                // Move towards the player's position (keeping Y grounded)
                transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);

                // Rotate towards the player
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = rotation;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            count++;

            if (count == 5)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
            }
        }
    }

}