using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

    bool isDone = false;
	
	// Update is called once per frame
	void Update () {
		if(!isDone)
        {
            isDone = true;
            UIManager.instance.ShowModal("DEMO", "Modal panel demo!\nNewline.");
            UICollection.instance.GetGameObject("Load Panel").GetComponent<LoadPanelBehaviour>().Show(PathManager.instance.EnvironmentPath);
        }
	}
}
