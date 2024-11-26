using FMODUnity;
using FMOD.Studio;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }
  
  private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one audio manager in the scene.");
        }
        instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateEventInstance(EventReference eventreference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventreference);
        return eventInstance;   
    }
}
