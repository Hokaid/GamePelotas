using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void Star(){
		 SceneManager.LoadScene("Game");
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {Application.Quit();}
	}
}
