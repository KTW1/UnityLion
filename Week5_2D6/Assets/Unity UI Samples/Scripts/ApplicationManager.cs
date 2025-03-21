using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
		UnityEditor.EditorApplication.isPlaying = false;
	}
}
