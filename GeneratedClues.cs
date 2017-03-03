using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneratedClues : MonoBehaviour {

	public GameObject slideLeftPanel;
	private Animator animator;
	private Text tex;
	public GameObject[] allclues;


	// Use this for initialization
	void Start () {

		animator = slideLeftPanel.GetComponent<Animator>();
		tex = slideLeftPanel.transform.GetChild (2).gameObject.GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowSidePanel()
	{
		if (null != animator)
		{
			animator.SetTrigger("show");
			Generated_clues ();
		}
	}

	public void HideSidePanel()
	{
		if (null != animator)
		{
			animator.SetTrigger("hide");
		}
	}

	private void Generated_clues()
	{
		tex.text = "";	
		for(int i=0;i<allclues.Length;i++)
		{

			if (allclues [i].name == PlayerPrefs.GetString ("SCENE" + 2 + "CLUE_NAME") && PlayerPrefs.GetInt("setclue2")==1) 
			{
				tex.text += allclues[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
			}

			if (allclues [i].name == PlayerPrefs.GetString ("SCENE" + 3 + "CLUE_NAME") && PlayerPrefs.GetInt("setclue3")==1) 
			{
				tex.text += "\n" + allclues[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
			}

			if (allclues [i].name == PlayerPrefs.GetString ("SCENE" + 4 + "CLUE_NAME") && PlayerPrefs.GetInt("setclue4")==1) 
			{
				tex.text += "\n" + allclues[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
			}

			if (allclues [i].name == PlayerPrefs.GetString ("SCENE" + 5 + "CLUE_NAME") && PlayerPrefs.GetInt("setclue5")==1) 
			{
				Debug.LogError ("clue of scene 5");
				tex.text += "\n" + allclues[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
			}
			/*
			if (allclues [i].name == PlayerPrefs.GetString ("SCENE" + 6 + "CLUE_NAME") && PlayerPrefs.GetInt("setclue6")==1) 
			{
				tex.text += "\n" + allclues[i].transform.GetChild(0).gameObject.GetComponent<Text>().text;
			}
			*/
		}
	}
}
