using UnityEngine;

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
        }
        InputField.DeleteSelectedText(); // no working
        InputField.text += c;
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyLeft()
    {
        if (!isSelected)
        {
            isSelected = true;
            InputField.FocusObject();
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
        }
        InputField.OnValueChanged();
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyDeselect()
    {
        isSelected = false;
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
