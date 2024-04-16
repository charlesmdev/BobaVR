using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool _deadTimeActive = false;
    private bool _buttonPressed = false;
    public UnityEvent onPressed, onReleased;
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActive)
        {
            _buttonPressed = true;
            onPressed?.Invoke();
            Debug.LogWarning("Button Pressed" + _buttonPressed);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActive && !_buttonPressed)
        {
            _buttonPressed = true;
            onPressed?.Invoke();
            Debug.LogWarning("Button Pressed Stay");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _buttonPressed = false;
        if (other.tag == "Button" && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.LogWarning("Button Released" + _buttonPressed);
            StartCoroutine(WaitForDeadTime());
        }
    }
    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }
}
