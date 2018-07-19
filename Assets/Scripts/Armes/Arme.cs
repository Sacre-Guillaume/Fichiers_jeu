
using UnityEngine;

abstract public class Arme : MonoBehaviour
{
	#region Variables (public)

	public float m_fDegats = 0.0f;
	public float m_AttaqueParSeconde = 0.0f;

	#endregion

	#region Variables (private)



	#endregion

	abstract public void Attaquer();

}
