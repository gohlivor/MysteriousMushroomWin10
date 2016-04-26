using UnityEngine;
using System.Collections;

public class Scorescript : MonoBehaviour {
    public UILabel scorecount;
    
    static public int score=0;
	// Use this for initialization
	void Start () {
        scorecount.text = score.ToString();
	}
	// Update is called once per frame
	void Update () {
	
	}
    public void Addscore()
    {
        score++;
        scorecount.text = score.ToString();

    }
    void Awake() //so that the game object will not be destroyed when a new level is loaded
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
