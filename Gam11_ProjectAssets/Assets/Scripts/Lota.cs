using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lota : MonoBehaviour {
	ConstantForce cf; Transform tr; PlaySet pset; public AudioClip[] audios;
	public AudioSource ausour;
	void Start () {
		ausour = gameObject.GetComponent<AudioSource>();
		pset = GameObject.FindObjectOfType<PlaySet>();
		tr = gameObject.GetComponent<Transform>();
		cf = gameObject.GetComponent<ConstantForce>();
		cf.force = new Vector3(15.0f,0.0f,0.0f);
	}
	void Update () {

	}
	void OnCollisionEnter (Collision col) {
        if(col.gameObject.name == "Port1") {
           cf.force = new Vector3(Random.Range(-3.0f, 3.0f),0.0f,Random.Range(-15.0f,-10.0f));
           ausour.clip = audios[0];
        }
        else if(col.gameObject.name == "Port2") {
        	cf.force = new Vector3(Random.Range(-15.0f,-10.0f),0.0f,Random.Range(-3.0f, 3.0f)); ausour.clip = audios[0];
        }
        else if(col.gameObject.name == "Port") {
            cf.force = new Vector3(Random.Range(10.0f, 15.0f),0.0f,Random.Range(-3.0f, 3.0f)); ausour.clip = audios[0];
        }
        else if(col.gameObject.name == "Player") {
            cf.force = new Vector3(Random.Range(-3.0f, 3.0f),0.0f,Random.Range(10.0f, 15.0f)); ausour.clip = audios[0];
        } 
        else if(col.gameObject.name == "PlayerPort"){
        	tr.transform.position = new Vector3(0.0f, 0.0f, -5.0f); ausour.clip = audios[1];
        	cf.force = new Vector3(Random.Range(-8.0f, 8.0f),0.0f,0.0f);
        	pset.vidas = pset.vidas - 1;
        	pset.vidachange = true;
        	if (pset.vidas == 0){
        		gameObject.SetActive(false);
        	}
        }
        ausour.Play();
    }
}
