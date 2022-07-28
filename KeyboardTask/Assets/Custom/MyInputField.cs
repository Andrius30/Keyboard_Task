
// The challenge is to create a new class that will implement the InputField.
// The new extended class (MyInputField) should make the InputField work with the UI buttons in the same way as manual input does.
public class MyInputField : InputFieldOriginal
{

    public void DeleteSymbol()
    {
        OnValueChanged();
        caretPosition = caretPositionInternal - 1;
        ShowCaret();
        if (text.Length - 1 >= 0)
        {
            m_Text = text.Remove(caretPositionInternal, 1);
            OnValueChanged();
        }
    }

    // TODO: Focus should remain on the input field when the user interface buttons are pressed. 
    // TODO: Caret must remain in last position

    public void OnValueChanged() => SendOnValueChangedAndUpdateLabel();
    public void FocusObject() => SelectAll();
    public void DeleteSelectedText()
    {
        // Delete();
        // TODO: Get select text and remove count
        //m_Text = text.Remove(caretPosition);
    }
    public void DecreaseCaretPosition()
    {
        ShowCaret();
        caretPosition--;
        OnValueChanged();
    }
    public void IncreaseCaretPosition()
    {
        ShowCaret();
        caretPosition++;
        OnValueChanged();
    }
    /// <summary>
    /// Show caret on focused
    /// </summary>
    public void ShowCaret()
    {
        // 
        m_AllowInput = true;
        m_CaretVisible = true;
    }

}