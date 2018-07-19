﻿ 
using UnityEngine; 
 
public class PersonnageJoueur : MonoBehaviour 
{
	#region Variables (public) 

	public Rigidbody m_pRigidbody = null;

	public Arme m_pArme = null;
	
	public float m_fPV = 10.0f;
  
	public float m_fVitesse = 2.0f;

	public float m_fVitesseSaut = 5.0f;

	#endregion

	#region Variables (private)                       



	#endregion


	private void Update()
	{
		BougerPersonnage();

		Jump();

		Attaquer();
	}	

	private void BougerPersonnage()
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

	private void Attaquer()
	{
		if (Input.GetButton("Fire1"))
		{
			m_pArme.Attaquer();
		}
	}

} 
