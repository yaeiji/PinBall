using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {

	//HingIointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle=20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネントの取得
		this.myHingeJoint=GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.LeftArrow)&&tag=="LeftFripperTag"){
			SetAngle (this.flickAngle);
		}
		//右矢印が押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
			//矢印が離された時にフリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		if (0 < Input.touchCount) {
			
			for (int i = 0; i < Input.touchCount; i++) {
				Touch t = Input.GetTouch (i);
				if (t.position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);

					if(t.phase==TouchPhase.Ended){
						SetAngle (defaultAngle);
					}

				}else if (t.position.x > Screen.width * 0.5f && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);

					if(t.phase==TouchPhase.Ended){
						SetAngle (defaultAngle);
					}
			}
		}

	  }
	}
	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
