using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    [SerializeField]  Camera camera;
    [SerializeField] TrackHandler track;
    [SerializeField] Image pause, play;
 
    // Update is called once per frame
    void Update()
    {     
        // Moving by user
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        track.moveSpeed +=(Time.deltaTime);

        // Increase speed by pressing button By user)
        if (Input.GetButton("MoveForward"))
        {
            track.moveSpeed = track.moveSpeed + (Time.deltaTime * 2);
        }
        //Decrease speed by user
        if (Input.GetButton("Jump"))
        {
            // brake Pressed
            track.moveSpeed = track.moveSpeed - (Time.deltaTime * 15);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Obstacle" || other.transform.tag == "Border")
        {
            camera.transform.parent = null;
            gameObject.SetActive(false);
            track.enabled = false;
            Invoke("Gameover", 0.5f);
        }
    }

    private void Gameover()
    {
        //Save data on SharedPreferences
        PlayerPrefs.SetInt("CurrentScore", track.score);
        SceneManager.LoadScene(2);
    }

    public void onPauseClicked()
    {
        play.gameObject.SetActive(true);
        pause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void onPlayClicked()
    {
        play.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
