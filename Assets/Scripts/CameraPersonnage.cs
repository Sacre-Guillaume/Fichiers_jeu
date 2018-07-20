
using UnityEngine;
 
public class CameraPersonnage : MonoBehaviour
{
	#region Variables (public)

	static public CameraPersonnage Instance = null;

	public PersonnageJoueur m_pTarget = null;
	public Transform m_pCameraTransform = null;

	public Camera m_pCamera = null; 

	public float m_fDistanceDeSuivi = 0.0f;
	public float m_fVitesseDeRotation = 0.0f;

	#endregion

	#region Variables (private)


	#endregion

	private void Awake()
	{
		if (CameraPersonnage.Instance != null)
		{
			if (CameraPersonnage.Instance != this)
			{ 
				Debug.LogError("2 CameraPersonnages Dans La Scène");
				Destroy(this);
			}
			return;
			
		}

		CameraPersonnage.Instance = this;
	}

	private void Update()
	{
		TournerCamera();
	}

	private void LateUpdate()
	{
		if (m_pTarget != null)
			Follow();
	}

	private void Follow()
	{
		Vector3 nouvellePositionPoint = (m_pTarget.transform.position) + Vector3.up;
		transform.position = nouvellePositionPoint;

		Vector3 nouvellePositionCamera = nouvellePositionPoint - (m_pCameraTransform.forward * m_fDistanceDeSuivi);
		m_pCameraTransform.position = nouvellePositionCamera;
	}

	private void TournerCamera()
	{
		float fMouseX = Input.GetAxis("Mouse X");

		if(fMouseX != 0.0f)
		{
			Vector3 rotationCamera = new Vector3(0.0f, fMouseX, 0.0f) * (m_fVitesseDeRotation * Time.deltaTime);

			transform.localEulerAngles += rotationCamera;
		}
		float fMouseY = Input.GetAxis("Mouse Y");

		if (fMouseY != 0.0f)
		{
			Vector3 rotationCamera = new Vector3(-fMouseY, 0.0f, 0.0f) * (m_fVitesseDeRotation * Time.deltaTime);

			Vector3 valeurSiAjoutee = transform.eulerAngles + rotationCamera;

			if (valeurSiAjoutee.x < 80.0f && valeurSiAjoutee.x >= 0.0f)
			transform.eulerAngles = valeurSiAjoutee;
		}
	}

}
