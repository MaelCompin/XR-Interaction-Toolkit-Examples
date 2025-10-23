using System;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class VelocityConservator : MonoBehaviour
{
    [SerializeField] XRBaseInteractor m_ExampleInteractor;
    private Rigidbody _rb;
    private float _newRb;
    public bool bIsDrop = false;
    private RigidBodyRef rbref;
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

    void EndConservation(SelectExitEventArgs args)
    {
        bIsDrop = true;
        rbref = GameObject.Find("Balle").GetComponent<RigidBodyRef>();
        rbref.endGrab();

    }

    void StartConservation(SelectEnterEventArgs args)
    {
        DuringSelect();
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


    void OnEnable()
    {
        if (m_ExampleInteractor != null)
        {
            m_ExampleInteractor.selectExited.AddListener(EndConservation);
            m_ExampleInteractor.selectEntered.AddListener(StartConservation);
            Debug.Log("Avant le test");
        }

    }

}
