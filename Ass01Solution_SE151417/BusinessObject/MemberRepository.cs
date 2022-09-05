using BusinessObject.DAO;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMember();
        Member GetMemberByID(int id);
        void InsertMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);

    }
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member member) => MemberDAO.Instance.Remove(member);

        public IEnumerable<Member> GetMember() => MemberDAO.Instance.GetMemberList();

        public Member GetMemberByID(int id) => MemberDAO.Instance.GetMemberByID(id);

        public void InsertMember(Member member) => MemberDAO.Instance.AddNew(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.Update(member);
    }
}
