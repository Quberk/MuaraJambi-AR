using UnityEngine;
using MuaraJambi.Markerless;

namespace MuaraJambi
{
    namespace QrCodeObjectTracking
    {
        public class ButtonsPopUpController : MonoBehaviour
        {
            [SerializeField] private ObjectTypes objectType;

            [SerializeField] private GameObject nonActiveButtons;

            [Header("Buttons")]
            [SerializeField] private GameObject kontenSejarahBtn;
            [SerializeField] private GameObject faktaUnikBtn;
            [SerializeField] private GameObject spesifikasiCandiBtn;


            public void ObjectDetected()
            {
                nonActiveButtons.SetActive(true);
                kontenSejarahBtn.SetActive(true);

                if (objectType == ObjectTypes.Artefak)
                {
                    faktaUnikBtn.SetActive(true);
                }

                else
                {
                    spesifikasiCandiBtn.SetActive(true);
                }
            }

            public void Activating(GameObject target)
            {
                target.SetActive(true);
            }

            public void Deactivating(GameObject target)
            {
                target.SetActive(false);
            }
        }
    }
}
