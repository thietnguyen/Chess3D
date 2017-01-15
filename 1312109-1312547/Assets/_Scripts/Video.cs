using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class Video : MonoBehaviour {

    public MovieTexture movie;
    
    // Use this for initialization
	void Start () {
        movie.Play();    
	}
	
    void OnMouseDown()
    {
        movie.Stop();
        Application.LoadLevel("TwoPlayer");
    }

	// Update is called once per frame
	void Update () {
	    if(!movie.isPlaying)
        {
            Application.LoadLevel("TwoPlayer");
        }
	}
}
