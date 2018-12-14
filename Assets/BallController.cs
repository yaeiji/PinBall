using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	
	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	private GameObject Ten;
	private int num=0;
	Material myMaterial;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.Ten = GameObject.Find ("ten");
		this.Ten.GetComponent<Text> ().text = num.ToString();
		this.myMaterial=GetComponent<Renderer>().material;
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		this.Ten.GetComponent<Text> ().text = num.ToString();

		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "LargeStarTag") {
			num += 2;
		} else if (other.gameObject.tag == "SmallStarTag") {
			num += 1;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			num += 2;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			num += 5;
		}
	}

}
