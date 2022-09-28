using BusinessObject.Entity;
using DataAccess;
using SalesWPFApp.Configuration;
using SalesWPFApp.Event;
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
        public WindowMembers(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            InitializeComponent();
            GenerateComponent();
        }
        private void GenerateComponent()
        {
            var isAdmin = AppManager.getCurrentRole();
            if (!isAdmin)
            {
                btnDelete.IsEnabled = false;
            }
        }
        public Member GetObject()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtpassword.Text
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public void LoadMemberList()
        {
            lvMember.ItemsSource = _memberRepository.GetMember();
        }
        private void btnLoadMember_click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadMemberList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnAddMember_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetObject();
                var result = _memberRepository.InsertMember(member);
                LoadMemberList();
                MessageBox.Show(result.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnUpdateMember_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetObject();
                var result = _memberRepository.UpdateMember(member);
                LoadMemberList();
                MessageBox.Show(result.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnDeleteMember_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = GetObject();
                var result = _memberRepository.DeleteMember(member);
                LoadMemberList();
                MessageBox.Show(result.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnAddMemberDetail_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearText_click(object sender, RoutedEventArgs e)
        {
            txtMemberID.Clear();
            txtEmail.Clear();
            txtCompanyName.Clear();
            txtCountry.Clear();
            txtCity.Clear();
            txtpassword.Clear();
        }

        private void btnCloseWindow_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
