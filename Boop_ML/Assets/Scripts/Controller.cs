using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Controller : MonoBehaviour {

    MLInputController _controller;
    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;

	// Use this for initialization
	void Start () {
        MLInput.Start();

        _controller = MLInput.GetController(MLInput.Hand.Left);
	}

    void OnDestroy()
    {
        MLInput.Stop();

    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(_controller.Position.x - offsetX, _controller.Position.y + offsetY, _controller.Position.z + offsetZ);
        transform.localRotation = Quaternion.Euler(_controller.Orientation.eulerAngles);
	}
}
