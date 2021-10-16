using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameJam.UI.Menu
{
    public class MainMenu : MonoBehaviour
    {
        public static MainMenu Instance;

        /// <summary>
        /// Get this credit from Amyra/Amirul
        /// </summary>
        [SerializeField] int credit = 1000;

        public enum UIMenu
        {
            None,
            Menu,
            Multiplayer,
            Practise,
            Garage
        }
        public UIMenu uiMenu;

        [Header("Text in Garage")]
        public TextMeshProUGUI menuText;
        public TextMeshProUGUI crText;
        public TextMeshProUGUI chosenCarText;

        // Start is called before the first frame update
        void Start()
        {
            if (Instance == null)
                Instance = this;
            else Destroy(this);

        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void minusCredit(int value)
        {
            if (Instance.credit >= value)
            {
                Instance.credit -= value;

                Instance.UpdateCredit();
            }
            else
            {
                // Play error
            }
        }

        void UpdateCredit()
        {
            crText.SetText($"Cr. {credit}");
        }

        /// <summary>
        /// UI state controlling animation. Something to open or close. Update Menu UI
        /// </summary>
        void UIState()
        {
            switch (uiMenu)
            {
                case UIMenu.None:

                    break;
                case UIMenu.Menu:
                    menuText.SetText("Menu");
                    break;
                case UIMenu.Multiplayer:
                    menuText.SetText("Multiplayer");
                    break;
                case UIMenu.Practise:
                    menuText.SetText("Practise");
                    break;
                case UIMenu.Garage:
                    menuText.SetText("Garage");
                    break;
            }
        }

        public void Next(int menuInt)
        {
            uiMenu = (UIMenu)menuInt;
            UIState();
        }

        public void Back()
        {

        }
    }
}