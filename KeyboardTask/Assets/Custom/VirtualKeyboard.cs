using Andrius.Utils.Timers;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualKeyboard : MonoBehaviour
{
    public MyInputField InputField;
    public float timeToHold = 2f;

    [SerializeField] float updateRatio = .1f;
    [SerializeField] float delayOnReleaseButton = .3f;
    [ReadOnly, SerializeField] string lastClickedKey;

    [ReadOnly] public bool isHolding = false;
    [ReadOnly] public bool isSelected = false;
    // bool isRoutineRunning = false;

    //Timer holdTimer;
    WaitForSeconds wait;
    InputKeys inputKeys;

    void Start()
    {
        wait = new WaitForSeconds(updateRatio);
        // holdTimer = new Timer(0, OnHoldTimeOut, false, true);
        inputKeys = new InputKeys(this);
    }
    void Update()
    {
        inputKeys.OnUpdate();
        //if (holdTimer.IsDone()) return;
        //holdTimer.StartTimer();
    }

    public void KeyPress(string c)
    {
        lastClickedKey = c;
        if (!isSelected)
        {
            isSelected = true;
            InputFieldAndSelectObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
    }
    /// <summary>
    /// Called when user click on on UI element with this function added at OnClick
    /// </summary>
    /// <param name="hold"></param>
    public void HoldingToTypeText(bool hold)
    {
        //count++;
        isHolding = hold;
        if (!hold)
        {
            inputKeys.WriteText(lastClickedKey);
            inputKeys.holdTimer.SetTimer(0, true); // stop timer
        }
        else
        {
            inputKeys.holdTimer.SetTimer(timeToHold, false);
        }
    }
    #region Keys
    public void KeyLeft()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputFieldAndSelectObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
        MoveLeft();
    }
    public void KeyRight()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputFieldAndSelectObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
        MoveRight();
    }
    public void KeyDeselect() // [TEST] because I didn't knew for which device this task is i decided to add this button just to test what's happening after deselection
    {
        FocusInputField();
        isSelected = false;
        InputField.hasSelection = false;
        InputField.OnDeselect(null);
        isHolding = false;
    }
    public void KeyDelete()
    {
        if (!isSelected)
        {
            InputFieldAndSelectObject();
            isSelected = true;
        }
        InputField.DeleteSymbol();
    }

    void MoveLeft()
    {
        InputField.OnValueChanged();
        InputField.DecreaseCaretPosition();
        InputField.OnValueChanged();
    }
    void MoveRight()
    {
        InputField.OnValueChanged();
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();
    }
    #endregion

    /// <summary>
    /// Focus input Field for EventTrigger
    /// </summary>
    public void FocusInputField() => EventSystem.current.SetSelectedGameObject(gameObject);
    public void InputFieldAndSelectObject()
    {
        FocusInputField();
        InputField.FocusObject();
    }

}

public class MoveLeft
{
    public Timer holdTimer;
    VirtualKeyboard keyboard;
    WaitForSeconds wait;
    bool isRoutineRunning = false;

    public MoveLeft(VirtualKeyboard keyboard)
    {
        this.keyboard = keyboard;
        holdTimer = new Timer(0, OnHoldTimeOut, false, true);
    }

    public void OnUpdate()
    {
        if (holdTimer.IsDone()) return;
        holdTimer.StartTimer();
    }
    void OnHoldTimeOut() // Called when hold timer is done time <= 0;
    {
        if (keyboard.isHolding)
        {
            // TODO: Apply for this class
           // keyboard.StartCoroutine(HoldWriteSymbolsRoultine());
        }
    }
}
