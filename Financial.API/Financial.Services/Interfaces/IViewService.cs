using Financial.Data.Models;

namespace Financial.Services.Interfaces
{
    public interface IViewService
    {
        Task CreateViewAsync(View view);
        Task<View?> GetViewAsync(int viewId, int userId);

        Task<List<View>> GetViewsAsync(int userId);

        Task DeleteViewAsync(int viewId);
    }
}
