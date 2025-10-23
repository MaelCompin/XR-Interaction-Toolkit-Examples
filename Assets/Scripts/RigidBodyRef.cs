using System;
using UnityEngine;

public class RigidBodyRef : MonoBehaviour
{
    private Rigidbody _rb;
    private Func<float> velocityConservator;
    private float newRB;
    void endGrab()
    {
        _rb = GetComponent<Rigidbody>();
        velocityConservator = GameObject.Find("Balle").GetComponent<VelocityConservator>().DuringSelect;
        newRB = velocityConservator();
        _rb.angularVelocity *= newRB; 

    }
}
