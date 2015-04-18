using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour 
{

	public Rigidbody SkillPrefab;
	public Transform pos;





	void Skill()
	{
		Instantiate(SkillPrefab,  pos.position, pos.rotation);

		
		
	}



}
