using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuScript : MonoBehaviour
{
	public static int howManyPlayers;
    public GameObject Info;
    public GameObject Exit;
    public void two_player()
	{
		SoundManagerScript.buttonAudioSource.Play();
		howManyPlayers = 2;
		SceneManager.LoadScene("Lucky");
	}

	public void three_player()
	{
		SoundManagerScript.buttonAudioSource.Play();
		howManyPlayers = 3;
		SceneManager.LoadScene("Lucky");
	}

	public void four_player()
	{
		SoundManagerScript.buttonAudioSource.Play();
		howManyPlayers = 4;
		SceneManager.LoadScene("Lucky");
	}

    public void quit()
    {
        SoundManagerScript.buttonAudioSource.Play();
        Application.Quit();
    }
    public void InfoMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        Info.SetActive(true);
    }
    public void ReturnToMainPage()
    {
        SoundManagerScript.buttonAudioSource.Play();
        Info.SetActive(false);
    }
    void Start()

	{
		Time.timeScale = 1;
	}
}
