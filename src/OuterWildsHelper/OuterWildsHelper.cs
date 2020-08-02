using OWML.ModHelper;
using UnityEngine;

namespace OuterWildsHelper
{
    public class OuterWildsHelper : ModBehaviour
    {
        private string _timeRemainingText;
        private GUIStyle _timeRemainingStyle;

        private void Start()
        {
            ModHelper.Console.WriteLine("Helper: Started");

            ModHelper.Menus.PauseMenu.OnOpen += PauseMenuOpen;
            ModHelper.Menus.PauseMenu.OnClose += PauseMenuClose;
        }

        private void PauseMenuOpen()
        {
            var part1 = Mathf.Floor(TimeLoop.GetSecondsRemaining() / 60f);
            var part2 = Mathf.Round(TimeLoop.GetSecondsRemaining() % 60f);

            _timeRemainingText = $"Time Remaining: {part1}:{part2}";
        }

        private void PauseMenuClose()
        {
            _timeRemainingText = null;
        }

        private void OnGUI()
        {
            if (_timeRemainingStyle == null)
            {
                _timeRemainingStyle = new GUIStyle(GUI.skin.GetStyle("Label"))
                {
                    alignment = TextAnchor.MiddleCenter,
                    fontSize = 30
                };
            }

            if (ModHelper.Menus.PauseMenu.IsOpen && _timeRemainingText != null)
            {
                GUI.Label(new Rect((Screen.width / 2) - 150, Screen.height - 200, 300, 100), _timeRemainingText, _timeRemainingStyle);
            }
        }
    }
}
