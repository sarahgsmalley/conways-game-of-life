namespace GameOfLife
{
    public interface INotifyCancelling
    {
        bool ShouldStop();
        bool ShouldSaveWorldState();
        bool ShouldSave();
        void CheckUserOption();
    }
}