using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using MuaraJambi.Markerless;
using TMPro;

namespace MuaraJambi
{
    namespace QrCodeObjectTracking{
        public class QrCodeObjectTrackingController : MonoBehaviour
        {
            public ObjectTypes objectTypes;

            [Header("Buttons")]
            private GameObject kontenSejarahBtn;
            private GameObject faktaUnikBtn;
            private GameObject spesifikasiCandiBtn;

            [Header("Content Defenition")]
            //[SerializeField] private GameObject objectToDetectGameobject;

            //[SerializeField] private VideoClip kontentSejarah_Video;
            [SerializeField] private string kontenSejarah_Title;
            [SerializeField] private string kontenSejarah_Content;

            //[SerializeField] private Sprite faktaUnik_TittleImage;
            [SerializeField] private string faktaUnik_Tittle;
            [SerializeField] private string faktaUnik_Content;

            [HideInInspector] public Sprite spesifikasiCandi_Image;
            [HideInInspector] public string spesifikasiCandi_Tittle;
            [HideInInspector] public string spesifikasiCandi_Content;

            [Header("Content To Populate")]
            //[SerializeField] private VideoPlayer kontenSejarah_VideoPlayer;
            private TMP_Text kontenSejarah_Tittle_TmpText;
            private TMP_Text kontenSejarah_Content_TmpText;

            //[SerializeField] private Image faktaUnik_Tittle_Image;
            private TMP_Text faktaUnik_Tittle_TmpText;
            private TMP_Text faktaUnik_Content_TmpText;

            private Image spesifikasiCandi_Image_;
            private TMP_Text spesifikasiCandi_Tittle_TmpText;
            private TMP_Text spesifikasiCandi_Content_TmpText;

            private void Start()
            {
                UiReference uiReference = FindObjectOfType<UiReference>();

                //Buttons
                kontenSejarahBtn = uiReference.kontenSejarahBtn;
                faktaUnikBtn = uiReference.faktaUnikBtn;
                spesifikasiCandiBtn = uiReference.spesifikasiCandiBtn;

                //Konten Sejarah
                kontenSejarah_Tittle_TmpText = uiReference.kontenSejarah_Title;
                kontenSejarah_Content_TmpText = uiReference.kontenSejarah_Konten;

                //Fakta Unik
                faktaUnik_Tittle_TmpText = uiReference.faktaUnik_Title;
                faktaUnik_Content_TmpText = uiReference.faktaUnik_Konten;

                //Spesifikasi Candi
                spesifikasiCandi_Image_ = uiReference.spesifikasiCandi_Image_;
                spesifikasiCandi_Tittle_TmpText = uiReference.spesifikasiCandi_Title;
                spesifikasiCandi_Content_TmpText = uiReference.spesifikasiCandi_Konten;

            }

            public void PopulateTheParameter()
            {
                //objectToDetectGameobject.SetActive(true);

                //Konten Sejarah
                //kontenSejarah_VideoPlayer.clip = kontentSejarah_Video;
                kontenSejarah_Tittle_TmpText.text = kontenSejarah_Title;
                kontenSejarah_Content_TmpText.text = kontenSejarah_Content;

                kontenSejarahBtn.SetActive(true);
                faktaUnikBtn.SetActive(false);
                spesifikasiCandiBtn.SetActive(false);

                if (objectTypes == ObjectTypes.Candi)
                {
                    //Spesifikasi Candi
                    spesifikasiCandi_Image_.sprite = spesifikasiCandi_Image;
                    spesifikasiCandi_Tittle_TmpText.text = spesifikasiCandi_Tittle;
                    spesifikasiCandi_Content_TmpText.text = spesifikasiCandi_Content;

                    spesifikasiCandiBtn.SetActive(true);
                }

                else
                {
                    //Fakta Unik
                    //faktaUnik_Tittle_Image.sprite = faktaUnik_TittleImage;
                    faktaUnik_Tittle_TmpText.text = faktaUnik_Tittle;
                    faktaUnik_Content_TmpText.text = faktaUnik_Content;

                    faktaUnikBtn.SetActive(true);
                }


            }
        }
    } 
}