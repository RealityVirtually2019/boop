using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {
    public DadyClient DC;
    public ProjectileLauncher PL;
    bool runOnced = false;
    public GameObject babyFace, chickenFace;

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
                PL.selectedProjectile = 4;
                DC.actionType = 4;
                DC.shootingState = 1;
                PL.LaunchObject();

            }
            else if (this.name == "5")
            {
                // Baby face:
                DC.faceType = 1;
                DC.shootingState = 1;
                babyFace.SetActive(true);
                chickenFace.SetActive(false);
                gameObject.SetActive(false);
            }
            else if (this.name == "6")
            {
                // Chicken face:
                DC.faceType = 2;
                DC.shootingState = 1;
                chickenFace.SetActive(true);
                babyFace.SetActive(false);
                gameObject.SetActive(false);
            } 
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitForIt());
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2);
        DC.shootingState = 0;
        runOnced = false;
    }

}
