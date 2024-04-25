using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// This class describes how the Corgi Engine demo achievements are triggered.
	/// It extends the base class MMAchievementRules
	/// It listens for different event types
	/// </summary>
	public class AchievementRules : MMAchievementRules,
		MMEventListener<MMGameEvent>,
		MMEventListener<MMCharacterEvent>,
		MMEventListener<CorgiEngineEvent>,
		MMEventListener<MMStateChangeEvent<CharacterStates.MovementStates>>,
		MMEventListener<MMStateChangeEvent<CharacterStates.CharacterConditions>>,
		MMEventListener<PickableItemEvent>
		
	{
		/// <summary>
		/// When we catch an MMGameEvent, we do stuff based on its name
		/// </summary>
		/// <param name="gameEvent">Game event.</param>
		public override void OnMMEvent(MMGameEvent gameEvent)
		{

			base.OnMMEvent (gameEvent);

		}

		public virtual void OnMMEvent(MMCharacterEvent characterEvent)
		{
			if (characterEvent.TargetCharacter.CharacterType == Character.CharacterTypes.Player)
			{
				switch (characterEvent.EventType)
				{
					case MMCharacterEventTypes.Jump:
						MMAchievementManager.AddProgress ("JumpAround", 1);
                        MMAchievementManager.AddProgress("ProJump", 1);

                        break;
					case MMCharacterEventTypes.Crouch:
						MMAchievementManager.UnlockAchievement("LookDown");
						break;

				}	
			}
		}

		public virtual void OnMMEvent(CorgiEngineEvent corgiEngineEvent)
		{
			switch (corgiEngineEvent.EventType)
			{
                case CorgiEngineEventTypes.LevelEnd:
                    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "NombreDeLaEscena")
                    {
                        // Desbloquea el logro cuando se completa la escena específica
                        MMAchievementManager.UnlockAchievement("LogroDeNivelEspecifico");
                    }
                    MMAchievementManager.UnlockAchievement ("PrincessInAnotherCastle");
					break;
				case CorgiEngineEventTypes.PlayerDeath:
					MMAchievementManager.UnlockAchievement ("DeathIsOnlyTheBeginning");
					MMAchievementManager.AddProgress("TenDeaths", 1);
					break;
                case CorgiEngineEventTypes.Respawn:
					MMAchievementManager.UnlockAchievement ("Respawn");
					break;
               

            }
		}

		public virtual void OnMMEvent(PickableItemEvent pickableItemEvent)
		{
			if (pickableItemEvent.PickedItem != null)
			{
				if (pickableItemEvent.PickedItem.GetComponent<Coin>() != null)
				{
					MMAchievementManager.AddProgress ("MoneyMoneyMoney", 1);
                    MMAchievementManager.AddProgress("Money", 1);
                    MMAchievementManager.AddProgress("MoneyMoney", 1);
                }

				if (pickableItemEvent.PickedItem.GetComponent<Stimpack>() != null)
				{
					MMAchievementManager.UnlockAchievement ("Medic");
				}
              
            }
		}

		public virtual void OnMMEvent(MMStateChangeEvent<CharacterStates.MovementStates> movementEvent)
		{
			switch (movementEvent.NewState)
			{
				
			}

		}

	

		/// <summary>
		/// On enable, we start listening for MMGameEvents. You may want to extend that to listen to other types of events.
		/// </summary>
		protected override void OnEnable()
		{
			base.OnEnable ();
            this.MMEventStartListening<MMCharacterEvent>();
			this.MMEventStartListening<CorgiEngineEvent>();
			this.MMEventStartListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
			this.MMEventStartListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
			this.MMEventStartListening<PickableItemEvent>();

		}

		/// <summary>
		/// On disable, we stop listening for MMGameEvents. You may want to extend that to stop listening to other types of events.
		/// </summary>
		protected override void OnDisable()
		{
			base.OnDisable ();
			this.MMEventStopListening<MMCharacterEvent>();
			this.MMEventStopListening<CorgiEngineEvent>();
			this.MMEventStopListening<MMStateChangeEvent<CharacterStates.MovementStates>>();
			this.MMEventStopListening<MMStateChangeEvent<CharacterStates.CharacterConditions>>();
			this.MMEventStopListening<PickableItemEvent>();
		}

        public void OnMMEvent(MMStateChangeEvent<CharacterStates.CharacterConditions> eventType)
        {
            throw new System.NotImplementedException();
        }
    }
}