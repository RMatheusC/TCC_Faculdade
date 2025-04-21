using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class ConfigScene : MonoBehaviour
{
    public int sala = 0;

    #region resolution

    public Dropdown DropResolution;
    public Dropdown DropQuality;
    public Toggle TgWindow;

    private List<string> resolutions = new List<string>();
    private List<string> quality = new List<string>();


    public void setWinMode() {
        if (TgWindow.isOn)
        {
            Screen.fullScreen = false;
        }
        else {
            Screen.fullScreen = true;
        }
    }

    public void setResolution() {
        String[] res = resolutions[DropResolution.value].Split('X');
        int w = Convert.ToInt16(res[0].Trim());
        int h = Convert.ToInt16(res[1].Trim());
        Screen.SetResolution(w, h, Screen.fullScreen);
    }

    public void setQuality() {
        QualitySettings.SetQualityLevel(DropQuality.value, true);
    }

    public void Exit() {
        Application.Quit();
    }
    #endregion

    #region som
    public float masterVolume;
    public float fxVolume;
    public float musicVolume;

    public Slider SliderMaster;
    public Slider SliderFx;
    public Slider SliderMusic;

    public void MasterVolume(float volume) {
        masterVolume = volume;
        AudioListener.volume = masterVolume;

        PlayerPrefs.SetFloat("Master", masterVolume);
    }
    public void FXvolume(float volume)
    {
        fxVolume = volume;
        GameObject[] fxs = GameObject.FindGameObjectsWithTag("Fx");
        for (int i = 0; i < fxs.Length; i++) {
            fxs[i].GetComponent<AudioSource>().volume = fxVolume;//puxar todos os objetos com a tag "Fx"
        }

        PlayerPrefs.SetFloat("fxs", fxVolume);
    }
    public void MusicVolume(float volume)
    {
        musicVolume = volume;
        GameObject[] musics = GameObject.FindGameObjectsWithTag("Musica");
        for (int i = 0; i < musics.Length; i++)
        {
            musics[i].GetComponent<AudioSource>().volume = musicVolume;//puxar todos os objetos com a tag "Musica"
        }

        PlayerPrefs.SetFloat("music", musicVolume);
    }
    #endregion

    #region Config


    #endregion

    #region
    public void Voltar(){
        SceneManager.LoadScene(1);
    }
    #endregion
    void Start()
    {
        #region resolution array
        Resolution[] arrResolution = Screen.resolutions;
        foreach (Resolution r in arrResolution)
        {
            resolutions.Add(string.Format("{0} x {1}", r.width, r.height));
        }
        DropResolution.AddOptions(resolutions);
        DropResolution.value = (resolutions.Count - 1);

        quality = QualitySettings.names.ToList<string>();
        DropQuality.AddOptions(quality);
        DropQuality.value = QualitySettings.GetQualityLevel();
        #endregion

        #region sound components
        SliderMaster.value = PlayerPrefs.GetFloat("Master");
        SliderFx.value = PlayerPrefs.GetFloat("fxs");
        SliderMusic.value = PlayerPrefs.GetFloat("music");
        #endregion 
    }

}
