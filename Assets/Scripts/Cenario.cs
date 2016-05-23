using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cenario : MonoBehaviour {

	public GameObject nuvem1;
	public GameObject nuvem2;
	public GameObject nuvem3;
	public GameObject nuvem4;
	public GameObject nuvem5;
	public GameObject nuvem6;
	public GameObject barquinho;

	private Text debugs;

	// Use this for initialization
	void Start () {
		//InvokeRepeating("CriarNuvem1", 0f, 30f);

		CriarNuvem1();
	}	

	private void CriarNuvem1(){
		float pos_x = ((Screen.width*1.1f/2 + MetaUtils.getWidth(nuvem1)/2)/100)+MetaUtils.getWidth(nuvem1)/2/100;
		GameObject obj = (GameObject)Instantiate(nuvem1, new Vector3(pos_x, Random.Range(-0.3f, 3f), 1), Quaternion.identity);
		obj.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(-0.5f, 0f);
	}



	// Debug
	void Update(){
		//debugs = GameObject.FindWithTag("Debug").GetComponent<Text>();
		//debugs.text = "Screen.width:"+Screen.width+"\nScreen.height:"+Screen.height;
		//DebugText("Screen.width:"+Screen.width+"\nScreen.height:"+Screen.height);


	}

	void DebugText(string text){
		debugs = GameObject.FindWithTag("Debug").GetComponent<Text>();
		debugs.text = text;
	}
}
