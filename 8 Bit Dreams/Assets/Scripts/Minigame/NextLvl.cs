using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour 
{
	void OnEnable()
	{
		BossLogic.senderLvl += enableNext;
	}
	void OnDisable()
	{
		BossLogic.senderLvl -= enableNext;
	}
	void enableNext()
	{
		this.GetComponent<Image>().color = new Color(255, 255, 255, 1);
		Invoke("LoadNextScene", 3f);
	}
	void LoadNextScene()
	{
		SceneManager.LoadScene("SpacePlane");
	}
}
