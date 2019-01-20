using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadyClient : MonoBehaviour
{
    [System.Serializable]

    public class JsonTransform
    {
        public Vector3 pos;
        public Vector3 rot;
    }

    private JsonTransform localData = new JsonTransform();
    public Vector3 input;
    public Vector3 output;

    // Inputs 
    public int actionType;
    public int faceType;
    public int soundType;

    // Outputs 
    public int reactionVal;
    public int gameState;
    // public int ...


    void Update()
    {
        // Update MLInput 
        input.x = actionType;
        input.y = faceType;
        input.z = soundType;

        // Update IPhoneXOutput 
        output.x = reactionVal;
        output.y = gameState;
        //output.z = ...;

        // Update Blendshape  
        // float1
        // float2
        // float3
        // float4
        // float5
        // float6

        // Update Face Position 
        // Vector3

        // Update Face Rotation 
        // Vector3

        //SetTransform(input, output);
        //getData();
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
            StartCoroutine(Set(input, output));
            yield return new WaitForSeconds(1);
        }

    }

    public static Vector3 GetStaticInput()
    {
        DadyClient dad = new DadyClient();
        return dad.localData.pos;
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
        string url = "http://internal.mcmentos.com/setTransform";

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