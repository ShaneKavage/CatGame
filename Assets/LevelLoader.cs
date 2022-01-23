using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public string _Level;
    private float wait = 3f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadLevel());
    }
    public void LoadCreditsScene()
    {
        StartCoroutine(LoadCredits());
    }
    public void LoadGameMenu()
    {
        StartCoroutine(LoadMenu());
    }
    public void LoadInstructions()
    {
        StartCoroutine(Loadinstructions());
    }
    public void StopMusic()
    {
        SC_SCE_MusicManager obj = GameObject.FindGameObjectWithTag("MainScreenMusic").GetComponent<SC_SCE_MusicManager>();
        obj.DestroyME();
    }
    public void PlayButtonNoise()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator LoadMenu()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene("Menu");
    }
    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene(_Level);
    }
    IEnumerator LoadCredits()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene("Credits");
    }
    IEnumerator Loadinstructions()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(wait);

        SceneManager.LoadScene("Instructions");
    }
}
