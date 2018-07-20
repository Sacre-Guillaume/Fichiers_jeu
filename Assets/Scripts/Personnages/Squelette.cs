
using UnityEngine;
using UnityEngine.AI;

public class Squelette : Personnage
{
	#region Variables (public)

	public NavMeshAgent m_pNavMeshAgent = null;

	public Personnage m_pCible = null;

	public float m_fDistanceDarret = 0.0f;

	#endregion

	#region Variables (private)



	#endregion

	private void Start()
	{
		m_pNavMeshAgent.speed = m_fVitesse;
		m_pNavMeshAgent.stoppingDistance = m_fDistanceDarret;
	}

	private void Update()
	{
		if (m_pCible == null)
			return;
		// On a une cible

		BougerPersonnage();
	}
	private void LateUpdate()
	{
		if (m_pAnimator != null)
			AnimeMarche();
	}


	protected override void Attaquer()
	{
		
	}

	protected override void BougerPersonnage()
	{
		Vector3 destination = m_pCible.transform.position;

		RaycastHit hit;

		if (Physics.Raycast(transform.position + Vector3.up, (destination - transform.position).normalized, out hit, 300.0f, LayerMask.GetMask("personnage"), QueryTriggerInteraction.Collide))
		{
			m_pNavMeshAgent.SetDestination(hit.point - Vector3.up);
		}
	}

	private void AnimeMarche()
	{
		m_pAnimator.SetBool("Bouger",m_pNavMeshAgent.velocity != Vector3.zero);
	}

}