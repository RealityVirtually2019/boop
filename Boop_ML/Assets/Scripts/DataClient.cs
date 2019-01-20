using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataClient : MonoBehaviour {
    [System.Serializable]

	public class JsonData {
		public Vector3 input;
        public Vector3 output;
	}

    private JsonData localData = new JsonData();
    public Vector3 MLInput;
    public Vector3 playerOutput;

    // Inputs 
    public int actionType = 1;
    public int faceType = 2;
    public int soundType = 3;

    // Outputs 
    public int reactionVal;
    public int gameState;

    void Update() {
        //StartCoroutine(Get());

        // Update MLInput 
        MLInput.x = actionType;
        MLInput.y = faceType;
        MLInput.z = soundType;

        // Update UserOutput 
        playerOutput.x = reactionVal;
        playerOutput.y = gameState;

        // set MLInput 
        // setScore();
        // set playerOutput
        SetData(MLInput, playerOutput);
        GetData();
    }


    public Vector3 GetInput() {
        return localData.input;
    }

    public Vector3 GetOutput() {
        return localData.output;
    }

    public void GetData() {
        StartCoroutine(Get());
    }

    IEnumerator Get() {
		WWW www;

		string url = "http://internal.mcmentos.com/getTransform";
        www = new WWW(url);

		yield return www;

        if (www.error == "" || www.error == null) {
            Debug.Log("Get succeeded!");
            Debug.Log(www.text);
            JsonData t = JsonUtility.FromJson<JsonData>(www.text);
            localData.input = t.input;
            localData.output = t.output;
            print("networked input" + localData.input);
            print("networked output" + localData.output);
            Debug.Log(localData.input);
        } else {
            Debug.Log(www.error);
        }
    }

    public void SetData(Vector3 input, Vector3 output)
    {
        StartCoroutine(Set(input, output));
    }

    IEnumerator Set(Vector3 input, Vector3 output) {
		WWW www;
		Dictionary<string, string> postHeader = new Dictionary<string, string>();
		postHeader.Add("Content-Type", "application/json");

        JsonData t = new JsonData();
        t.input = input;
        t.output = output;

		string transformStr = JsonUtility.ToJson(t);

		var formData = System.Text.Encoding.UTF8.GetBytes(transformStr);
		string url = "http://internal.mcmentos.com/setTransform";

		www = new WWW(url, formData, postHeader);

		yield return www;

		if (www.error == "" || www.error == null) {
			Debug.Log("Set succeeded!");
			Debug.Log(www.text);
		} else {
            Debug.Log(www.error);
        }
	}

    //public void addScore(int val)
    //{
    //    StartCoroutine(Add(val));
    //}

    //IEnumerator Add(int val)
    //{
    //    WWW www;
    //    Dictionary<string, string> postHeader = new Dictionary<string, string>();
    //    postHeader.Add("Content-Type", "application/json");

    //    Score score = new Score();
    //    score.value = val;

    //    string scoreStr = JsonUtility.ToJson(score);

    //    var formData = System.Text.Encoding.UTF8.GetBytes(scoreStr);
    //    string url = "http://internal.mcmentos.com:62802/addScore";

    //    www = new WWW(url, formData, postHeader);

    //    yield return www;

    //    if (www.error != "")
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        Debug.Log("Add succeeded!");
    //        Debug.Log(www.text);
    //    }
    //}
}
