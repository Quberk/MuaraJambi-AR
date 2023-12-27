using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using MuaraJambi.Markerless;

namespace MuaraJambi{
    namespace Markerless
    {
        public class ContentParameterCatcher : MonoBehaviour
        {
            MarkerlessObjectDefine markerlessObjectDefine;

            PlaceOnPlane placeOnPlaneManger;

            public ObjectTypes objectTypes;

            [SerializeField] private GameObject kontenSejarah_Button;
            [SerializeField] private GameObject spesifikasiCandiButton;
            [SerializeField] private GameObject faktaUnikButton;

            [Header("Populate Parameter")]
            [SerializeField] private GameObject parentObjectToDetect;
            private GameObject objectToDetect;

            [Header("Konten Sejarah")]
            [SerializeField] private Image kontenSejarah_ObjectImage;
            [SerializeField] private TMP_Text kontenSejarah_title;
            [SerializeField] private TMP_Text kontenSejarah_content;

            [Header("Fakta Unik")]
            [SerializeField] private Image faktaUnik_ObjectImage;
            [SerializeField] private TMP_Text faktaUnik_title;
            [SerializeField] private TMP_Text faktaUnik_content;

            [Header("Spesiikasi Candi")]
            [SerializeField] private Image spesifikasiCandi_image;
            [SerializeField] private TMP_Text spesifikasiCandi_title;
            [SerializeField] private TMP_Text spesifikasiCandi_content;

            // Start is called before the first frame update
            void Start()
            {
                markerlessObjectDefine = GameObject.FindObjectOfType<MarkerlessObjectDefine>();
                placeOnPlaneManger = GameObject.FindObjectOfType<PlaceOnPlane>();

                ///-------------------------------------POPULATE THE PARAMETER---------------------
                ///
                //objectTypes = markerlessObjectDefine.objectTypes;
                objectToDetect = markerlessObjectDefine.objectToDetect;
                kontenSejarah_ObjectImage.sprite = markerlessObjectDefine.objectImage;
                kontenSejarah_title.text = markerlessObjectDefine.kontenSejarah_title;
                kontenSejarah_content.text = markerlessObjectDefine.kontenSejarah_content;
                faktaUnik_ObjectImage.sprite = markerlessObjectDefine.objectImage;
                faktaUnik_title.text = markerlessObjectDefine.faktaUnik_title;
                faktaUnik_content.text = markerlessObjectDefine.faktaUnik_content;

                kontenSejarah_Button.SetActive(true);

                switch (objectTypes)
                {
                    case (ObjectTypes.Artefak):
                        spesifikasiCandiButton.SetActive(false);
                        faktaUnikButton.SetActive(true);
                        break;

                    case (ObjectTypes.Candi):
                        spesifikasiCandiButton.SetActive(true);
                        faktaUnikButton.SetActive(false);
                        spesifikasiCandi_image.sprite = markerlessObjectDefine.spesifikasiCandi_image;
                        spesifikasiCandi_title.text = markerlessObjectDefine.spesifikasiCandi_title;
                        spesifikasiCandi_content.text = markerlessObjectDefine.spesifikasiCandi_content;
                        break;

                    default:
                        break;
                }

                //Instantiate Object to Scene
                /*GameObject myObject = Instantiate(objectToDetect, transform.position, Quaternion.identity);
                myObject.transform.SetParent(parentObjectToDetect.transform);
                myObject.transform.localPosition = Vector3.zero;
                myObject.transform.localScale = new Vector3(0.0100759f, 0.0100759f, 0.0100759f);*/

                //Instantiate Object to Scene
                placeOnPlaneManger.m_PlacedPrefab = objectToDetect;

                Destroy(markerlessObjectDefine.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

