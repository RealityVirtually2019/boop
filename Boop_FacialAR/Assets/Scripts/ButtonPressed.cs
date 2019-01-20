using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {
    public DadyClient DC;
    public ProjectileLauncher PL;
    private void OnTriggerEnter(Collider other)
    {
        if (this.name == "1")
        {
            PL.selectedProjectile = 1;
            DC.actionType = 1;
            PL.LaunchObject();
        }
        else if (this.name == "2")
        {
            PL.selectedProjectile = 2;
            DC.actionType = 2;
            PL.LaunchObject();
        }
        else if (this.name == "3")
        {
            PL.selectedProjectile = 3;
            DC.actionType = 3;
            PL.LaunchObject();
        }
        else if (this.name == "4")
        {
            // DROP EGG
        }
        else if (this.name == "5")
        {
            // Baby face:
            DC.faceType = 1;
        }
        else if (this.name == "6")
        {
            // Chicken face:
            DC.faceType = 2;
        }
    }
}
