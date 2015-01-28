using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TalBrody.DataLayer;
using TalBrody.Entity;

namespace TalBrody.Logic
{

	
    public class OxifyParams
	{
        public const string PARAM_DB_VERSION = "DBVersion";


        public static int GetDbVersion()
        {
            OxifyParamDal dal = new OxifyParamDal();
            List<Param> list = dal.GetParams();

            return list.Find(x => x.Name == PARAM_DB_VERSION).ValueInt ?? 0;

        }

	    public static void InsertParam(string Name, string Value, int? ValueInt)
	    {
	        OxifyParamDal dal = new OxifyParamDal();
	        Param param = new Param();
	        param.Name = Name;
	        param.Value = Value;
	        param.ValueInt = ValueInt;
            dal.InsertParam(param);
	    }
        public static void UpdateParam(string Name, string Value, int? ValueInt)
	    {
	        OxifyParamDal dal = new OxifyParamDal();
	        Param param = new Param();
	        param.Name = Name;
	        param.Value = Value;
	        param.ValueInt = ValueInt;
            dal.UpdateParam(param);
	    }

	}
}