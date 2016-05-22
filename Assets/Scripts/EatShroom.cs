using UnityEngine;
using System.Collections;

public class EatShroom : MonoBehaviour 
{
	public GameObject armToMove;

	public Vector3 startPosition;

	public Vector3 eatPosition;

	public float moveTime = 3;

	public AnimationCurve moveCurve;

	private float tolerance = 0.05f;

	private float elapsedTime;

	private bool isMoving;

	// Use this for initialization
	void Start () 
	{
		startPosition = armToMove.transform.position;
		isMoving = false;
		elapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.A)) 
		{
			isMoving = true;
		}

		if (isMoving) 
		{
			elapsedTime += Time.deltaTime;
			float interpolateValue = elapsedTime / moveTime;

			if (interpolateValue > 1.0) 
			{
				interpolateValue = 1.0f;
			}

			float curveValue = moveCurve.Evaluate (interpolateValue);

			armToMove.transform.position = Vector3.Lerp (startPosition, eatPosition, curveValue);

			if (interpolateValue >= 1.0) 
			{
				isMoving = false;
			}
		}
	}
}
