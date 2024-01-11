using System.Collections.Generic;
using System.Threading.Tasks;
using TgLib.Model;

namespace TgLib
{
    public interface ITgClient
    {
        bool AuthNeeded { get; set; }
        int ApiId { get; set; }
        Task<bool> AuthAsync(string code);
        Task<bool> SendCode();
        Task<bool> DeleteContactAsync(long[] userIds);
        Task<List<User>> GetContactsAsync();
        Task<List<Groups>> GetGroupAsync(int limit = 1000);
        Task<List<User>> GetGroupUsersAsync(long groupId, bool isSuper);
        Task<List<User>> ImportContactsAsync(List<Contact> list);
        void Init();
        Task<Result> InviteGroupAsync(long chatId, long userId, bool isSuper);
        Task InviteToSuperGroupAsync(long groupId, List<long> userList);
        Task SendMessageAsync(long chatId, string message);
        Task SendPhotoAsync(long chatId, string path);

        Task<Groups> CreateGroupAsync(string title, string description);

        Task<bool> DeleteSuperGroupAsync(long groupId);

        Task<string> GetChatHistoryAsync(long chatId = default, int limit = 200);

        Task<List<string>> SearchChatsAsync(string query = default);

        Task<bool> JoinChatByInviteLinkAsync(string link);

        Task<List<AvailableContacts>> GetAvailableContactsAsync(int limit = 1000);

        Task<List<SearchUser>> SearchPublicUserAsync(string name = default);
        Task<List<Groups>> SearchPublicGroupAsync(string name = default);

        Task<string> JoinChatAsync(long chatId = default);
        Task<List<NearByUser>> NearbyUsersAsync();

        Task<List<NearByGroup>> NearbyGroupAsync();
    }
}