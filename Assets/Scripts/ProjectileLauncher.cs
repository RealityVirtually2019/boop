using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;
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
    }

    private void LaunchObject()
    {
        // Spawn projectile and play corresponding sound:
        GameObject spawned;
        spawned = Instantiate(projectile);
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