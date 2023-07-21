using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLoading : MonoBehaviour
{
    [TextArea(2, 6)]
    public string[] ArrayText;
    public int TextNumber;
    public TextMeshProUGUI Text;

    public void TextChange()
    {
        TextNumber = Random.Range(0, ArrayText.Length) +1;

        Text.text = ArrayText[TextNumber].ToString();
    }
}
