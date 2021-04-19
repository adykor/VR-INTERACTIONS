using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsSlider : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float value;

    public UnityEvent onValueChanged;
    private float prevValue;

    // Update is called once per frame
    void Update()
    {
        // Calculate how far along the slider is as a percentage (0 to 1)
        value = (transform.localPosition.x - minX) / (maxX - minX);
        value = Mathf.Clamp(value, 0f, 1f);

        // If the value changed
        if (value != prevValue)
        {
            onValueChanged.Invoke();
            prevValue = value;
        }
    }
}
