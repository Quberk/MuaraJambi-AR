using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace MuaraJambi
{
    namespace Video{
        public class VideoPlayerController : MonoBehaviour
        {
            [SerializeField] private VideoPlayer videoPlayer;

            [SerializeField] private GameObject playDescription;
            [SerializeField] private GameObject pauseDescription;

            [SerializeField] private GameObject thumbNail_Gameobject;

            private VideoStatus videoStatus;

            private void Start()
            {
                videoPlayer.Play();
                
                videoStatus = VideoStatus.Off;
                playDescription.SetActive(true);
                pauseDescription.SetActive(false);
            }

            private void TurnOffVideo()
            {
                videoPlayer.Pause();
                videoStatus = VideoStatus.Off;
                playDescription.SetActive(false);
                pauseDescription.SetActive(true);
            }

            private void TurnOnVideo()
            {
                videoPlayer.Play();
                videoStatus = VideoStatus.On;
                playDescription.SetActive(false);
                pauseDescription.SetActive(false);

                thumbNail_Gameobject.SetActive(false);
            }

            public void VideoPlayerButton()
            {
                if (videoStatus == VideoStatus.Off)
                {
                    TurnOnVideo();
                    return;
                }

                TurnOffVideo();
            }

        }

        public enum VideoStatus
        {
            On,
            Off
        }

    }
}
