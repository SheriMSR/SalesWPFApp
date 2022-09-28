using DataAccess.DAO;
using BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMember();
        Member GetMemberByID(int id);
        BaseResponseModel InsertMember(Member member);
        BaseResponseModel DeleteMember(Member member);
        BaseResponseModel UpdateMember(Member member);

    }
    public class MemberRepository : IMemberRepository
    {
        public BaseResponseModel DeleteMember(Member member) => MemberDAO.Instance.Remove(member);

        public IEnumerable<Member> GetMember() => MemberDAO.Instance.GetMemberList();

        public Member GetMemberByID(int id) => MemberDAO.Instance.GetMemberByID(id);

        public BaseResponseModel InsertMember(Member member) =>  MemberDAO.Instance.AddNew(member);

        public BaseResponseModel UpdateMember(Member member) => MemberDAO.Instance.Update(member);
    }
}
