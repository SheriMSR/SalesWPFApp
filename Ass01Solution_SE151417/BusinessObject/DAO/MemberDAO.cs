using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        
        public IEnumerable<Member> GetMemberList()
        {
            List<Member> members;
            try
            {
                var fStoreDB = new FStoreDBContext();
                members = fStoreDB.Members.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberByID(int memberID)
        {
            Member member = null;
            try
            {
                var fStoreDB = new FStoreDBContext();
                member = fStoreDB.Members.SingleOrDefault(member => member.MemberId == memberID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }

        public void AddNew (Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if(_member == null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Members.Add(member);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Member member)
        {
            try
            {
                Member m = GetMemberByID(member.MemberId);
                if(m != null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Entry<Member>(member).State = EntityState.Modified;
                    fStoreDB.SaveChanges ();
                }
                else
                {
                    throw new Exception("Member does not exist.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Members.Remove(member);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("Member does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
