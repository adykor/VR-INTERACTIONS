using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public string gripInputName;
    public string triggerInputName;

    private Grabbable touchedObject;
    private Grabbable grabbedObject;

    void Update()
    {
        // If the grip button is pressed
        if (Input.GetButtonDown(gripInputName))
        {
            // Play the gripped animation
            GetComponent<Animator>().SetBool("Gripped", true);

            // If we're touching something 
            if(touchedObject != null)
            {
                // Let the touched object know it has been grabbed
                touchedObject = OnGrab(this);

                // Store the new grabbed object
                grabbedObject = touchedObject;
            }
        }

        // If the grip button is released
        if (Input.GetButtonUp(gripInputName))
        {
            // Stop playing the gripped animation
            GetComponent<Animator>().SetBool("Gripped", false);

            // If we have a grabbed object
            if(grabbedObject != null)
            {
                // Let the grabbed object know it's been dropped
                grabbedObject.OnDrop();

                // Reset the grabbed object
                grabbedObject = null;
            }
        }

        // If the grip button is pressed
        if (Input.GetButtonDown(triggerInputName))
        {
            // If we have a grabbed object
            if (grabbedObject != null)
            {
                // Let the grabbed object know it has been triggered
                grabbedObject.OnTriggerStart();
            }
        }

        // If the grip button is released
        if (Input.GetButtonUp(triggerInputName))
        {
            // If we have a grabbed object
            if (grabbedObject != null)
            {
                // Let the grabbed object know it has stopped being triggered
                grabbedObject.OnTriggerEnd();
            }
        }
    }

    private Grabbable OnGrab(Grabber grabber)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Can make decisions based on just the presence of a component ***
        // Check if the object we touched is a grabable object
        Grabbable grabable = other.GetComponent<Grabbable>();
        if (grabable != null)
        {
            // Let the object know it was touched
            grabable.OnTouched();

            // Store the currently touched object
            touchedObject = grabable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object we stopped touching is a grabable object
        Grabbable grabable = other.GetComponent<Grabbable>();
        if (grabable != null)
        {
            // Let the object know it is no longer being touched
            grabable.OnUntouched();

            // TODO: This will need more work when we have lots of objects close together***
            // Reset the currently touched object
            touchedObject = null;
        }
    }
}