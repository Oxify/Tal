using System.Data.SqlTypes;
using TalBrody.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalBrody.Entity;
using log4net;

namespace TalBrody.DataLayer
{
    public class ParamDal : BaseDal
    {
        public bool CheckParamExists()
        {
            bool exists = false;
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE  TABLE_NAME = 'Params'", myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myConnection.Open();
                    var dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        exists = true;
                    }
                    myConnection.Close();
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error("CheckParamExists Threw: " + ex.ToString());
                throw ex;
            }
            return exists;
        }

        public Param GetParam(string Name)
        {
            Param Result = null;
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("select * from Params where Name = @Name", myConnection);
                    myCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                    myCommand.CommandType = CommandType.Text;
                    myConnection.Open();
                    var dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        Result = Populators.Populate_Params(dr);
                    }
                    myConnection.Close();
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetParam Threw: " + ex.ToString());
            }

            return Result;
        }



        public List<Param> GetParams()
        {
            List<Param> Result = new List<Param>();
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("select * from Params", myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myConnection.Open();
                    var dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {

                        Result.Add(Populators.Populate_Params(dr));
                    }
                    myConnection.Close();
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetParams Threw: " + ex.ToString());
            }
            return Result;
        }

        public void UpdateParam(Param param)
        {
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("update [Params] set [Name] = @Name, [Value] = @Value, [ValueInt] = @ValueInt ", myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = param.Name;
                    myCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = param.Name;
                    myCommand.Parameters.Add("@ValueInt", SqlDbType.Int).Value = param.ValueInt ?? SqlInt32.Null;

                    myConnection.Open();
                    var result = myCommand.ExecuteNonQuery();
                    if (result != 1)
                    {
                        throw new Exception("Expected result 1, got " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("UpdateParam Threw: " + ex);
                throw ex;
            }
        }

        public void InsertParam(Param param)
        {
            try
            {
                using (var myConnection = PortalConection)
                {
                    var myCommand = GetCommand("insert into [Params] ([Name], [Value], [ValueInt]) values (@Name, @Value, @ValueInt", myConnection);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = param.Name;
                    myCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = param.Name;
                    myCommand.Parameters.Add("@ValueInt", SqlDbType.Int).Value = param.ValueInt ?? SqlInt32.Null;

                    myConnection.Open();
                    var result = myCommand.ExecuteNonQuery();
                    if (result != 1)
                    {
                        throw new Exception("Expected result 1, got " + result);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("InsertParam Threw: " + ex);
                throw ex;
            }
        }




    }
}