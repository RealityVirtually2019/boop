using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ProjectileLauncher : MonoBehaviour
{

    [SerializeField]
    private GameObject p1, p2, p3;
    public int selectedProjectile = 1;
    [SerializeField]
    private float forceAmount;
    [SerializeField]
    private Transform l1, l2, l3;

    public DadyClient DC;

    Rigidbody rigidObject;

    // Launcher sound effects
    [SerializeField]
    private AudioClip launchSound;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchObject();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedProjectile = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedProjectile = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedProjectile = 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.name == "1")
        {
            selectedProjectile = 1;
            DC.actionType = 1;
            LaunchObject();
        }
        else if (this.name == "2")
        {
            selectedProjectile = 2;
            DC.actionType = 2;
            LaunchObject();
        }
        else if (this.name == "3")
        {
            selectedProjectile = 3;
            DC.actionType = 3;
            LaunchObject();
        }
    }
        public void LaunchObject()
    {
        // Spawn projectile and play corresponding sound:
        GameObject spawned;
        if (selectedProjectile == 1)
        {
            spawned = Instantiate(p1);
            GetComponent<AudioSource>().PlayOneShot(launchSound);

            // Launch projectile from source:
            spawned.transform.position = l1.position;
            spawned.transform.right = -1.0f * l1.forward;

            // Rigidbody stuff:
            rigidObject = spawned.GetComponent<Rigidbody>();
            Vector3 forceVector = l1.forward;
            rigidObject.AddForce(forceVector * forceAmount, ForceMode.Impulse);
        }
        else if (selectedProjectile == 2)
        {
            spawned = Instantiate(p2);
            GetComponent<AudioSource>().PlayOneShot(launchSound);

            // Launch projectile from source:
            spawned.transform.position = l2.position;

            // Rigidbody stuff:
            rigidObject = spawned.GetComponent<Rigidbody>();
            Vector3 forceVector = l2.forward;
            rigidObject.AddForce(forceVector * forceAmount, ForceMode.Impulse);
        }
        else if (selectedProjectile == 3)
        {
            spawned = Instantiate(p3);
            GetComponent<AudioSource>().PlayOneShot(launchSound);

            // Launch projectile from source:
            spawned.transform.position = l3.position;
            spawned.transform.right = -1.0f * l3.forward;

            // Rigidbody stuff:
            rigidObject = spawned.GetComponent<Rigidbody>();
            Vector3 forceVector = l3.forward;
            rigidObject.AddForce(forceVector * forceAmount, ForceMode.Impulse);
        }
        else
        {
            spawned = Instantiate(p1);
            GetComponent<AudioSource>().PlayOneShot(launchSound);

            // Launch projectile from source:
            spawned.transform.position = l1.position;
            spawned.transform.right = -1.0f * l1.forward;

            // Rigidbody stuff:
            rigidObject = spawned.GetComponent<Rigidbody>();
            Vector3 forceVector = l1.forward;
            rigidObject.AddForce(forceVector * forceAmount, ForceMode.Impulse);
        }
    }
}