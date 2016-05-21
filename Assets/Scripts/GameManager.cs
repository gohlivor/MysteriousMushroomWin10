using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void SetLiveTile(string textmessage) //you should update this with your own images
    {
        UnityEngine.WSA.Tile.main.Update("ms-appx:///Data/StreamingAssets/TanksIcon_150x150.png",
               "ms-appx:///Data/StreamingAssets/TanksIcon_310x150.png", string.Empty, textmessage);
    }
}
