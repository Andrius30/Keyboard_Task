using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualKeyboard : MonoBehaviour
{
    public MyInputField InputField;
    bool isSelected = false;

    public void KeyPress(string c)
    {
        if (!isSelected)
        {
            isSelected = true;
            InputField.FocusObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
        InputField.OnValueChanged();
        InputField.DeleteSelectedText(); // no working
        string value = InputField.text.Insert(InputField.caretPosition, c);
        InputField.text = value;
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();

    }

    public void KeyLeft()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputField.FocusObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
        InputField.OnValueChanged();
        InputField.DecreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyRight()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputField.FocusObject();
            InputField.MoveTextEnd(true); // on selection move caret at the end of text
        }
        InputField.OnValueChanged();
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyDeselect() // [TEST] because I didn't knew for which device this task is i decided to add this button just to test what's happening after deselection
    {
        isSelected = false;
        InputField.hasSelection = false;
        InputField.OnDeselect(null);
    }

    public void KeyDelete()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputField.FocusObject();
        }
        InputField.DeleteSymbol();
    }

}
