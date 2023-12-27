using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MuaraJambi
{
    namespace UI
    {
        public class MenuDropdownController : MonoBehaviour
        {
            [HideInInspector] public int dropDownValue;

            [SerializeField] private Dropdown dropDown;

            [SerializeField] private GameObject[] scrollViews;

            private void Update() {
                dropDownValue = dropDown.value;
            }

            public void OnDropdownValueChanged()
            {
                for (int i = 0; i < scrollViews.Length; i++)
                {
                    scrollViews[i].SetActive(false);
                }

                dropDownValue = dropDown.value;
                scrollViews[dropDown.value].SetActive(true);
            }

            public void ResetDropdown(){
                for (int i = 0; i < scrollViews.Length; i++)
                {
                    scrollViews[i].SetActive(false);
                }

                dropDownValue = dropDown.value;
                scrollViews[dropDown.value].SetActive(true);
            }

    }
}
}