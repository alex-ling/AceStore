using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft.ViewModels
{
    public interface ITabViewModel
    {
        int Index { get; }
        bool IsSelected { get; set; }
        string CurrentIcon { get; }
        string Icon { get; }
        string SelectedIcon { get; }
    }
}
