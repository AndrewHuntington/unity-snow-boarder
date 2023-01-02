using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] ParticleSystem bloodEffect;
  [SerializeField] float loadDelay = 0.5f;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Ground")
    {
      bloodEffect.Play();
      Invoke("ReloadScene", loadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}