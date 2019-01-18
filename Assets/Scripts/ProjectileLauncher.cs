using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField]
    private GameObject p1, p2, p3;
    int selectedProjectile = 1;
    [SerializeField]
    private float forceAmount;
    [SerializeField]
    private Transform launcherMuzzle;

    Rigidbody rigidObject;

    // Launcher sound effects
    [SerializeField]
    private AudioClip launchSound;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LaunchObject();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedProjectile = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            selectedProjectile = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            selectedProjectile = 3;
        }
    }

    private void LaunchObject()
    {
        // Spawn projectile and play corresponding sound:
        GameObject spawned;
        if (selectedProjectile == 1)
        {
            spawned = Instantiate(p1);
        }
        else if (selectedProjectile == 2)
        {
            spawned = Instantiate(p2);
        }
        else if (selectedProjectile == 3)
        {
            spawned = Instantiate(p3);
        }
        else
        {
            spawned = Instantiate(p1);
        }

        GetComponent<AudioSource>().PlayOneShot(launchSound);

        // Launch projectile from source:
        spawned.transform.position = launcherMuzzle.position;
        spawned.transform.right = -1.0f * launcherMuzzle.forward;
        
        // Rigidbody stuff:
        rigidObject = spawned.GetComponent<Rigidbody>();
        Vector3 forceVector = launcherMuzzle.forward;
        rigidObject.AddForce(forceVector * forceAmount, ForceMode.Impulse);
    }
}