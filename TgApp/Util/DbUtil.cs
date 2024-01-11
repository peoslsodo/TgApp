using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using TgApp.Model;

namespace TgApp.Util
{
    public class DbUtil
    {
        private readonly string _connStr;
        public DbUtil()
        {

        }

        private SqlSugarClient GetInstance()
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                
            });
        }

        public List<Language> GetLangList()
        {
            return new List<Language>();
        }

        public List<T> GetList<T>()
        {
            throw new NotImplementedException();
        }

      
        

        public int AddModel<T>(T model, bool ignoreId = true) where T : class, new()
        {
            return 1;
        }

        public int DelById<T>(int id) where T : class, new()
        {
            return 1;
        }
      

        public int DelAll<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }


        public bool IsExistCofig(string phone)
        {
            return false;
        }

     

        public bool IsExistMemberGroup(long groupId)
        {
            return false;
        }
        public bool IsExistMember(long groupId, long userId)
        {
            return false;
        }

        public List<MemberView> GetMemberList(long groupId = default, string firstName = default, string status = default)
        {
              return new List<MemberView>();
        }


        public List<Members> GetList(long groupId, long chatId, string status)
        {
            return new List<Members>();
        }




        /// <summary>
        /// SqlSugar  not support 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
       

        public int UpdateConfig(Config model)
        {
            return 0;
        }

        public int UpdateMsg(MsgModel model)
        {
            return 0;
        }

    }
}
