using UnityEngine;

public class VirtualKeyboard : MonoBehaviour
{

    public MyInputField InputField;

    public void KeyPress(string c)
    {
        InputField.FocusObject();
        InputField.text += c;
        InputField.caretPosition++;
        InputField.OnValueChanged();
    }

    public void KeyLeft()
    {
        InputField.FocusObject();
        InputField.caretPosition--;
        InputField.OnValueChanged();
    }

    public void KeyRight()
    {
        InputField.FocusObject();
        InputField.caretPosition++;
        InputField.OnValueChanged();
    }

    public void KeyDelete() => InputField.Delete();

}
