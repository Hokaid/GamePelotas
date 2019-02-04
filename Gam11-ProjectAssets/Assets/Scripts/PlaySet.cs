using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySet : MonoBehaviour {
	GameObject puntos, h1, h2, h3, fon, pearn, hi, contro, lota; Text tp; float counter = 1.0f; int points = 0, hip = 0; public bool vidachange;
	public int vidas = 3; Image sfo; public bool gameover = false; GameObject govac; Text pearnt, hit; 
	void Start () {
		hip = PlayerPrefs.GetInt("hi", 0);
		lota = GameObject.Find("Lota");
		contro = GameObject.Find("Control");
		fon = GameObject.Find("Fondo");
		puntos = GameObject.Find("Puntos");
		h1 = GameObject.Find("Heart1");
		h2 = GameObject.Find("Heart2");
		h3 = GameObject.Find("Heart3");
		tp = puntos.GetComponent<Text>();
		tp.text = "0 Points";
		vidas = 3;
		sfo = fon.GetComponent<Image>();
		govac = GameObject.Find("GameOvaCan");
		pearn = GameObject.Find("PointsEarn");
		hi = GameObject.Find("Hi");
		pearnt = pearn.GetComponent<Text>();
		hit = hi.GetComponent<Text>();
		govac.SetActive(false);
	}
	public void VolverAJugar(){
		gameover = false;
		govac.SetActive(false);
		sfo.color = new Color(1.0f,0.0f,0.0f,0.0f);
		contro.SetActive(true);
		vidas = 3;
		lota.SetActive(true);
		points = 0;
		h1.SetActive(true);
		h2.SetActive(true);
		h3.SetActive(true);
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene("Menu");
		}
		if (gameover == false){
			if (vidas == 2){
				h1.SetActive(false);
				if (vidachange == true){
					StartCoroutine("LostLife");
					vidachange = false;
				}
			}
			else if (vidas == 1){
				h2.SetActive(false);
				if (vidachange == true){
					StartCoroutine("LostLife");
					vidachange = false;
				}
			}
			else if (vidas == 0){
				h3.SetActive(false);
				if (vidachange == true){
					StartCoroutine("LostLife");
					vidachange = false;
					gameover = true;
					govac.SetActive(true);
					contro.SetActive(false);
					pearnt.text = "Points: " + points.ToString();
					if (points > hip){
						hip = points;
						PlayerPrefs.SetInt("hi", hip);
					}
					hit.text = "Hi: " + hip.ToString();
				}
			}
			counter = counter - Time.deltaTime;
			if (counter <= 0.0f){
				points = points + 1;
				if (points == 1){
					tp.text = "1 Point";
				}
				else{
					string strpoi = points.ToString();
					tp.text = strpoi + " Points";
				}
				counter = 1.0f;
			}
		}
	}
	IEnumerator LostLife(){
		float trans = 0.0f;
		for (int i = 0; i < 25;i++){
			sfo.color = new Color(1.0f,0.0f,0.0f,trans);
			trans = trans + 0.02f;
			yield return new WaitForSeconds(.01f);
		}
		if (vidas != 0){
			for (int i = 0; i < 25; i++){
				sfo.color = new Color(1.0f,0.0f,0.0f,trans);
				trans = trans - 0.02f;
				yield return new WaitForSeconds(.01f);
			}
			sfo.color = new Color(1.0f,0.0f,0.0f,0.0f);
		}
	}
}
