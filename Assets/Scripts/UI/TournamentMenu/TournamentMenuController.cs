using System;
using OpenSkiJumping.Data;
using UnityEngine;
using EventType = OpenSkiJumping.Competition.EventType;

namespace OpenSkiJumping.UI.TournamentMenu
{
    public class TournamentMenuController : MonoBehaviour, ITournamentMenuController
    {
        [SerializeField] private GameObject classificationsHierarchyGO;
        [SerializeField] private GameObject jumpersListGO;
        [SerializeField] private MainMenuController menuController;
        [SerializeField] private SavesRuntime saves;
        [SerializeField] private GameObject teamsListGO;
        [SerializeField] private GameObject teamSquadGO;
        [SerializeField] private TournamentMenuData tournamentMenuData;

        public event Action OnReloadTeamsList;

        public void ShowTeamSquad()
        {
            teamSquadGO.SetActive(true);
        }

        public void HideTeamSquad()
        {
            teamSquadGO.SetActive(false);
            OnReloadTeamsList?.Invoke();
        }

        private void Start()
        {
            if (tournamentMenuData.GetCurrentEvent() == null)
            {
                classificationsHierarchyGO.SetActive(false);
                jumpersListGO.SetActive(false);
                teamsListGO.SetActive(false);
                return;
            }

            classificationsHierarchyGO.SetActive(true);
            jumpersListGO.SetActive(tournamentMenuData.GetCurrentEvent().eventType == EventType.Individual);
            teamsListGO.SetActive(tournamentMenuData.GetCurrentEvent().eventType == EventType.Team);
        }

        public void LoadCompetition()
        {
            menuController.LoadTournament();
        }

        public void LoadMainMenu()
        {
            menuController.LoadMainMenu();
        }
    }
}