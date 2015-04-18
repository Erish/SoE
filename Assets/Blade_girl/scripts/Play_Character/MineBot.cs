

using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  


public class MineBot: MonoBehaviour {
	
	protected Animator avatar;
	public float rotateSpeed = 1.0F;
	public float speed = 3.0F;
	public float DirectionDampTime = .25f;//rotate
	public bool useCurves;	//jump






	private AnimatorStateInfo currentBaseState;	
	private CapsuleCollider col;	// a reference to the current state of the animator, used for base layer


	static int jumpState = Animator.StringToHash("Base Layer.BG_Jump_Front");
	static int attack01State = Animator.StringToHash("Base Layer.BG_Attack01");



	void Start () 
	{
		avatar = GetComponent<Animator>();
	
	}
    




	void Update () 
	{
		currentBaseState = avatar.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation

		
		if(avatar)
		{
			bool k = Input.GetButton("Jump");
            bool j = Input.GetButton("Fire1");
			bool r = Input.GetButton("Fire2");
			bool b = Input.GetButton("Fire3");
      		float h = Input.GetAxis("Horizontal");
        	float v = Input.GetAxis("Vertical");



			avatar.SetFloat("Speed", h*h+v*v);
			avatar.SetFloat("Direction", Mathf.Atan2(h,v) * 180.0f / 3.14159f);
            avatar.SetBool("Jump", k);
			avatar.SetBool("Attack", j);
			avatar.SetBool("Attack01", r);
			avatar.SetBool("AttackStandy", b);

		    Rigidbody rigidbody = GetComponent<Rigidbody>();

            if(rigidbody)
            {
                Vector3 speed = rigidbody.velocity;
                speed.x = 4 * h;
                speed.z = 4 * v;
                rigidbody.velocity = speed;
				transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);//rotate


                if (j)
                {
					avatar.SetBool("Attack", true);
				

				
				}


					
				else if (r)
				{
					avatar.SetBool("Attack01", true);
					
					
				}

				else if (k)
				{
					avatar.SetBool("Jump", true);


					
				}
				
				else if (b)
				{
					avatar.SetBool("AttackStandy", true);
					
					
					
				}

				else if(currentBaseState.nameHash == jumpState)
				{
					//  ..and not still in transition..
					if(!avatar.IsInTransition(0))
					{
						if(useCurves)
							// ..set the collider height to a float curve in the clip called ColliderHeight
							col.height = avatar.GetFloat("ColliderHeight");
						
						// reset the Jump bool so we can jump again, and so that the state does not loop 
						avatar.SetBool("Jump", false);
					}
					
					// Raycast down from the center of the character.. 
					Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
					RaycastHit hitInfo = new RaycastHit();
					
					if (Physics.Raycast(ray, out hitInfo))
					{
						// ..if distance to the ground is more than 1.75, use Match Target
						if (hitInfo.distance > 1.75f)
						{
							
							// MatchTarget allows us to take over animation and smoothly transition our character towards a location - the hit point from the ray.
							// Here we're telling the Root of the character to only be influenced on the Y axis (MatchTargetWeightMask) and only occur between 0.35 and 0.5
							// of the timeline of our animation clip
							avatar.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
						}
					}
				}

			   else
				{
					avatar.SetBool("Attack", false);
					avatar.SetBool("Attack01", false);
					avatar.SetBool("Jump", false);
					avatar.SetBool("AttackStandy", false);
					rigidbody.AddForce(Vector3.down * 700);
				
				}






            }


			if (currentBaseState.nameHash == attack01State)
			{
				if(Input.GetButtonDown("Fire1"))
				{
					avatar.SetBool("Combo", true);

					
					
				}
				else
				{
					avatar.SetBool("Combo", false);

				}
			}
		
		}		
	}



	
}