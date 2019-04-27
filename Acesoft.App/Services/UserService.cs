using System;
using System.Collections.Generic;

using Acesoft.Components;
using Acesoft.Models;
using Acesoft.Services;
using Acesoft.Util;

namespace Acesoft.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private const string KEY_UserToken = "user_token";
        private const string KEY_UserLogin = "user_login";

        public UserService(string baseUrl) : base(baseUrl)
        { }

        #region login
        public bool Login(string userName, string password)
        {
            try
            {
                var token = GetToken(userName, password);
                if (token != null)
                {
                    AppCtx.Store.SetString(KEY_UserLogin, $"{userName},{password}");
                    AppCtx.Store.Set(KEY_UserToken, token);

                    AppCtx.SetLogind(token, GetUser());
                    Toast.ShowShortMsg("登录成功");

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Toast.ShowShortMsg(ex.GetMessage());
                return false;
            }
        }

        public bool AutoLogin()
        {
            try
            {
                if (AppCtx.Logined) return true;

                var token = AppCtx.Store.Get<Token>(KEY_UserToken);
                if (token != null)
                {
                    if (token.Created.AddSeconds(token.Expires_In / 2.0) < DateTime.Now)
                    {
                        token = RefreshToken(token.Refresh_Token);
                        if (token == null)
                        {
                            // refresh token fail
                            var userInfos = AppCtx.Store.GetString(KEY_UserLogin).Split(',');
                            token = GetToken(userInfos[0], userInfos[1]);
                        }

                        AppCtx.Store.Set(KEY_UserToken, token);
                    }

                    AppCtx.SetLogind(token, GetUser());
                    Toast.ShowShortMsg("登录成功");

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Toast.ShowShortMsg(ex.GetMessage());

                return false;
            }
        }
        #endregion

        #region user
        public User GetUser()
        {
            return Client.Get<User>($"api/auth/GetUser", GetAuthHeaders());
        }
        #endregion

        #region token
        private Token GetToken(string userName, string password)
        {
            return Client.GetJson<Token>($"api/app/GetToken?username={userName}&password={password}");
        }

        private Token RefreshToken(string refreshToken)
        {
            return Client.GetJson<Token>($"api/app/RefreshToken?refreshtoken={refreshToken}");
        }
        #endregion

        #region auth
        private Dictionary<string, string> GetAuthHeaders()
        {
            return new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {AppCtx.Token.Access_Token}" }
            };
        }
        #endregion
    }
}
