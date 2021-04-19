using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private HingeJoint hinge;
    public float onAngleThreshold;
    public float offAngleThreshold;
    private bool pushedForward;
    private bool pulledBackward;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }


    void Update()
    {
        // If the lever has been pushed fully forward (and it wasn't already)
        if (hinge.angle > onAngleThreshold && !pushedForward)
        {
            pushedForward = true;
            // Do something

        }
        // If the lever was pushed forward and isn't anymore
        if(hinge.angle < onAngleThreshold)
        {
            pushedForward = false;
        }

        // If the lever has been pulled fully backward (and it wasn't already)
        if (hinge.angle < offAngleThreshold && !pulledBackward)
        {
            pulledBackward = true;

            // Do something

        }
        // If the lever was pulled backward and isn't anymore
        if (hinge.angle > offAngleThreshold)
        {
            pulledBackward = false;
        }
    }
}
