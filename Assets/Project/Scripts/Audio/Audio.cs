using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : Singleton<Audio>
{
    //WARNING => This is a "Static" class.

    //Inspector����p
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] AudioSource _bgmSource;
    [SerializeField] AudioSource _seSource;
    [SerializeField] AudioClip[] _bgmClips;
    [SerializeField] string[] _bgmNames;
    [SerializeField] AudioClip[] _seClips;
    [SerializeField] string[] _seNames;

    //static�֐����g�p
    public static AudioMixer audioMixer;
    public static AudioSource bgmSource;
    public static AudioSource seSource;
    public static Dictionary <string, AudioClip> BGMs = new Dictionary<string, AudioClip>();
    public static Dictionary <string, AudioClip> SEs = new Dictionary<string, AudioClip>();

    //Fade In/Out�p�ϐ�
    readonly private static float _fadeSeconds = 0.5f; //Fade�ɂ����鎞��
    private static float _fadeing = 0;
    private static float _nowVolume = 0;

    public override void Awake()
    {
        RemoveDuplicates(); //Singleton
        Instantiate();

        //bgmSource.clip = bgmClips[0];
        //bgmSource.Play();
    }


    private void Instantiate()
    {
        audioMixer = _audioMixer;
        bgmSource = _bgmSource;
        seSource = _seSource;

        if (_bgmClips.Length != _bgmNames.Length)
        {
            Debug.LogWarning("Please set bgm in both clip and name. Maybe, some bgms are not set in both.");
        }
        if (_seClips.Length != _seNames.Length)
        {
            Debug.LogWarning("Please set se in both clip and name. Maybe, some ses are not set in both.");
        }

        for (int i = 0; i < _bgmClips.Length; i++)
        {
            BGMs[_bgmNames[i]] = _bgmClips[i];
        }
        for (int i = 0; i < _seClips.Length; i++)
        {
            SEs[_seNames[i]] = _seClips[i];
        }
    }

    //SEPlay�p�֐�
    public static void SEPlayOneShot(string key)
    {
        seSource.PlayOneShot(SEs[key]);
    }

    //Pause�֐��Q
    public static void BGMPause()
    {
        bgmSource.Pause();
    }
    public static void SEPause()
    {
        seSource.Pause();
    }

    //UnPose�֐��Q
    public static void BGMUnPause()
    {
        bgmSource.UnPause();
    }
    public static void SEUnPose()
    {
        seSource.UnPause();
    }

    //BGM���ʒ����֐�
    public static void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    //SE���ʒ����֐�
    public static void SetSEVolume(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }


    //BGM�ݒ�֐�
    public static void BGMSetter(string key)
    {
        audioMixer.GetFloat("BGM", out float nowvol);
        BGMFadeOut(nowvol);
        bgmSource.clip = BGMs[key];
    }

    //FadeOut�֐�
    private static void BGMFadeOut(float nowVolume)
    {
        _fadeing = 0;
        Audio._nowVolume = nowVolume;
        while (_fadeing < _fadeSeconds)
        {
            _fadeing += Time.deltaTime;
            SetBGMVolume(nowVolume * (1 - _fadeing / _fadeSeconds));
        }
        SetBGMVolume(0);
    }

    //FadeIn�֐�
    private static void BGMFadeIn(float now)
    {
        _fadeing = 0;
        _nowVolume = now;
        while (_fadeing < _fadeSeconds)
        {
            _fadeing += Time.deltaTime;
            SetBGMVolume(now * (_fadeing / _fadeSeconds));
        }
        SetBGMVolume(_nowVolume);
    }
}

