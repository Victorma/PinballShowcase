using UnityEngine;
using System.Collections;

public class VisualLogger : MonoBehaviour {
    
    void Awake()
    {
        Application.logMessageReceived += OnLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= OnLog;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    Vector2 scrollPos = Vector2.zero;
    public void OnGUI()
    {
        scrollPos = GUILayout.BeginScrollView(scrollPos);

        foreach(var s in log)
        {
            GUILayout.Label((string) s);
        }

        GUILayout.EndScrollView();
    }

    private ArrayList log = new ArrayList();

    private void OnLog(string condition, string stacktrace, UnityEngine.LogType type)
    {
        log.Add(condition + " at : " + stacktrace);
    }
}
