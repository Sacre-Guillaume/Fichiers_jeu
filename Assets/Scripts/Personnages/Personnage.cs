
using UnityEngine;

abstract public class Personnage : MonoBehaviour
{
	#region Variables (public)

	public Animator m_pAnimator = null;

	public Arme m_pArme = null;

	public float m_fPV = 10.0f;

	public float m_fVitesse = 2.0f;

	#endregion

	#region Variables (private)



	#endregion

	abstract protected void BougerPersonnage();
	abstract protected void Attaquer();
}