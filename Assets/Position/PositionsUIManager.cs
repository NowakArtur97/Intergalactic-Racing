using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsUIManager : MonoBehaviour
    {
        private List<PositionUI> _positionsUI;

        // TODO: Unsubscibe (?)
        private void Start() => FindObjectOfType<PositionsManager>().PositionsEvent += UpdatePositionsUI;

        public void SetPositionsUI(List<PositionUI> positionsUI) => _positionsUI = positionsUI;

        public void UpdatePositionsUI(List<Vehicle> vehiclesPositions)
        {
            for (int positionIndex = 0; positionIndex < vehiclesPositions.Count; positionIndex++)
            {
                PositionUI positionUI = _positionsUI[positionIndex];

                // TODO: PositionsUIManager: Real name(?)
                positionUI.UpdateNameText(vehiclesPositions[positionIndex].gameObject.name);
                positionUI.UpdateImage(vehiclesPositions[positionIndex].GetComponent<SpriteRenderer>().sprite);
            }
        }
    }
}
