using System.Threading.Tasks;

namespace MSPRoadDemo.VkApi
{
    public interface IVkApi
    {
        Task<RepostsResponse> GetReposts(int ownerId, int postId);
    }
}