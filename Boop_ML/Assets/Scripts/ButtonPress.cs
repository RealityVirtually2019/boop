<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    public DadyClient DC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        
        // stream update from ML to Mac
        if (this.name == "1")
        {
            DC.actionType = 1;
        }
        else if (this.name == "2")
        {
            DC.actionType = 2;
        }
        else if (this.name == "3")
        {
            DC.actionType = 3;
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

    public DadyClient DC;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        
        // stream update from ML to Mac
        if (this.name == "1")
        {
            DC.actionType = 1;
        }
        else if (this.name == "2")
        {
            DC.actionType = 2;
        }
        else if (this.name == "3")
        {
            DC.actionType = 3;
        }
    }
}
>>>>>>> 9b189e3074a19b8dd7ccfbbf9fc2ef617e555f62
