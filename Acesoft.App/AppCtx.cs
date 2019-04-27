using Acesoft.Models;
using Acesoft.Services;

namespace Acesoft
{
    public class AppCtx
    {
        public const string ApiUrl = "http://store.miniplat.com/";

        public static Token Token { get; private set; }
        public static bool Logined { get; private set; }
        public static IUser User { get; private set; }
        public static IStore Store { get; private set; }
        public static IUserService UserService { get; } = new UserService(ApiUrl);
        
        public static void InitStore(IStore store)
        {
            Store = store;
        }

        public static void SetLogind(Token token, IUser user)
        {
            Logined = true;
            Token = token;
            User = user;
        }
    }
}
