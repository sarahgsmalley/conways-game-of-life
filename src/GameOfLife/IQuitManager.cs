namespace GameOfLife
{
    public interface IQuitManager
    {
        bool ShouldStop();
        bool ShouldSave();
        void CheckUserOption();
    }
}