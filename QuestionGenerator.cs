using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour {

	public GameObject slideLeftPanel;
	private Animator animator;
	private Text tex;
	public Text[] allQuestions;


	// Use this for initialization
	void Start () {

		animator = slideLeftPanel.GetComponent<Animator>();
		tex = slideLeftPanel.transform.GetChild (2).gameObject.GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void ShowSidePanel()
	{
		if (null != animator)
		{
			animator.SetTrigger("show");
			GenerateQuestion ();
		}
	}

	public void HideSidePanel()
	{
		if (null != animator)
		{
			animator.SetTrigger("hide");
		}
	}

	private void GenerateQuestion()
	{
		if (PlayerPrefs.HasKey ("SCENE6CLUE_NAME") && !PlayerPrefs.HasKey("question")) 
		{
			int i = Random.Range (0,allQuestions.Length);
			PlayerPrefs.SetString("question",allQuestions [i].text);
			PlayerPrefs.Save ();
		}
		tex.text = PlayerPrefs.GetString("question");
	}
}
