using UnityEngine;
using System.Collections;

public class PrintScore : MonoBehaviour {
    public UILabel endscore;
    private Scorescript scoreend;
	// Use this for initialization
	void Start () {
        endscore = this.gameObject.GetComponent<UILabel>();
        scoreend = GameObject.FindGameObjectWithTag("Scoremanager").GetComponent<Scorescript>();
        //this.gameObject.SetActive(false);

        if (endscore != null)
        {
        endscore.text = scoreend.scorecount.text;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
