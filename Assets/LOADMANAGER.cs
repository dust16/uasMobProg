using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOADMANAGER : MonoBehaviour {

	void Start()
	{
		StartCoroutine(MyCoroutine());
	}

	IEnumerator MyCoroutine()
	{
		//This is a coroutine
	
		yield return 3;    //Wait one frame

		SceneManager.LoadScene ("maze");
	}

}