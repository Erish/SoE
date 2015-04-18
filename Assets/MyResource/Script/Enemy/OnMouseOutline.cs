using UnityEngine;
using System.Collections;

public class OnMouseOutline : MonoBehaviour {

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
