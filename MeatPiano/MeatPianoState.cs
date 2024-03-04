using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class MeatPianoState : MonoBehaviour
    {
        [SerializeField] private AIConversant _conversant;
        [SerializeField] private Dialogue dialogueEntry;
        [SerializeField] private Dialogue dialogueSuccessCustom;
        [SerializeField] private Dialogue dialogueSuccessHeart;
        [SerializeField] private Dialogue dialogueFail;
        [SerializeField] private GameObject playSongPanel;
        [SerializeField] private GameObject playCustomSongPanel;

        [SerializeField] private GameObject failPanel;


        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _heartAudioSource;

        [SerializeField] private AudioClip _heartAndSoulClip;
        [SerializeField] private AudioClip _failClip;

        [SerializeField] private GameObject scrolls;
        [SerializeField] private SongCreator songPlayer;
        [SerializeField] private GameObject songParent;
        [SerializeField] private string currentState;
        [SerializeField] private GameObject _meat;
        [SerializeField] private CaveSaveSettings _saveManager;

        // Start is called before the first frame update
        void Start()
        {
            _saveManager.LoadGame();
            currentState = _saveManager.GetStateOfMeatPiano();
            SetUpState();

        }

        public void StopPlaying()
        {
            _audioSource.Stop();
        }

        public void ChangeStateDebug(string newState)
        {
            currentState = newState;
            SetUpState();
        }

        void SetUpState()
        {
            if (currentState == "successfulcustom")
            {
                _conversant.ChangeDialogue(dialogueSuccessCustom);
                playCustomSongPanel.SetActive(true);
                songPlayer.SwitchToPlayerSong();
                songPlayer.MakeSongActive();
            }
            else if (currentState == "successfulheart")
            {
                _conversant.ChangeDialogue(dialogueSuccessHeart);
                playSongPanel.SetActive(true);
                _heartAudioSource.clip = _heartAndSoulClip;
                _heartAudioSource.Play();
            }
            else if (currentState == "failed")
            {
                _conversant.ChangeDialogue(dialogueFail);
                failPanel.SetActive(true);
                _heartAudioSource.clip = _failClip;
                _heartAudioSource.Play();

            }
            else if (currentState == "entryscroll")
            {
                scrolls.SetActive(true);
                _conversant.ChangeDialogue(dialogueEntry);

            }
            else if (currentState == "entry")
            {
                _meat.SetActive(true);
                scrolls.SetActive(false);
                _conversant.ChangeDialogue(dialogueEntry);

            }
            else if (currentState == "sceneComplete")
            {
                scrolls.SetActive(false);
                _meat.SetActive(false);

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
