using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;

    public static Vocals instance;

    Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

        anim = GetComponent<Animator>();
    }

    public void Say(AudioObject clip)
    {
        if(source.isPlaying)
          source.Stop();

          source.PlayOneShot(clip.clip);

          SubtitleUI.instance.SetSubtitle(clip.subtitle, clip.clip.length);
    }

    public void SheepleSnakTalk()
    {
        anim.Play("snak", -1, 0f);
    } 

    public void AskForSnak()
    {
        StartCoroutine(PlayActions());
    }

    private IEnumerator PlayActions()
    {
        anim.Play("talk", -1, 0f);
        yield return new WaitForSeconds(2);
        anim.Play("snak", -1, 0f);
        yield return new WaitForSeconds(3);
        anim.Play("sad", -1, 0f);
    }

    public void CollectSnak()
    {
        StartCoroutine(PlayCollectSnakAnimation());
    }

    private IEnumerator PlayCollectSnakAnimation()
    {
        anim.Play("eating", -1, 0f);
        yield return new WaitForSeconds(5);
        anim.Play("talk", -1, 0f);
        yield return new WaitForSeconds(3);
        anim.Play("happy", -1, 0f);
    }


}
