/// <summary>
/// Timed lighting.
/// This listens for a message from the GameTime.cs to tell it weather it is time for it to be on or off.
/// </summary>
using UnityEngine;
using System.Collections;

public class TimedLighting : MonoBehaviour {
	
	public void OnEnable()
	{
		Messenger<bool>.AddListener("Morning Time", OnToggleLight);
	}
	
	public void OnDisable()
	{
		
		Messenger<bool>.RemoveListener("Morning Time", OnToggleLight);
	}
	
	private void OnToggleLight(bool b)
	{
		if(b)
		{
			
			GetComponent<Light>().enabled = false;
		}
		
		else
		{
			GetComponent<Light>().enabled = true;
			
		}
	}
}
