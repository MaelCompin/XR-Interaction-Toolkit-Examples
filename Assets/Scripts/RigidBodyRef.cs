using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class RigidBodyRef : MonoBehaviour
{
    private Rigidbody _rb;
    private Func<float> velocityConservator;
    private float newRB;
    public void endGrab()
    {
        _rb = GetComponent<Rigidbody>();
        velocityConservator = GameObject.Find("Balle").GetComponent<VelocityConservator>().DuringSelect;
        newRB = velocityConservator();
        _rb.angularVelocity *= newRB;
        Debug.Log("Ça marche ? " + newRB);

    }
 



  //  void OnInteractorSelectEntered(SelectEnterEventArgs args)
   // {
        // Example of casting args objects to interactor and interactable base classes
      //  var interactor = args.interactorObject as XRBaseInteractor;
      //  var interactable = args.interactableObject as XRBaseInteractable;

        // Logic for select enter event goes here
     //   Debug.Log(args.interactorObject.transform.name + " began selecting " + args.interactableObject.transform.name, this);
 //   } 
}
