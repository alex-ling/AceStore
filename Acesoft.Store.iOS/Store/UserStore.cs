using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Acesoft.Store.iOS.Store
{
    public class UserStore : IStore
    {
        public string GetString(string key)
        {
            return NSUserDefaults.StandardUserDefaults.StringForKey(key);
        }

        public void SetString(string key, string value)
        {
            NSUserDefaults.StandardUserDefaults.SetString(value, key);
        }

        public void Delete(string key)
        {
            NSUserDefaults.StandardUserDefaults.RemoveObject(key);
        }
    }
}