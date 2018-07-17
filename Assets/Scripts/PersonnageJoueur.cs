 
using UnityEngine; 
 
public class PersonnageJoueur : MonoBehaviour 
{
	#region Variables (public) 
 
	public  int m_iPV = 10;
  
	public float m_fVitesse = 2.0f;
	#endregion

#region Variables (private)                       



	#endregion


	private void Update()
	{
		BougerPersonnage();
	}
	private void BougerPersonnage()
	{
		float fAxeHorizontal = Input.GetAxis("Horizontal");
		float fAxeVertical   = Input.GetAxis("Vertical")  ;

		Vector3 direction = new Vector3(fAxeHorizontal, 0.0f, fAxeVertical);

		if (direction != Vector3.zero)
		{
			direction.Normalize();

			Vector3 deplacement = direction * (m_fVitesse * Time.deltaTime);
			transform.position += deplacement;

			transform.forward = direction;
		}
	}
	

} 
