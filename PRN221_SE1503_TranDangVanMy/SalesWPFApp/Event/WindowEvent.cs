using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp.Event
{ 
    public delegate void LoadMemberWindow();
    public delegate void LoadOrderWindow();
    public delegate void LoadProductWindow();
    public delegate void LoadMainWindow();
    public delegate void LoadLoginWindow();
    public static class WindowEvent
    {
        public static event LoadMemberWindow? LoadMemberWindow;
        public static event LoadOrderWindow? LoadOrderWindow;
        public static event LoadProductWindow? LoadProductWindow;
        public static event LoadMainWindow? LoadMainWindow;
        public static event LoadLoginWindow? LoadLoginWindow;


        public static void OnLoadMemberWindow() => LoadMemberWindow?.Invoke();
        public static void OnLoadOrderWindow() => LoadOrderWindow?.Invoke();
        public static void OnLoadProductWindow() => LoadProductWindow?.Invoke();
        public static void OnLoadMainWindow() => LoadMainWindow?.Invoke();
        public static void OnLoadLoginWindow() => LoadLoginWindow?.Invoke();
    }
}
