using Game.Input.Android;
using Game.Input.Base;
using Game.Input.Windows;
using Global;
using UnityEngine;

namespace Game.Factories.Input
{
    public class InputPresenterFactory
    {
        public BaseInputPresenter Create(in GlobalEnvironment environment, RuntimePlatform platformType)
        {
            BaseInputPresenter presenter = null;
            IInputModel model = null;
            var gameView = environment.GameSceneView.GameView;
            switch (platformType)
            {
                case RuntimePlatform.Android:
                    model = new AndroidInputModel();
                    presenter = new AndroidInputPresenter(environment, model, gameView.CreateInputView<AndroidInputView>());
                    break;
                case RuntimePlatform.WindowsPlayer:
                    model = new WindowsInputModel();
                    presenter = new WindowsInputPresenter(environment, model, gameView.CreateInputView<WindowsInputView>());
                    break;
                case RuntimePlatform.WindowsEditor:
                    model = new WindowsInputModel();
                    presenter = new WindowsInputPresenter(environment, model, gameView.CreateInputView<WindowsInputView>());
                    break;
            }
            
            environment.InputModel = model;
            
            return presenter;
        }
    }
}