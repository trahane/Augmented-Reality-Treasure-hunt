using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneManagerBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			if (SceneManager.GetActiveScene ().name != "Clue_Select_Scene" && SceneManager.GetActiveScene ().name != "Main")
				SceneManager.LoadScene ("Clue_Select_Scene");
			if (SceneManager.GetActiveScene ().name == "Clue_Select_Scene")
				SceneManager.LoadScene ("Main");
			if (SceneManager.GetActiveScene ().name == "Main")
				Application.Quit ();
		}
	}

}
