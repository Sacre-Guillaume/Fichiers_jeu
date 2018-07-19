
using UnityEngine;

public class Projectile : MonoBehaviour
{
	#region Variables (public)

	public float m_fVitesse = 0.0f;
	public float m_fDistanceMax = 0.0f;

	#endregion

	#region Variables (private)

	private Vector3 m_positionDeDepart = Vector3.zero;
	private Vector3 m_directionDeDepart = Vector3.forward;

	#endregion
	
	private void Start()
	{
		m_positionDeDepart = transform.position;
		m_directionDeDepart = transform.forward;
	}

	private void Update()
	{
		DeplacerProjectile();
	}

	private void DeplacerProjectile()
	{
		transform.position += m_directionDeDepart * (m_fVitesse * Time.deltaTime);

		if ((transform.position - m_positionDeDepart).sqrMagnitude >= (m_fDistanceMax * m_fDistanceMax))
		{
			// Pour Detruire la boule uniquement
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider pCollider)
	{
		if (pCollider.gameObject.layer != LayerMask.NameToLayer("Attaque") 
		&& pCollider.gameObject.layer != LayerMask.NameToLayer("sol")
		&& pCollider.gameObject.layer != LayerMask.NameToLayer("Arme(Nez)"))
		{ 
			Destroy(gameObject);
		}
	}
}
