using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClueGenerator : MonoBehaviour {

	public GameObject[] allClues;
	int sceneIndex;
	int clue = -1;

	void Start()
	{
		//PlayerPrefs.DeleteAll ();
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		if(!PlayerPrefs.HasKey ("SCENE"+sceneIndex+"CLUE"))
		{
			randomClue ();
		}
		else
		{
			clue = PlayerPrefs.GetInt ("SCENE" + sceneIndex + "CLUE");
		}
	}

	void randomClue()
	{
		clue = Random.Range (0, allClues.Length);
		PlayerPrefs.SetInt ("SCENE"+sceneIndex+"CLUE",clue);
		PlayerPrefs.SetString ("SCENE"+sceneIndex+"CLUE_NAME",allClues[clue].transform.name.ToString());
		PlayerPrefs.Save ();
	}

}
