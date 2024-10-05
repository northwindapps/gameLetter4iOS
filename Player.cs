using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private float movespeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Optionally initialize anything here
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Use the correct property name 'velocity' instead of 'valocity'
        rigidbody.velocity = new Vector3(joystick.Horizontal * movespeed, rigidbody.velocity.y, joystick.Vertical * movespeed);
    }
}
