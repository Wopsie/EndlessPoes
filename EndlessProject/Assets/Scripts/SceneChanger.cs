using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour 
{
	public void ChangeToScene (int sceneToChangeTo) 
    {
        Application.LoadLevel(sceneToChangeTo);
	}
}
