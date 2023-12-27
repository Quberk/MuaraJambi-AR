using UnityEngine;
using TMPro;
using System.Collections.Generic;
using MuaraJambi.Markerless;
using MuaraJambi.UI;

namespace MuaraJambi
{
    namespace SearchTool
    {
        public class SearchToolController : MonoBehaviour
        {
            [SerializeField] private TMP_InputField searchInputfield;

            [Header("Default Content")]
            [SerializeField] private MenuDropdownController menuDropdownController;
            [SerializeField] private GameObject artefactDefaultContent;
            [SerializeField] private GameObject candiDefaultContent;
            private List<ContentDefenition> defaultContentChildren;

            [Header("Search Content")]
            [SerializeField] private GameObject searchContent;
            private List<GameObject> searchContentChildren;

            private string lastInputFieldText;

            // Start is called before the first frame update
            void Start()
            {
                lastInputFieldText = "";
                defaultContentChildren = new List<ContentDefenition>();
                searchContentChildren = new List<GameObject>();

                SetTheDefaultContent();

                foreach (ContentDefenition contentDefChild in defaultContentChildren)
                {
                    GameObject children = Instantiate(contentDefChild.gameObject);
                    children.transform.SetParent(searchContent.transform);
                    children.transform.localScale = new Vector3(1f, 1f, 1f);
                }

                //Check Debug
                /*foreach (ContentDefenition content in defaultContentChildren)
                {
                    Debug.Log("Content Children telah masuk " + content.gameObject.name);
                }*/
            }

            // Update is called once per frame
            void Update()
            {
                if (searchInputfield.text == lastInputFieldText)
                {
                    lastInputFieldText = searchInputfield.text;
                    return;
                }

                lastInputFieldText = searchInputfield.text;

                ResetSearchContent();

                SetTheDefaultContent();

                Searching();

                //Check Debug
                /*foreach (GameObject gameObjectCheck in searchContentChildren)
                {
                    Debug.Log("Content yang terbaca sama namanya adalah : " +gameObjectCheck.name);
                }*/
            }

            void Searching(){
                #region Search Input Text
                /// BREAK SEARCH INPUT TEXT INTO CHARACTERS
                string searchInputText = searchInputfield.text.ToLower();

                string[] searchCharacters = new string[searchInputText.Length];
                for (int i = 0; i < searchInputText.Length; i++)
                {
                    searchCharacters[i] = searchInputText[i].ToString();
                    //Debug.Log("Search Character : "+searchCharacters[i]);
                }
                #endregion


                foreach (ContentDefenition contentDefChild in defaultContentChildren)
                {
                    if (searchInputText == ""){
                        GameObject children = Instantiate(contentDefChild.gameObject);
                        children.transform.SetParent(searchContent.transform);
                        children.transform.localScale = new Vector3(1f, 1f, 1f);
                        continue;
                    }

                    #region Content Text
                    ///BREAK CONTENT DEFENITION TEXT NAME INTO CHARACTERS
                    string childName = contentDefChild.contentName.ToLower();

                    string[] childNameCharacters = new string[childName.Length];
                    for (int i = 0; i < childName.Length; i++)
                    {
                        
                        childNameCharacters[i] = childName[i].ToString();
                        //Debug.Log("Child Name Character : "+childNameCharacters[i]);
                    }
                    #endregion

                    #region Checking One by One the Character of Search Inputfield with Content Name
                    //Checking
                    GameObject contentToAdd = contentDefChild.gameObject;

                    for (int i = 0; i < searchInputText.Length; i++)
                    {
                        if (searchCharacters.Length > childNameCharacters.Length)
                        {
                            contentToAdd = null;
                            break;
                        }
                        else if (searchCharacters[i] == childNameCharacters[i])
                        {
                            contentToAdd = contentDefChild.gameObject;
                        }
                        else
                        {
                            contentToAdd = null;
                            break;
                        }
                        
                    }

                    if (contentToAdd != null)
                        searchContentChildren.Add(contentToAdd);
                    #endregion
                }

                Debug.Log(searchContentChildren.Count);

                #region Inserting Content into SearchContent
                for (int i = 0; i <searchContentChildren.Count; i++)
                {
                    GameObject children = Instantiate(searchContentChildren[i]);
                    children.transform.SetParent(searchContent.transform);
                    children.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                #endregion
            }

            void ResetSearchContent()
            {
                    searchContentChildren.Clear();
                    defaultContentChildren.Clear();
                foreach(Transform searchContent1 in searchContent.transform)
                {

                    Destroy(searchContent1.gameObject);
                }
            }

            public void ResetSearchTool(){
                ResetSearchContent();
                SetTheDefaultContent();
                Searching();
                searchInputfield.text = "";
            }

            void SetTheDefaultContent(){
                //Find all the Children of Content
                menuDropdownController.OnDropdownValueChanged();
                GameObject parentContent = candiDefaultContent;

                if (menuDropdownController.dropDownValue > 0)
                    parentContent = artefactDefaultContent;

                foreach (Transform child in parentContent.transform)
                {
                    defaultContentChildren.Add(child.gameObject.GetComponent<ContentDefenition>());
                    
                }
            }
        }
    }
}