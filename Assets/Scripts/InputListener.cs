using System;
using UnityEngine;
using UnityEngine.UI;

public class InputListener : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public void TestOnValueChanged()
    {
        print($"From change{inputField.text}");
    }
    
    public void TestOnValueEdit()
    {
        print($"On Edit {inputField.text}");
    }

    private void Start()
    {
        inputField.onValueChanged.AddListener(delegate(string str)
        {
            print($"From code change {str}");
        });
        
        inputField.onEndEdit.AddListener(delegate(string str)
        {
            print($"From code end event {str}");
        });
    }
}
