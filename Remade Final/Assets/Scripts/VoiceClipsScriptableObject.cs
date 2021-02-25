using UnityEngine;

[CreateAssetMenu(fileName = "VoiceClips", menuName = "clips", order = 0)]
public class VoiceClipsScriptableObject : ScriptableObject
{
    [SerializeField] public AudioClip[] voiceLines = new AudioClip[]{};

}