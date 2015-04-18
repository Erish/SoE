using UnityEngine;
using System.Collections;

public class OnMouseOutline : MonoBehaviour {

	/*
	オブジェクトにアウトラインを付けるスクリプト

	マウスオーバーやクリック・タップしたオブジェクトが選択されている事を視覚化しわかりやすくする使用法を想定
	
	マテリアルのプロパティを操作するとそのマテリアルを使っている他のオブジェクトにまで影響が及ぶので
	対象のオブジェクト一つのマテリアルをアウトライン付のものに入れ替える、という手法

	OnMouse~はColiderが付いているオブジェクトに対してしか発動しません
	キャラクターのPrefab等はColiderが付いているオブジェクトと実際のMeshが別になっている事が多いので
	このスクリプト自体はColiderがアタッチされている親オブジェクトにアタッチし
	Mesh変数にマテリアルがくっついてる子オブジェクトを指定すると動作します	
	 */

	//マテリアルを入れ替えるオブジェクト
	public GameObject Mesh;

	public Material BaseMaterial;
	public Material OutlineMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		//マウスが乗ったときにMeshのマテリアルをOutlineMaterialに入れ替える
		Mesh.GetComponent<Renderer> ().material = OutlineMaterial;
	}

	void OnMouseExit(){
		//マウスが離れたときにMeshのマテリアルをBaseMaterialに戻す
		Mesh.GetComponent<Renderer> ().material = BaseMaterial;
	}
}
