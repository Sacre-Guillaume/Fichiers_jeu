
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	#region Variables (public)

	public string m_sNomDeLaScene = null;

	#endregion

#region Variables (private)



	#endregion

	public void LancerLeJeu()
	{
		SceneManager.LoadScene(m_sNomDeLaScene);
	}
	public void QuitterLeJeu()
	{
		Application.Quit();
	}
}
