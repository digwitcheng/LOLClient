using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WarrningWindow : MonoBehaviour {

    [SerializeField]
    private Text text;
    Action result;
    public void Active(WarrningModel value) {
        text.text = value.Context;
        this.result = value.Result;
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
        if (result != null) {
            result();
        }
        
    }
}
