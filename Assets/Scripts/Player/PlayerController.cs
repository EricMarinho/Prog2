using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 25.0f;
    public float horizontalInput;
    public float forwardInput;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        transform.Translate( new Vector3(horizontalInput, 0, forwardInput) * Time.deltaTime * speed);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput) + Mathf.Abs(forwardInput));
    }

}
