
private var buttonWidth:int = 200;
private var buttonHeight:int = 50;
private var spacing:int = 100;

function OnGui()
{
	 GUI.Box (Rect (10,10,100,90), "Loader Menu");
	 print ("it worked");


	if(GUI.Button(Rect(Screen.width/2 - buttonWidth/2, Screen.height/2 - buttonHeight/2 - spacing, buttonWidth, buttonHeight), "Play")) 
	{
		Application.LoadLevel("Mushroomscene");
		
	}
}


