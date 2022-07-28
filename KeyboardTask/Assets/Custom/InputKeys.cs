using Andrius.Utils.Timers;
using System.Collections;
using UnityEngine;

public class InputKeys
{
    public Timer holdTimer;

    string lastClickedKey;
    VirtualKeyboard keyboard;
    WaitForSeconds wait;
    bool isRoutineRunning = false;

    public InputKeys(VirtualKeyboard keyboard)
    {
        this.keyboard = keyboard;
        holdTimer = new Timer(0, OnHoldTimeOut, false, true);
    }

    public void OnUpdate()
    {
        if (holdTimer.IsDone()) return;
        holdTimer.StartTimer();
    }
    public void WriteText(string c)
    {
        keyboard.InputField.OnValueChanged();
        keyboard.InputField.DeleteSelectedText(); // no working
        string value = keyboard.InputField.text.Insert(keyboard.InputField.caretPosition, c);
        keyboard.InputField.text = value;
        keyboard.InputField.IncreaseCaretPosition();
        keyboard.InputField.OnValueChanged();
    }
    public void SetKeyClicked(string symbol) => lastClickedKey = symbol;

    void OnHoldTimeOut() // Called when hold timer is done time <= 0;
    {
        if (keyboard.isHolding)
        {
            keyboard.StartCoroutine(HoldWriteSymbolsRoultine());
        }
    }
    IEnumerator HoldWriteSymbolsRoultine()
    {
        if (isRoutineRunning) yield break;
        isRoutineRunning = true;
        while (keyboard.isHolding)
        {
            WriteText(lastClickedKey);
            yield return wait;
        }
        isRoutineRunning = false;
        yield break;
    }

}