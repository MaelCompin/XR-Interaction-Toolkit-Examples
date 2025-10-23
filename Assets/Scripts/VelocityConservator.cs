using System;
using System.Drawing.Text;
using UnityEngine;
using System.Collections.Generic;

public class VelocityConservator : MonoBehaviour
{
    private Rigidbody _rb;
    private float _newRb;
    public bool bIsDrop = false;
    private List<float> listOfVelocity;
    private int compteur = 0;
    private int lenghtList = 60;
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

    void EndConservation()
    {
        bIsDrop = true;
    }

    public float DuringSelect()
    {
        while (bIsDrop == false)
        {
            _newRb = _rb.angularVelocity.magnitude;
            if (listOfVelocity.Count < lenghtList+1)
            {
                listOfVelocity.Add(_newRb);
            }
            
            else 
            { 
                if (compteur < lenghtList)
                {
                    listOfVelocity[compteur] = _newRb;
                    compteur = +1;
                }
                else
                {
                    compteur = 0;
                    listOfVelocity[compteur] = _newRb;
                    compteur = +1;
                }
                    
            }
        }

        float hightVelo = 0;

        foreach (var velo in listOfVelocity) 
        { 
        if (velo >= hightVelo)
            {
                hightVelo = velo;
            }
        }
        return hightVelo;
    }
}
