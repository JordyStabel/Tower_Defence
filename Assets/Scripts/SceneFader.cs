using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Image loadingImage;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    /// <summary>
    /// Fade in effect for image
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            //Implement a curve effect
            float alpha = curve.Evaluate(t);
            //Black with different alpha value each frame
            loadingImage.color = new Color(0f, 0f, 0f, alpha);
            //Wait a frame before moving on, effectively creating a update like methode
            yield return 0;
        }
    }

    /// <summary>
    /// Fade out effect for image
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;

            float alpha = curve.Evaluate(t);

            loadingImage.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
        //Load scene
        SceneManager.LoadScene(scene);
    }
}