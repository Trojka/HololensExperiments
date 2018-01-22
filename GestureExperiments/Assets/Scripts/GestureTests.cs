using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GestureTests : MonoBehaviour {

    GestureRecognizer _recognizer;
    bool _colorToggle = false;

    public GameObject cube;

	// Use this for initialization
	void Start () {
        _recognizer = new GestureRecognizer();

        _recognizer.SetRecognizableGestures(GestureSettings.Tap);
        _recognizer.Tapped += _recognizer_Tapped;

        _recognizer.StartCapturingGestures();

    }

    private void _recognizer_Tapped(TappedEventArgs obj)
    {
        if(_colorToggle)
        {
            cube.GetComponent<Renderer>().material.color = Color.red;
            _colorToggle = !_colorToggle;
        }
        else
        {
            cube.GetComponent<Renderer>().material.color = Color.blue;
            _colorToggle = !_colorToggle;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
