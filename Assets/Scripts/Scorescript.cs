using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scorescript : MonoBehaviour {
    public Text scorecount;
    
    static public int score=0;
	// Use this for initialization
	void Start () {
        scorecount.text = "Score: " + score.ToString();
	}
	// Update is called once per frame
	void Update () {
	
	}
    public void Addscore()
    {
        score++;
        scorecount.text = "Score: " + score.ToString();

    }
    void Awake() //so that the game object will not be destroyed when a new level is loaded
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
