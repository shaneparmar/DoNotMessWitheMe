using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    bool haskey = false;
    public string nextLevel;

    public GameObject bullet;


    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            haskey = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Terrorist"))
        {
            haskey = true;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
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
}
