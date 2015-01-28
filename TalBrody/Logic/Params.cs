using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{


    public class Params
    {
        public const string PARAM_DB_VERSION = "DBVersion";


        public static bool CheckParamExists()
        {
            ParamDal dal = new ParamDal();
            return dal.CheckParamExists();

        }
        public static Param GetParam(string Name)
        {
            ParamDal dal = new ParamDal();
            return dal.GetParam(Name);
        }

        public static void InsertParam(string Name, string Value, int? ValueInt)
        {
            ParamDal dal = new ParamDal();
            Param param = new Param();
            param.Name = Name;
            param.Value = Value;
            param.ValueInt = ValueInt;
            dal.InsertParam(param);
        }
        public static void UpdateParam(string Name, string Value, int? ValueInt)
        {
            ParamDal dal = new ParamDal();
            Param param = new Param();
            param.Name = Name;
            param.Value = Value;
            param.ValueInt = ValueInt;
            dal.UpdateParam(param);
        }


    }
}