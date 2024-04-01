using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MaterialControllerEffect : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float startAppearance = 1f;
    [SerializeField] private UnityEvent onDissolved;
    [SerializeField] private UnityEvent onReappeared;


    [SerializeField] private bool isDissolving, reAppearing;


    private void Start()
    {
        material.SetFloat("_Fade", startAppearance);
    }
    public void Dissolve()
    {
        isDissolving = true;

    }

    public void ReAppear()
    {
        fadeDuration = 0f;
        reAppearing = true;
    }

    private void Update()
    {
        if (isDissolving == true)
        {

            fadeDuration -= Time.deltaTime;

            if (fadeDuration <= 0f)
            {
                fadeDuration = 0f;
                isDissolving = false;
            }
            if (fadeDuration == 0f)
            {
                onDissolved.Invoke();
            }

            material.SetFloat("_Fade", fadeDuration);
        }

        else if (reAppearing == true)
        {
            fadeDuration += Time.deltaTime / 2;

            if (fadeDuration >= 1f)
            {
                fadeDuration = 1f;
                reAppearing = false;
            }
            if (fadeDuration == 1f)
            {
                onReappeared.Invoke();
            }

            material.SetFloat("_Fade", fadeDuration);
        }

    }

}