/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class DefaultTrackableEventHandler : MonoBehaviour,
	ITrackableEventHandler
	{
		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;

		#endregion // PRIVATE_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		public ClueGenerator cs;
		public Canvas can;
		int sceneIndex;

		GameObject clueobj;
		string clueName;
		string nextUnlockScene;

		void Start()
		{

			sceneIndex = SceneManager.GetActiveScene ().buildIndex;

			clueName = PlayerPrefs.GetString ("SCENE"+(sceneIndex-1)+"CLUE_NAME");

			nextUnlockScene = "SCENE"+(sceneIndex+1)+"ISLOCKED";

			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



		#region PUBLIC_METHODS

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		#endregion // PUBLIC_METHODS



		#region PRIVATE_METHODS


		private void OnTrackingFound()
		{
			Debug.LogError (mTrackableBehaviour.TrackableName);
			if (clueName == mTrackableBehaviour.TrackableName && SceneManager.GetActiveScene().name != "GroundLevel") {
				
				Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
				Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);

				// Enable rendering:
				foreach (Renderer component in rendererComponents) {
					component.enabled = true;
				}

				// Enable colliders:
				foreach (Collider component in colliderComponents) {
					component.enabled = true;
				}




				string cluepar = "SCENE" + sceneIndex + "CLUE";

				Transform trans = can.transform;

				int clue = PlayerPrefs.GetInt (cluepar);



				if (clue != -1) {
					
					clueobj = Instantiate (cs.allClues [clue],trans.GetChild(0).transform.position,trans.GetChild(0).transform.rotation) as GameObject;
					clueobj.transform.SetParent (trans.GetChild(0).transform);
					PlayerPrefs.SetInt (nextUnlockScene,1);
					PlayerPrefs.SetInt ("setclue" + (sceneIndex), 1);
					PlayerPrefs.Save ();
				}
			}

			if(SceneManager.GetActiveScene().name == "GroundLevel")
			{

				Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
				Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);

				// Enable rendering:
				foreach (Renderer component in rendererComponents) {
					component.enabled = true;
				}

				// Enable colliders:
				foreach (Collider component in colliderComponents) {
					component.enabled = true;
				}
					


				string cluepar = "SCENE" + sceneIndex + "CLUE";

				Transform trans = can.transform;

				int clue = PlayerPrefs.GetInt (cluepar);


				if (clue != -1) {

					clueobj = Instantiate (cs.allClues [clue],trans.GetChild(0).transform.position,trans.GetChild(0).transform.rotation) as GameObject;
					clueobj.transform.SetParent (trans.GetChild(0).transform);
					PlayerPrefs.SetInt (nextUnlockScene,1);
					PlayerPrefs.SetInt ("setclue" + (sceneIndex), 1);
					PlayerPrefs.Save ();
				}
			}
		}


		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}

			if (clueobj)
			{
				Destroy (clueobj);
			}
		}

		#endregion // PRIVATE_METHODS
	}
}
