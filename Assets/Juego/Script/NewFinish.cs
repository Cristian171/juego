using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;


namespace MoreMountains.CorgiEngine
{
    [AddComponentMenu("Corgi Engine/Spawn/Finish Level")]
    public class FinishLevel : ButtonActivated
    {
        [MMInspectorGroup("Finish Level", true, 22)]
        public string LevelName;
        public float DelayBeforeTransition = 0f;

        [MMInspectorGroup("MMFader Transition", true, 25)]
        public bool TriggerFade = false;
        [MMCondition("TriggerFade", true)]
        public int FaderID = 0;
        [MMCondition("TriggerFade", true)]
        public MMTweenType FadeTween = new MMTweenType(MMTween.MMTweenCurve.EaseInCubic);

        [MMInspectorGroup("Freeze", true, 27)]
        public bool FreezeTime = false;
        public bool FreezeCharacter = true;

        [MMInspectorGroup("Item Requirements", true, 28)]
        [Tooltip("A list of items and their required interactions")]
        public List<ItemRequirement> ItemRequirements = new List<ItemRequirement>(); // Lista de requisitos de ítems

        private Dictionary<string, int> _currentItemInteractions = new Dictionary<string, int>(); // Diccionario de interacciones actuales
        private WaitForSeconds _delayWaitForSeconds;
        private Character _character;

        [System.Serializable]
        public class ItemRequirement
        {
            public string ItemName;  // Nombre del ítem
            public int RequiredInteractions;  // Número de interacciones necesarias
        }

        public override void Initialization()
        {
            base.Initialization();
            _delayWaitForSeconds = new WaitForSeconds(DelayBeforeTransition);

            // Inicializar el diccionario con los ítems requeridos
            foreach (var requirement in ItemRequirements)
            {
                _currentItemInteractions[requirement.ItemName] = 0;
            }
        }

        // Método que aumenta el conteo de interacciones para el ítem especificado
        public void RegisterItemInteraction(string itemName)
        {
            if (_currentItemInteractions.ContainsKey(itemName))
            {
                _currentItemInteractions[itemName]++;
                Debug.Log($"Interactions with {itemName}: {_currentItemInteractions[itemName]}");
            }
        }

        public override void TriggerButtonAction(GameObject instigator)
        {
            if (instigator.GetComponent<Character>() != null)
            {
                _character = instigator.GetComponent<Character>();
            }

            // Verificar si se alcanzaron las interacciones necesarias para cada ítem
            foreach (var requirement in ItemRequirements)
            {
                if (_currentItemInteractions[requirement.ItemName] < requirement.RequiredInteractions)
                {
                    Debug.Log($"Not enough interactions with {requirement.ItemName}.");
                    return;  // No permitir la transición si falta alguna interacción
                }
            }

            if (!CheckNumberOfUses())
            {
                return;
            }

            base.TriggerButtonAction(instigator);
            StartCoroutine(GoToNextLevelCoroutine());
            ActivateZone();
        }

        protected virtual IEnumerator GoToNextLevelCoroutine()
        {
            if (TriggerFade && (DelayBeforeTransition > 0f))
            {
                MMFadeInEvent.Trigger(DelayBeforeTransition, FadeTween, FaderID, false, LevelManager.Instance.Players[0].transform.position);
            }

            if (FreezeTime)
            {
                MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, 0f, 0f, false, 0f, true);
            }

            if (FreezeCharacter && (_character != null))
            {
                _character.Freeze();
            }

            yield return _delayWaitForSeconds;
            GoToNextLevel();
        }

        public virtual void GoToNextLevel()
        {
            if (LevelManager.HasInstance)
            {
                LevelManager.Instance.GotoLevel(LevelName, (DelayBeforeTransition == 0f));
            }
            else
            {
                MMSceneLoadingManager.LoadScene(LevelName);
            }
        }
    }
}
