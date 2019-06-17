﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public GameObject dialogBox;
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.isLooping = false;
        videoPlayer.waitForFirstFrame = true;
        videoPlayer.loopPointReached += EndReached;
        StartCoroutine(PlayVideo());
        if (GameObject.FindGameObjectWithTag("AudioManager"))
        {
            FindObjectOfType<AudioManager>().StopAllAudio();
        }


    }

    // Update is called once per frame
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
        {
            yield return null;
            videoPlayer.Prepare();
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        videoPlayer.Pause();
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("End of the video animation");
        videoPlayer.Pause();
        //dialogBox.SetActive(true);
        continueToGame();
    }

    public void onBackButtonPress()
    {
        FindObjectOfType<SceneFader>().FadeTo("LevelSelector");
    }

    public void onContinueButtonPress()
    {
        continueToGame();
    }

    void continueToGame()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelOneVideoAnimation"))
        {
            //add some type of way via shared pref or something to check and see what mode the user is in
            //if its beginner do beginner 1 - 4 levels
            //else do advanced which is level1a etc
            //for rn we will default to doing beginner untill we setup a way to toggle the users choice and save it through plays
            //seems like a shared pref will do the job
            //FindObjectOfType<SceneFader>().FadeTo("Level1a");
            //also should we change the music? to the ones used in level 6 and 7?

            if (GameValues.diffuclty == GameValues.Difficulties.Beginner)
            {
                FindObjectOfType<SceneFader>().FadeTo("BeginnerLevel1a");
            }
            else
            {
                FindObjectOfType<SceneFader>().FadeTo("Level1a");
            }



            FindObjectOfType<AudioManager>().Play("captainscurvy");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelTwoVideoAnimation"))
        {
            if (GameValues.diffuclty == GameValues.Difficulties.Beginner)
            {
                FindObjectOfType<SceneFader>().FadeTo("BeginnerLevel2a");
            }
            else
            {
                FindObjectOfType<SceneFader>().FadeTo("Level2a");
            }
            FindObjectOfType<AudioManager>().Play("captainscurvy");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelThreeVideoAnimation"))
        {
            if (GameValues.diffuclty == GameValues.Difficulties.Beginner)
            {
                FindObjectOfType<SceneFader>().FadeTo("BeginnerLevel3a");
            }
            else
            {
                FindObjectOfType<SceneFader>().FadeTo("Level3a");
            }
            FindObjectOfType<AudioManager>().Play("captainscurvy");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelFourVideoAnimation"))
        {
            if (GameValues.diffuclty == GameValues.Difficulties.Beginner)
            {
                FindObjectOfType<SceneFader>().FadeTo("BeginnerLevel4a");
            }
            else
            {
                FindObjectOfType<SceneFader>().FadeTo("Level4a");
            }
            FindObjectOfType<AudioManager>().Play("captainscurvy");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelFiveVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level5");
            FindObjectOfType<AudioManager>().Play("masterylevelmusic");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelSixVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level6a");
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelSevenVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level7a");
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelEightVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level8");
            FindObjectOfType<AudioManager>().Play("masterylevelmusic");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelNineVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level9a");
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelTenVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level10");
            FindObjectOfType<AudioManager>().Play("quizgamenoise");

        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelElevenVideoAnimation"))
        {
            FindObjectOfType<SceneFader>().FadeTo("Level11");
            FindObjectOfType<AudioManager>().Play("quizgamenoise");
        }
    }
}