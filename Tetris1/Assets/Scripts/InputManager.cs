using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float HorizontalValue { get; private set; }
    public bool UpButtonPressed { get; private set; }
    public bool DownButtonPressed { get; private set; }

    private void Awake()
    {
        HorizontalValue = 0f;
        UpButtonPressed = false;
        DownButtonPressed = false;
    }

    private void Update()
    {
        HorizontalValue = Input.GetAxisRaw("Horizontal");
        UpButtonPressed = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        DownButtonPressed = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
    }
}
