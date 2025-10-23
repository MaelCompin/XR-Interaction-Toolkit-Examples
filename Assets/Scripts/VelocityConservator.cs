using System;
using System.Drawing.Text;
using UnityEngine;

public class VelocityConservator : MonoBehaviour
{
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_rb.angularVelocity.magnitude);
    }
}
