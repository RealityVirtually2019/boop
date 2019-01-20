using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {
    public DadyClient DC;
    public ProjectileLauncher PL;
    bool runOnced = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!runOnced)
        {
            if (this.name == "1")
            {
                PL.selectedProjectile = 1;
                DC.actionType = 1;
                DC.shootingState = 1;
                PL.LaunchObject();

            }
            else if (this.name == "2")
            {
                PL.selectedProjectile = 2;
                DC.actionType = 2;
                DC.shootingState = 1;
                PL.LaunchObject();
            }
            else if (this.name == "3")
            {
                PL.selectedProjectile = 3;
                DC.actionType = 3;
                DC.shootingState = 1;
                PL.LaunchObject();
            }
            else if (this.name == "4")
            {
                // DROP EGG
                DC.shootingState = 1;
            }
            else if (this.name == "5")
            {
                // Baby face:
                DC.faceType = 1;
                DC.shootingState = 1;
            }
            else if (this.name == "6")
            {
                // Chicken face:
                DC.faceType = 2;
                DC.shootingState = 1;
            }
            //runOnced = true;
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        DC.shootingState = 0;
        //runOnced = false;
    }
}
