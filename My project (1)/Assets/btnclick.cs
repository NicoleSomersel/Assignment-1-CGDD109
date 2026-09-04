using TMPro;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public TextMeshProUGUI textbox;

    private string tempString;

    public void ButtonClickMethod(){
        textbox.text = "I have changed";
    }
}