using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float timeLeft = 30;
    
    bool haskey = false;
    public string nextLevel;

    public GameObject bullet;


    Rigidbody rb;

    //public GameObject bulletPrefab;
    //public Transform firePoint;



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
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (haskey == true && Input.GetKeyDown(KeyCode.F))
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
