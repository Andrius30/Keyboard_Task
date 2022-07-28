using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualKeyboard : MonoBehaviour
{
    public MyInputField InputField;
    public float timeToHold = 2f;
    public float updateRatio = .1f;

    [ReadOnly] public bool isHolding = false;
    [ReadOnly] public bool isSelected = false;

    InputKeys inputKeys;
    MoveLeft moveLeft;
    MoveRight moveRight;
    DeleteText deleteText;

    void Start()
    {
        inputKeys = new InputKeys(this);
        moveLeft = new MoveLeft(this);
        moveRight = new MoveRight(this);
        deleteText = new DeleteText(this);
    }
    void Update()
    {
        inputKeys.OnUpdate();
        moveLeft.OnUpdate();
        moveRight.OnUpdate();
        deleteText.OnUpdate();
    }

    #region Keys
    public void KeyPress(string c)
    {
        inputKeys.SetKeyClicked(c);
        if (!isSelected)
        {
            isSelected = true;
            InputFieldAndSelectObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
    }
    public void KeyLeft()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputFieldAndSelectObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
    }
    public void KeyRight()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputFieldAndSelectObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
    }
    public void KeyDelete()
    {
        if (!isSelected)
        {
            InputFieldAndSelectObject();
            isSelected = true;
        }
    }
    #endregion

    #region Exposed as editor functions
    /// <summary>
    /// Called when user click on on UI element with this function added at OnClick
    /// </summary>
    /// <param name="hold"></param>
    public void KeyHoldingWriteText(bool hold)
    {
        isHolding = hold;
        if (!hold)
        {
            inputKeys.WriteText();
            inputKeys.holdTimer.SetTimer(0, true); // stop timer
        }
        else
        {
            inputKeys.holdTimer.SetTimer(timeToHold, false);
        }
    }
    public void HoldingMoveLeft(bool hold)
    {
        //count++;
        isHolding = hold;
        if (!hold)
        {
            moveLeft.OnMoveLeft();
            moveLeft.holdTimer.SetTimer(0, true); // stop timer
        }
        else
        {
            moveLeft.holdTimer.SetTimer(timeToHold, false);
        }
    }
    public void HoldingMoveRight(bool hold)
    {
        //count++;
        isHolding = hold;
        if (!hold)
        {
            moveRight.OnMoveRight();
            moveRight.holdTimer.SetTimer(0, true); // stop timer
        }
        else
        {
            moveRight.holdTimer.SetTimer(timeToHold, false);
        }
    }
    public void HoldingBackSpace(bool hold)
    {
        //count++;
        isHolding = hold;
        if (!hold)
        {
            deleteText.OnDelete();
            deleteText.holdTimer.SetTimer(0, true); // stop timer
        }
        else
        {
            deleteText.holdTimer.SetTimer(timeToHold, false);
        }
    }
    #endregion

    public void KeyDeselect() // [TEST] because I didn't knew for which device this task is i decided to add this button just to test what's happening after deselection
    {
        FocusInputField();
        isSelected = false;
        InputField.hasSelection = false;
        InputField.OnDeselect(null);
        isHolding = false;
    }
    public void InputFieldAndSelectObject()
    {
        FocusInputField();
        InputField.FocusObject();
    }

    void FocusInputField() => EventSystem.current.SetSelectedGameObject(gameObject);
}
