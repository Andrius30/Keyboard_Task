using System.Collections;
using UnityEngine;

// The challenge is to create a new class that will implement the InputField.
// The new extended class (MyInputField) should make the InputField work with the UI buttons in the same way as manual input does.
public class MyInputField : InputFieldOriginal
{

    public void DeleteSymbol()
    {
        FocusObject();
        OnValueChanged();
        caretPosition = text.Length - 1;
        ShowCaret();
        if (text.Length - 1 >= 0)
        {
            m_Text = text.Remove(caretPosition, 1);
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
    }
    public void DecreaseCaretPosition()
    {
        FocusObject();
        ShowCaret();
        caretPosition--;
        Debug.Log($"[DECREACE] {caretPosition}");
        OnValueChanged();
    }
    public void IncreaseCaretPosition()
    {
        FocusObject();
        ShowCaret();
        caretPosition++;
        Debug.Log($"[INCREACE] {caretPosition}");
        OnValueChanged();
    }
    /// <summary>
    /// Show caret on focused
    /// </summary>
    public void ShowCaret()
    {
        m_AllowInput = true;
        m_CaretVisible = true;
    }



}