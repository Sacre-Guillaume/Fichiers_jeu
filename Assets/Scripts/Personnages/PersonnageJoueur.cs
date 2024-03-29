﻿ 
using UnityEngine; 
 
public class PersonnageJoueur : Personnage 
{
	#region Variables (public) 

	public float m_fVitesseSaut = 5.0f;

	public Rigidbody m_pRigidbody = null;

	#endregion

	#region Variables (private)                       



	#endregion
	
	
	private void Update()
	{
		BougerPersonnage();
		
		Jump();
		
		Attaquer();
	}	
	
	override protected void BougerPersonnage()
	{
		float fAxeHorizontal = Input.GetAxis("Horizontal");
		float fAxeVertical   = Input.GetAxis("Vertical")  ;
		
		Vector3 direction = new Vector3(fAxeHorizontal, 0.0f, fAxeVertical);
		
		if (direction != Vector3.zero)
		{
			direction = CameraPersonnage.Instance.transform.TransformDirection(direction);
			direction.y = 0.0f;
			
			
			if (direction.sqrMagnitude != 0.0f)
				direction.Normalize();
			
			Vector3 deplacement = direction * (m_fVitesse * Time.deltaTime);
			m_pRigidbody.MovePosition(transform.position + deplacement);

			transform.forward = direction;
		}
	}
	
	private void Jump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Vector3 tSaut = Vector3.up * m_fVitesseSaut;
			m_pRigidbody.AddForce(tSaut, ForceMode.Impulse);
			
		}
	}
	
	override protected void Attaquer()
	{
		if (Input.GetButton("Fire1"))
		{
			Vector3 directionDattaque = Input.mousePosition;
			directionDattaque.x /= Screen.width;
			directionDattaque.y /= Screen.height;
			
			directionDattaque -= new Vector3(0.5f, 0.5f, 0.0f); // Centrage par rappor au centre de l'ecran

			directionDattaque.z = directionDattaque.y;
			directionDattaque.y = 0.0f;

			directionDattaque = CameraPersonnage.Instance.transform.TransformDirection(directionDattaque);
			directionDattaque.y = 0.0f;
			
			if (directionDattaque != Vector3.zero)
				transform.forward = directionDattaque.normalized;
			
			m_pArme.Attaquer();
		}
	}
	
} 
