using UnityEngine;

public class VirtualKeyboard : MonoBehaviour
{

    public MyInputField InputField;

    public void KeyPress(string c)
    {
        InputField.FocusObject();
        InputField.DeleteSelectedText();
        InputField.text += c;
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyLeft()
    {
        InputField.FocusObject();
        InputField.OnValueChanged();
        InputField.DecreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyRight()
    {
        InputField.FocusObject();
        InputField.OnValueChanged();
        InputField.IncreaseCaretPosition();
        InputField.OnValueChanged();
    }

    public void KeyDelete() => InputField.DeleteSymbol();

}
