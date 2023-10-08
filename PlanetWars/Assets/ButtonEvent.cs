using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public int intValue;
    public float floatValue;
    
    public delegate void ButtonPressed();

    public event ButtonPressed ButtonPressedEvent;

    public void Pressed()
    {
        ButtonPressedEvent();
    }

    public delegate void ButtonPressedIntValue(int Value);

    public event ButtonPressedIntValue ButtonPressedIntValueEvent;
    
    public void PressedIntValue()
    {
        ButtonPressedIntValueEvent(intValue);
    }
    
    public delegate void ButtonPressedFloatValue(float Value);

    public event ButtonPressedFloatValue ButtonPressedFloatValueEvent;
    
    public void PressedFloatValue()
    {
        ButtonPressedFloatValueEvent(floatValue);
    }
}
