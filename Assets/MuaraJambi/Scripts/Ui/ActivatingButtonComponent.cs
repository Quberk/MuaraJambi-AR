using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatingButtonComponent : MonoBehaviour
{
    [SerializeField] private Button buttonToActivate;

    private void Start()
    {
        buttonToActivate.enabled = false;
    }

    public void ActivatingBtn()
    {
        buttonToActivate.enabled = true;
    }
}
