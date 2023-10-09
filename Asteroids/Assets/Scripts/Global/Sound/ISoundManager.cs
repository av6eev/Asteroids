namespace Global.Sound
{
    public interface ISoundManager
    {
        ISoundManager Instance { get; }
        
        void Reset();
        void Play(SoundsTypes type);
    }
}