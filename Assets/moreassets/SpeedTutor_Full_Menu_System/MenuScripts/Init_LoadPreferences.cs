﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpeedTutorMainMenuSystem
{
    public class Init_LoadPreferences : MonoBehaviour
    {
        #region Variables
        //BRIGHTNESS
        [Space(20)]
        [SerializeField] private Brightness brightnessEffect;
        [SerializeField] private Text brightnessText;
        [SerializeField] private Slider brightnessSlider;

        //VOLUME
        [Space(20)]
        [SerializeField] private Text volumeText;
        [SerializeField] private Slider volumeSlider;

        //SENSITIVITY
        [Space(20)]
        [SerializeField] private Text controllerText;
        [SerializeField] private Slider controllerSlider;

        //INVERT Y
        [Space(20)]
        [SerializeField] private Toggle invertYToggle;

        [Space(20)]
        [SerializeField] private bool canUse = false;
        [SerializeField] private MenuController menuController;
        #endregion

        private void Awake()
        {
            Debug.Log("Loading player prefs test");

            if (canUse)
            {
                //VOLUME
                if (PlayerPrefs.HasKey("masterVolume"))
                {
                    float localVolume = PlayerPrefs.GetFloat("masterVolume");

                    volumeText.text = localVolume.ToString("0.0");
                    volumeSlider.value = localVolume;
                    AudioListener.volume = localVolume;
                }
                else
                {
                    menuController.ResetButton("Audio");
                }

                //CONTROLLER SENSITIVITY
                if (PlayerPrefs.HasKey("masterSen"))
                {
                    float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                    controllerText.text = localSensitivity.ToString("0");
                    controllerSlider.value = localSensitivity;
                    menuController.controlSenFloat = localSensitivity;
                }
                else
                {
                    menuController.ResetButton("Graphics");
                }

            }
        }
    }
}
