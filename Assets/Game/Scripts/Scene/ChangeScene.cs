using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scene
{
    Menu, Game
}

[RequireComponent(typeof(Button))]
public class ChangeScene : MonoBehaviour
{
    private readonly Dictionary<Scene, string> _scenes = new Dictionary<Scene, string>()
    {
        { Scene.Menu, "Menu" },
        { Scene.Game, "Game" }
    };

    [SerializeField] private Scene _openScene;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => OpenScene(_openScene));
    }

    private void OpenScene(Scene scene)
    {
        SceneManager.LoadScene(_scenes[scene]);
    }
}