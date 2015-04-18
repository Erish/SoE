﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float backSpeed;

	public float moveAnimationSpeed;
	public float backAnimationSpeed;


	public Animator animator;

	private bool jumping;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//hに縦方向の入力を,vに横方向の入力を取得する
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		
		Vector3 direction = transform.TransformDirection(new Vector3 (0,0,v).normalized);

		if (Input.GetButton ("Jump")) {
			StartCoroutine(jump ());
		}
		//キャラクターを回転させる
		transform.Rotate(0, h * rotateSpeed, 0);

		//vの入力値をMecanimに反映
		if (!jumping){
			animator.SetFloat ("speed", v);		//directionと移動速度を元にキャラクターの移動量を計算する
		}

		//前進の場合
		if (v > 0) {
			GetComponent<Rigidbody> ().AddForce (direction * moveSpeed);	
		}
		
		//後退の場合
		if (v < 0) {
			GetComponent<Rigidbody> ().AddForce (direction * backSpeed);
		}

		if (v == 0) {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}

	IEnumerator jump(){
		jumping = true;
		animator.SetBool ("jumping", true);
		animator.SetFloat ("speed", 0);
		yield return new WaitForSeconds (0.70f);
		animator.SetBool ("jumping", false);
		jumping = false;
	}
	
}