using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuaraJambi
{
    namespace InfoPanel
    {
        public class InfoPanelController : MonoBehaviour
        {
            [SerializeField] private GameObject tentangAarimbiPanel;
            [SerializeField] private GameObject tutorialPanel;
            [SerializeField] private GameObject pengaturanPanel;

            [SerializeField] private GameObject infoMenuPanel;

            [SerializeField] private GameObject xButton;

            [SerializeField] private GameObject infoPanel;


            private void Start()
            {
                xButton.SetActive(false);
                infoPanel.SetActive(false);

                infoMenuPanel.SetActive(true);

                tentangAarimbiPanel.SetActive(false);
                tutorialPanel.SetActive(false);
                pengaturanPanel.SetActive(false);
            }

            public void ActivatingPanel(GameObject activatingPanel)
            {
                activatingPanel.SetActive(true);
            }

            public void ClosingButton()
            {
                if (tentangAarimbiPanel.activeInHierarchy)
                    tentangAarimbiPanel.SetActive(false);
                else if (tutorialPanel.activeInHierarchy)
                    tutorialPanel.SetActive(false);
                else if (pengaturanPanel.activeInHierarchy)
                    pengaturanPanel.SetActive(false);
                else
                {
                    infoPanel.SetActive(false);
                    xButton.SetActive(false);
                }
                    

            }
        }
    }
}