using Global.Dialogs.Base;
using Global.Sound;
using Global.UI.Base;

namespace Global.Scene
{
    public interface IGlobalSceneView
    {
        IGlobalUIView GlobalUIView { get; }
        IDialogsView DialogsView { get; }
        ISoundManager SoundManager { get; }
        
        void DisableCamera();
        void EnableCamera();
        void EnableEventSystem();
        void DisableEventSystem();
    }
}