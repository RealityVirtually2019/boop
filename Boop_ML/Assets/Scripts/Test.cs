using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public DadyClient DC;
	// Use this for initialization
	void Start () {
        // Set test val
        DC.SetTransform(new Vector3(1, 1, 1), new Vector3(0, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
        //print("Type:" + DC.GetOutput());
        print("Transform:" + DC.GetInput());
	}
}
