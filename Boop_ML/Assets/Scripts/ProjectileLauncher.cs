using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ProjectileLauncher : MonoBehaviour
{
    [System.Serializable]
    public class JsonTransform
    {
        public Vector3 pos;
        public Vector3 rot;
    }
    [SerializeField]
    private GameObject p1, p2, p3, p4;
    public int selectedProjectile = 1;
    [SerializeField]
    private float forceAmount;
    [SerializeField]
    private Transform l1, l2, l3, l4;
    [SerializeField]
    private AudioClip launchSound;

    public DadyClient DC;

    Rigidbody rigidObject;
    

    private JsonTransform localData = new JsonTransform();

    private void Update()
    {
        if (localData.rot.z == 1)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchObject();
            }

        if (localData.pos.x == 1)
        {
            selectedProjectile = 1;
        }
        else if (localData.pos.x == 2)
        {
            selectedProjectile = 2;
        }
        else if (localData.pos.x == 3)
        {
            selectedProjectile = 3;
        }
        else if (localData.pos.x == 4)
        {
            selectedProjectile = 4;
        }
    }

    private void Start()
    {
        StartCoroutine(GetData());
    }
    

    public IEnumerator GetData()
    {
        while (true)
        {
            print("fetching");
            StartCoroutine(Get());
            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator Get()
    {
        WWW www;

        string url = "http://internal.mcmentos.com/getTransform2";
        www = new WWW(url);

        yield return www;

        if (www.error == "" || www.error == null)
        {
            Debug.Log("Get succeeded!");
            Debug.Log(www.text);
            JsonTransform t = JsonUtility.FromJson<JsonTransform>(www.text);
            localData.pos = t.pos;
            localData.rot = t.rot;
            print("networked p" + localData.pos);
            print("networked r" + localData.rot);
            Debug.Log(localData.pos);
        }
        else
        {
            Debug.Log(www.error);
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
        else if (selectedProjectile == 4)
        {
            // DROP EGG:
            spawned = Instantiate(p4);
            GetComponent<AudioSource>().PlayOneShot(launchSound);
            // Launch projectile from source:
            spawned.transform.position = l4.position;
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