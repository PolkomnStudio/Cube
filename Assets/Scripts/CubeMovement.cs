using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeMovement : MonoBehaviour
{
    public float Speed;
    public float Distance;

    private Transform respawnPoint;

    private Rigidbody Rb;
    private bool isGround;
    
    

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        respawnPoint = GameObject.Find("RespawnPoint").GetComponent<Transform>();
        
    }

    void Update()
    {
        if (isGround)
        {
            Move();
            CheckDistance();
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (other.CompareTag("Untagged"))
        {
            isGround = false;
        }

    }
    private void Move()
    {
        Rb.AddForce(transform.forward * Speed, ForceMode.Force);
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(gameObject.transform.position, respawnPoint.position);

        if ((distance > Distance) && (Distance != 0))
        {
            DestroyCube();
        }
    }
    private void DestroyCube()
    {
        Destroy(gameObject);
    }
}
