using BusinessObject.Entity;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        IMemberRepository _memberRepository;
        public WindowMembers(IMemberRepository repository)
        {
            InitializeComponent();
            _memberRepository = repository;
        }

        //private Member GetMemberObject()
        //{
        //    Member member = null;
        //    try
        //    {
        //        member = new Member
        //        {
        //            MemberId = int.Parse(txtMemberId.text)
        //        }
        //    }
        //}
    }
}
