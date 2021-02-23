using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubecontroller : MonoBehaviour
{
    [SerializeField] public LayerMask groundMask;
    public float moveForce;

    private Rigidbody rb;
    private new AudioSource audio;

    private bool pressUp;
    private bool pressDown;
    private bool pressLeft;
    private bool pressRight;
    private bool pressJump;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) pressUp = true; else pressUp = false;
        if (Input.GetKey(KeyCode.S)) pressDown = true; else pressDown = false;
        if (Input.GetKey(KeyCode.A)) pressLeft = true; else pressLeft = false;
        if (Input.GetKey(KeyCode.D)) pressRight = true; else pressRight = false;
        if (Input.GetKeyDown(KeyCode.Space)) pressJump = true;
    }

    private void FixedUpdate()
    {
        if (pressUp) { rb.angularVelocity += new Vector3(100, 0, 0); rb.AddForce(new Vector3(0, 0, moveForce)); }
        if (pressDown) { rb.angularVelocity += new Vector3(-100, 0, 0); rb.AddForce(new Vector3(0, 0, -moveForce)); }
        if (pressLeft) { rb.angularVelocity += new Vector3(0, 0, 100); rb.AddForce(new Vector3(-moveForce, 0, 0)); }
        if (pressRight) { rb.angularVelocity += new Vector3(0, 0, -100); rb.AddForce(new Vector3(moveForce, 0, 0)); }
        if (pressJump) Jump();
    }

    void Jump()
    {
        pressJump = false;
        if (CheckGrounded(1f)) rb.AddForce(Vector3.up * 500f);
        
    }

    private bool CheckGrounded(float reach = 0.05f)
    {
        //return if the player is on the ground
        //reach variable (default 0.05) is how far the 
        if (Physics.Raycast(transform.position, -Vector3.up, (0.5f + reach), groundMask)) return true;
        else return false;
    }
}
