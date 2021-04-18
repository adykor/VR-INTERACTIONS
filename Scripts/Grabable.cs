using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    public Color touchedColor;
    public Color initialColor;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Store the initial color of the object
        initialColor = GetComponent<Renderer>().material.color;

        // Store the rigid body of the object
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnTouched()
    {
        // Change the color of the object to the touched color
        GetComponent<Renderer>().material.color = touchedColor; 
    }

    public void OnUntouched()
    {
        // Change the color of the object back to the initial color
        GetComponent<Renderer>().material.color = initialColor;

    }

    public virtual void OnGrab (Grabber grabber)
    {
        // Child this object to the grabber
        transform.SetParent(grabber.transform);

        // Turn off physics
        // Was: GetComponent<Rigidbody>().useGravity = false;
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
    }

    public virtual void OnDrop()
    {
        // Unparent the object
        transform.SetParent(null);

        // Turn on physics
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
    }

    public virtual void OnTriggerStart()
    {
    }

    public virtual void OnTriggerEnd()
    {
    }

}
