using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadingScript : MonoBehaviour {

	public Texture2D fadingTexture;
	public float fadingSpeed = 0.8f;

	private int drawDepth = -1000;
	public float alpha = 1.0f;
	private int fadeDir = -1;


	void OnGUI(){
		alpha += fadeDir * fadingSpeed * Time.deltaTime;

		alpha = Mathf.Clamp01 (alpha);


		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadingTexture);
	}

	public float BeginFade(int direction){

		fadeDir = direction;
		return fadingSpeed;
	}
		
}
