
using UnityEngine;
 
public class CameraPersonnage : MonoBehaviour
{ 
	#region Variables (public)

	public PersonnageJoueur m_pTarget = null;

	public float m_fDistanceDeSuivi = 0.0f;

	#endregion
 
	#region Variables (private)


	#endregion

	private void LateUpdate()
	{
		if (m_pTarget !=null)
		Follow();
	}

	private void Follow()
	{
		Vector3 nouvellePosition = (m_pTarget.transform.position) - (transform.forward * m_fDistanceDeSuivi);
		transform.position = nouvellePosition;
	}
}
