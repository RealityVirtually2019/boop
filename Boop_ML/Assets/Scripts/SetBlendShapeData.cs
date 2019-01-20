using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For IphoneX
public class SetBlendShapeData : MonoBehaviour
{
    [System.Serializable]

    public class JsonTransform
    {
        public Vector3 pos;
        public Vector3 rot;
    }

    private JsonTransform localData = new JsonTransform();
    public Vector3 headRot;
    public Vector3 eyeRot;

    public GameObject chickenHead;
    public GameObject chickenEye;

    // Eye Rot 
    public int eyeRotX;
    public int eyeRotY;
    public int eyeRotZ;

    // Head Rot 
    public int headRotX;
    public int headRotY;
    public int headRotZ;

    // public int ...


    void Update()
    {

        // Update Head Rotation
        headRot.x = headRotX;
        headRot.y = headRotY;
        headRot.z = headRotZ;

        // Update Eye Rotation 
        eyeRot.x = eyeRotX;
        eyeRot.y = eyeRotY;
        eyeRot.z = eyeRotZ;

        //SetTransform(headRot, eyeRot);
        headRot = new Vector3(chickenHead.transform.rotation.x, chickenHead.transform.rotation.y, chickenHead.transform.rotation.z);
        eyeRot = new Vector3(chickenEye.transform.rotation.x, chickenEye.transform.rotation.y, chickenEye.transform.rotation.z);
    }

    private void Start()
    {
        StartCoroutine(SetData());
    }

    public IEnumerator SetData()
    {
        while (true)
        {
            print("fetching");
            StartCoroutine(Set(headRot, eyeRot));
            yield return new WaitForSeconds(1);
        }

    }
    public Vector3 GetInput()
    {
        return localData.pos;
    }

    public Vector3 GetOutput()
    {
        return localData.rot;
    }

    public void SetTransform(Vector3 pos, Vector3 rot)
    {
        StartCoroutine(Set(pos, rot));
    }

    // SET MLInput IphoneXOutput 
    IEnumerator Set(Vector3 pos, Vector3 rot)
    {
        WWW www;
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        postHeader.Add("Content-Type", "application/json");

        JsonTransform t = new JsonTransform();
        t.pos = pos;
        t.rot = rot;

        string transformStr = JsonUtility.ToJson(t);

        var formData = System.Text.Encoding.UTF8.GetBytes(transformStr);
        string url = "http://internal.mcmentos.com/setTransform2";

        www = new WWW(url, formData, postHeader);

        yield return www;

        if (www.error == "" || www.error == null)
        {
            Debug.Log("Set succeeded!");
            Debug.Log(www.text);
        }
        else
        {
            Debug.Log(www.error);
        }
    }

}
