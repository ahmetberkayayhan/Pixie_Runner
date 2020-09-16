using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Berkay : MonoBehaviour
{
	public float hiz,yukselisHizi,mesafe,skormesafe;
	public Transform baslangicNoktasi;
	public Text mesafeYazi,mesafeoyunsonuYazi,skormesafeYazi;
	public GameObject oyunsonuPanel,oyunPanel,baslangicPanel;

    void Start()
    {
		oyunsonuPanel.SetActive(false);
		oyunPanel.SetActive(false);
		baslangicPanel.SetActive(true);
		hiz=0;
		yukselisHizi=0;
		GetComponent<Rigidbody2D> ().gravityScale = 0;
    }
		
    void Update()
    {
		mesafe= Vector2.Distance (baslangicNoktasi.position,transform.position);
		mesafeYazi.text=(int)mesafe+"M";
		transform.Translate (hiz*Time.deltaTime,0,0);

		if(Input.GetMouseButton (0)){
			Debug.Log("You Pressed Something");
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * yukselisHizi * Time.deltaTime);
		}

    }

	void OnTriggerEnter2D(Collider2D nesne){
		if(nesne.gameObject.tag == "Gecis"){
			nesne.gameObject.transform.root.gameObject.GetComponent<Yol> ().aktif = true;
		}

	}

	void OnCollisionEnter2D(Collision2D nesne){
		if(nesne.gameObject.tag == "Engel"){

			oyunsonu();
		}

	}

	public void Butonlar(int i){

		if(i==0){
			oyunPanel.SetActive(true);
			baslangicPanel.SetActive(false);
			oyunsonuPanel.SetActive(false);
			hiz= 4;
			yukselisHizi=2500;
			GetComponent<Rigidbody2D> ().gravityScale= 1;
			Time.timeScale=1;

		}
			
			

	}

	void oyunsonu(){
		oyunPanel.SetActive(false);
		oyunsonuPanel.SetActive(true);
		mesafeoyunsonuYazi.text= "Range : " +(int)mesafe+"M";
		skormesafe = PlayerPrefs.GetFloat("Best Ranges");
		if(skormesafe>mesafe){
			skormesafeYazi.text="Best Range : "+(int)skormesafe+"M";
		}
		else{
			skormesafe=mesafe;
			PlayerPrefs.SetFloat("Best Ranges",skormesafe);
			skormesafeYazi.text="Best Range : "+(int)skormesafe+"M";
		}



	


	}


}