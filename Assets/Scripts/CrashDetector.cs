using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] ParticleSystem bloodEffect;
  [SerializeField] float loadDelay = 0.5f;
  [SerializeField] AudioClip crashSFX;
  bool isDead = false;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Ground")
    {
      FindObjectOfType<PlayerController>().DisableControls();
      if (!isDead)
      {
        bloodEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        isDead = true;
      }
      Invoke("ReloadScene", loadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
