using Mono.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // Start is called before the first frame update
    //public Transform gunPosition;
    public Transform gunPosition;
    public GameObject gunonGround;
    //public Transform player;
    public Rigidbody rb;
    public GameObject instruction;
    public bool equipped = true;
    public Transform fpsCam;
    
    void Start()
    {
        instruction.SetActive(false);

        if(!equipped)
        {
            Debug.Log("false");

            rb.isKinematic = false;

        }
        else if(equipped)
        {
            rb.isKinematic = true;
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            instruction.SetActive(true);
            
        }
    }

    void OnTriggerExit(Collider collision)
    {
        instruction.SetActive(false);
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if (equipped && Input.GetKeyDown(KeyCode.G))
        {
            Drop();
            
        }
       
    }

    public void Pickup()
    {
        //gunonGround.SetActive(false);
        rb.isKinematic = true;
        transform.SetParent(gunPosition);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
        equipped = true;
        instruction.SetActive(false);
    }

    public void Drop()
    {

        transform.SetParent(null);
            rb.isKinematic = false;
            rb.velocity = Vector3.one;
            rb.AddForce(fpsCam.forward * 1f, ForceMode.Impulse);
           rb.AddForce(fpsCam.up * 1f, ForceMode.Impulse);
        equipped = false;

        
    }
}
