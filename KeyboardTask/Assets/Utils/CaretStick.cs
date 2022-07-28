using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(InputField))]
public class CaretStick : MonoBehaviour/*, ISelectHandler*/
{
    private bool alreadyFixed;
    public float up;
    public float right;

    public void OnSelect()
    {
        if (alreadyFixed)
            return;

        alreadyFixed = true;

        string nm = gameObject.name + "Input Caret";
        RectTransform caretRT = (RectTransform)transform.Find(nm);

        Vector2 anchorPosition = caretRT.anchoredPosition;

        // //$ //$Debug.Log("here's the ap .. " +anchorPosition);

        anchorPosition.y = anchorPosition.y + up;
        anchorPosition.x = anchorPosition.x + right;

        caretRT.anchoredPosition = anchorPosition;

        // //$ //$Debug.Log("    here's a somewhat better ap .. " +anchorPosition);
    }
}
