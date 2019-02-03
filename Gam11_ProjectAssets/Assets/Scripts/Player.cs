using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	Transform tr; float trans; bool up; bool down; PlaySet pset;
	void Start () {
		tr = gameObject.GetComponent<Transform>();
		pset = GameObject.FindObjectOfType<PlaySet>();
	}
	void Update () {
		if (pset.gameover == false){
			if (up){
				trans = -20;
			}
			else if (down){
				trans = 20;
			}
			else{
				trans = 0;
			}
			if (tr.position.x <= 3.31f && trans > 0){
				trans *= Time.deltaTime;
				tr.Translate(trans, 0, 0);
			}
			else if (tr.position.x >= -4.16f && trans < 0){
				trans *= Time.deltaTime;
				tr.Translate(trans, 0, 0);
			}
		}
	}
	public void ArribaT(){
		up = true;
	}
	public void ArribaF(){
		up = false;
	}
	public void AbajoT(){
		down = true;
	}
	public void AbajoF(){
		down = false;
	}
}
