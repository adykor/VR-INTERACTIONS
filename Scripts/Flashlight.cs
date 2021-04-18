using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Grabable
{
    public Light light;

    protected override void Start()
    {
        base.Start();

        light.enabled = false;
    }
    public override void OnTriggerStart()
    {
        light.enabled = true;
        // What auto populates; be aware for methods that aren't empty
        // base.OnTriggerStart();
    }

    public override void OnTriggerEnd()
    {
        light.enabled = false;
        // What auto populates; be aware for methods that aren't empty
        // base.OnTriggerEnd();
    }
}