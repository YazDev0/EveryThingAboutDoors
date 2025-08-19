using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anima : MonoBehaviour
{

    public Rigidbody rb;
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        anim.SetFloat("H",x);
        anim.SetFloat("V",z);
        Vector3 move = new Vector3 (x,0,z);
        rb.MovePosition(transform.position+ move * 10 *Time.deltaTime);

    }
}
