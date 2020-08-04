using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    private VideoPlayer _player;
    
    private string _pathToAirstrike;
    private string _pathToBaskt;
    private string _pathToRun;

    private void Start()
    {
        _player = GetComponent<VideoPlayer>();
        
        _pathToAirstrike = Path.Combine(Application.streamingAssetsPath, "airstrike.MOV");
        _pathToBaskt = Path.Combine(Application.streamingAssetsPath, "basket.MOV");
        _pathToRun = Path.Combine(Application.streamingAssetsPath, "run.MOV");

        _player.url = gameObject.CompareTag("Baskt") ? _pathToBaskt : _pathToRun;
        _player.Prepare();
        _player.SetDirectAudioMute(0, true);
        _player.Play();
    }
}
