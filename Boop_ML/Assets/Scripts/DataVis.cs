using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVis : MonoBehaviour {
    [System.Serializable]

    public class JsonTransform
    {
        public Vector3 pos;
        public Vector3 rot;
    }

    private JsonTransform localData = new JsonTransform();
    public GameObject testCube;
    public TMPro.TextMeshPro testText;

    private void Start()
    {
        StartCoroutine(GetData());
    }
    // Update is called once per frame
    void Update () {
        // debug cube 
        transform.position = localData.pos;
        // debug text
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(testCube);
        }
        testText.SetText("Debug: " + localData.pos);


    }

    public IEnumerator GetData()
    {
        while(true) {
            print("fetching");
            StartCoroutine(Get());
            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator Get()
    {
        WWW www;

        string url = "http://internal.mcmentos.com/getTransform";
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
