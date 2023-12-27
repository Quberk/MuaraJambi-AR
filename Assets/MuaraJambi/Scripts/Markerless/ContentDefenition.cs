using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MuaraJambi.Markerless;

namespace MuaraJambi{
    namespace Markerless{
        public class ContentDefenition : MonoBehaviour
        {
            public ObjectTypes objectTypes;
            public string contentName;

            [SerializeField] private GameObject objectToDetectPrefab;
            private MarkerlessObjectDefine markerlessObjectDefine;

            [SerializeField] private Sprite objectImage;

            [Header("Konten Sejarah")]
            [SerializeField] private string kontenSejarah_title;
            [SerializeField] private string kontenSejarah_content;

            [Header("Fakta Unik")]
            [SerializeField] private string faktaUnik_title;
            [SerializeField] private string faktaUnik_content;

            [Header("Spesiikasi Candi")]
            [HideInInspector] public Sprite spesifikasiCandi_image;
            [HideInInspector] public string spesifikasiCandi_title;
            [HideInInspector] public string spesifikasiCandi_content;

            // Start is called before the first frame update
            void Start()
            {
                markerlessObjectDefine = FindObjectOfType<MarkerlessObjectDefine>();
            }

            public void TransferParameter()
            {
                SceneManager.LoadScene("MarkerlessScene");

                ///-------------------POPULATE THE MARKERLESS OBJECT DEFINE-------------------
                ///
                markerlessObjectDefine.objectTypes = objectTypes;
                markerlessObjectDefine.objectImage = objectImage;
                markerlessObjectDefine.objectToDetect = objectToDetectPrefab;
                markerlessObjectDefine.kontenSejarah_title = kontenSejarah_title;
                markerlessObjectDefine.kontenSejarah_content = kontenSejarah_content;
                markerlessObjectDefine.faktaUnik_title = faktaUnik_title;
                markerlessObjectDefine.faktaUnik_content = faktaUnik_content;
            }

        }

    }
}
