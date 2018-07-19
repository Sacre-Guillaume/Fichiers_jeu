
using UnityEngine;

public class ArmeADistance : Arme
{
	#region Variables (public)

	public GameObject m_pPrefabProjectile = null;

	public Transform m_pOrigineTir = null;

	#endregion

	#region Variables (private)



	#endregion

	override public void Attaquer()
	{
		Instantiate(m_pPrefabProjectile, m_pOrigineTir.position, m_pOrigineTir.rotation);
	}


}
