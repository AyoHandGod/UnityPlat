using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

    // public field
    public string scene;

    // private field
    bool loadLock = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && !loadLock)
        {
            loadScene();
        }
	}

    void loadScene()
    {
        loadLock = true;
        SceneManager.LoadScene(scene);
    }
}
