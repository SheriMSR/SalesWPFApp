using BusinessObject.Entity;
using DataAccess.Model;
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
        string msg = null;
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
            catch (Exception ex)
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

        public BaseResponseModel AddNew(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                //id có tồn tại nhưng email khác => id đã được sử dụng 
                if (_member != null && member.Email != _member.Email)
                {
                    msg = "This ID has been used!";
                }
                else if (member.Email == _member.Email)
                {
                    msg = "Member already exsist!";
                }
                else
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Members.Add(member);
                    fStoreDB.SaveChanges();
                    msg = "Member has been added successfully!";
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new BaseResponseModel
            {
                Message = msg,
            };
        }

        public BaseResponseModel Update(Member member)
        {
            try
            {
                Member m = GetMemberByID(member.MemberId);
                if (m != null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Entry<Member>(member).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                    msg = "Member's information has been updated.";
                }
                else
                {
                    msg = "Member does not exist.";
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new BaseResponseModel
            {
                Message = msg
            };
        }

        public BaseResponseModel Remove(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var fStoreDB = new FStoreDBContext();
                    fStoreDB.Members.Remove(member);
                    fStoreDB.SaveChanges();
                    msg = "Member has been removed successfully!";
                }
                else
                {
                    msg = "Member does not exist.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return new BaseResponseModel { Message = msg };
        }
    }
}
