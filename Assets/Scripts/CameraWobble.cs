using UnityEngine;
using System.Collections;

public class CameraWobble : MonoBehaviour 
{
	private bool started;
	private bool finishedOnce;

	private Animation anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animation>();
		started = false;
		finishedOnce = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (started && !anim.isPlaying && !finishedOnce) 
		{
			anim.Play ();
			finishedOnce = true;
		}
	}

	public void StartWobble()
	{
		started = true;
		anim.Play ();
	}
}
