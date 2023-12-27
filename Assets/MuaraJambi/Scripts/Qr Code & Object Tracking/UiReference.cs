using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MuaraJambi
{
    namespace Markerless
    {
        public class UiReference : MonoBehaviour
        {
            [Header("Buttons")]
            public GameObject kontenSejarahBtn;
            public GameObject faktaUnikBtn;
            public GameObject spesifikasiCandiBtn;

            [Header("Konten Sejarah")]
            public Image kontenSejarah_ObjectImage;
            public TMP_Text kontenSejarah_Title;
            public TMP_Text kontenSejarah_Konten;

            [Header("Fakta Unik")]
            public Image faktaUnik_ObjectImage;
            public TMP_Text faktaUnik_Title;
            public TMP_Text faktaUnik_Konten;

            [Header("Spesifikasi Candi")]
            public Image spesifikasiCandi_Image_;
            public TMP_Text spesifikasiCandi_Title;
            public TMP_Text spesifikasiCandi_Konten;

        }
    }
}

