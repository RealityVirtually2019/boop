using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

// For Magic Leap
public class GetBlendShapeClient : MonoBehaviour {
    [System.Serializable]

    public class JsonTransform
    {
        public Vector3 pos;
        public Vector3 rot;
    }

    public GameObject chickenHead;
    public GameObject chickenEyeL;
    public GameObject chickenEyeR;
    private JsonTransform localData = new JsonTransform();

    private void Start()
    {
        StartCoroutine(GetData());
    }
    // Update is called once per frame
    void Update()
    {
        // Apply Iphone X data to ML chicken head 
        chickenHead.transform.rotation = Quaternion.Euler(localData.pos);
        chickenEyeL.transform.rotation = Quaternion.Euler(localData.rot);
        chickenEyeR.transform.rotation = Quaternion.Euler(localData.rot);
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
}
