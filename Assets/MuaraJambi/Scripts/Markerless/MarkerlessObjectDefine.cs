using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

namespace MuaraJambi{
    namespace Markerless{
        public class MarkerlessObjectDefine : MonoBehaviour
        {
            [HideInInspector]public ObjectTypes objectTypes;

            [Header("Populate Parameter")]
            [HideInInspector] public GameObject objectToDetect;

            [HideInInspector] public Sprite objectImage;

            [Header("Konten Sejarah")]
            [HideInInspector] public string kontenSejarah_title;
            [HideInInspector] public string kontenSejarah_content;

            [Header("Fakta Unik")]
            [HideInInspector] public string faktaUnik_title;
            [HideInInspector] public string faktaUnik_content;

            [Header("Spesiikasi Candi")]
            [HideInInspector] public Sprite spesifikasiCandi_image;
            [HideInInspector] public string spesifikasiCandi_title;
            [HideInInspector] public string spesifikasiCandi_content;

            // Start is called before the first frame update
            void Start()
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}

