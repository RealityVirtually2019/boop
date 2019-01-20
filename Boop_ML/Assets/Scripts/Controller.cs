<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Controller : MonoBehaviour {

    MLInputController _controller;
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
        transform.position = _controller.Position;
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Controller : MonoBehaviour {

    MLInputController _controller;
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
        transform.position = _controller.Position;
	}
}
>>>>>>> 9b189e3074a19b8dd7ccfbbf9fc2ef617e555f62
