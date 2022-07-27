using UnityEngine;

public class VirtualKeyboard : MonoBehaviour
{

    public MyInputField InputField;

    public void KeyPress(string c)
    {
        InputField.OnSelect(null);
        InputField.text += c;
        InputField.caretPosition++;
        InputField.OnValueChanged();
    }

    public void KeyLeft()
    {
        InputField.OnSelect(null);
        InputField.caretPosition--;
        InputField.OnValueChanged();
    }

    public void KeyRight()
    {
        InputField.OnSelect(null);
        InputField.caretPosition++;
        InputField.OnValueChanged();
    }

    public void KeyDelete() => InputField.Delete();

}
