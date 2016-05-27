#pragma strict

public var VignetteScript : Vignetting;
public var AnimCurveBeginning : AnimationCurve;
public var AnimCurveEnding : AnimationCurve;
public var EndCloseBeginning : int;
public var EndCloseEnding : int;
public var DurationBeginning : float;
public var DurationEnding : float;
public var Delay : float;

private var DelayTimer : float;
private var ElapsedTime : float;
private var IsClosing : boolean;

function Start () 
{
	IsClosing = false;
	ElapsedTime = 0.0f;
	DelayTimer = 0.0f;
}

function Update () 
{
	if(IsClosing)
	{
		DelayTimer += Time.deltaTime;
		if(DelayTimer > Delay)
		{
			ElapsedTime += Time.deltaTime;

			if(ElapsedTime > (DurationBeginning + DurationEnding))
			{
				IsClosing = false;
				ElapsedTime = DurationBeginning + DurationEnding;
			}

			var InterpolateTime = ElapsedTime;
			var InterpolateValue : float;
			var CurveValue : float;
			var NewIntensity : float;

			if(ElapsedTime < DurationBeginning) //AnimCurve2
			{
				InterpolateValue = InterpolateTime / DurationBeginning;
				CurveValue = AnimCurveEnding.Evaluate (InterpolateValue);
				NewIntensity = Mathf.Lerp (0, EndCloseBeginning, CurveValue);
				InterpolateTime -= DurationBeginning;
			}
			else //AnimCurve1
			{
				InterpolateValue = InterpolateTime / DurationEnding;
				CurveValue = AnimCurveBeginning.Evaluate (InterpolateValue);
				NewIntensity = Mathf.Lerp (EndCloseBeginning, EndCloseEnding, CurveValue);
			}

			VignetteScript.intensity = NewIntensity;
		}
	}
}
function StartFade()
{
	IsClosing = true;
}