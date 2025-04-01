using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button nextTrackButton;

    private void Start()
    {
        if (nextTrackButton != null)
        {
            nextTrackButton.onClick.AddListener(() =>
            {
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.OnButtonClickNextTrack();
                }
                else
                {
                    Debug.LogError("AudioManager instance is null.");
                }
            });
        }
    }
}
