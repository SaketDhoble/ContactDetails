using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetails.DAL.Interfaces;
using ContactDetails.Models;
using ContactDetails.StaticStuff;
using System.Data;
using System.Data.SqlClient;

namespace ContactDetails.DAL
{
    public class TblContactDetailsDAL : ITblContactDetailsDAL
    {
        public TblContactDetailsDAL()
        {
        }
        #region Methods
        public String SqlSelectQuery()
        {
            String sqlSelectQry = " SELECT * FROM [TblContactDetails] tblContactDetails";
            return sqlSelectQry;
        }
        #endregion

        #region Selection
        public List<TblContactDetailsTO> SelectTblContactDetails()
        {
            String sqlConnStr = Startup.ConnectionString;
            SqlConnection conn = new SqlConnection(sqlConnStr);
            SqlCommand cmdSelect = new SqlCommand();
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                cmdSelect.CommandText = SqlSelectQuery();
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = System.Data.CommandType.Text;

                rdr = cmdSelect.ExecuteReader(CommandBehavior.Default);
                List<TblContactDetailsTO> list = ConvertDTToList(rdr);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (rdr != null) rdr.Dispose();
                conn.Close();
                cmdSelect.Dispose();
            }
        }

        public List<TblContactDetailsTO> SelectTblContactDetailsByDetails(TblContactDetailsTO tblContactDetailsTO)
        {
            String sqlConnStr = Startup.ConnectionString;
            SqlConnection conn = new SqlConnection(sqlConnStr);
            SqlCommand cmdSelect = new SqlCommand();
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                cmdSelect.CommandText = SqlSelectQuery() + " WHERE firstName = '" + tblContactDetailsTO.FirstName + "' AND lastName = '" + tblContactDetailsTO.LastName +
                    "' AND phoneNo = '" + tblContactDetailsTO.PhoneNo + "' AND isActive = 1 ";

                if (tblContactDetailsTO.IdContactDetails > 0)
                {
                    cmdSelect.CommandText += " AND idContactDetails != " + tblContactDetailsTO.IdContactDetails;
                }

                cmdSelect.Connection = conn;
                cmdSelect.CommandType = System.Data.CommandType.Text;

                rdr = cmdSelect.ExecuteReader(CommandBehavior.Default);
                List<TblContactDetailsTO> list = ConvertDTToList(rdr);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (rdr != null) rdr.Dispose();
                conn.Close();
                cmdSelect.Dispose();
            }
        }
        public TblContactDetailsTO SelectTblContactDetailsTO(Int32 idContactDetails)
        {
            String sqlConnStr = Startup.ConnectionString;
            SqlConnection conn = new SqlConnection(sqlConnStr);
            SqlCommand cmdSelect = new SqlCommand();
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                cmdSelect.CommandText = SqlSelectQuery() + " WHERE tblContactDetails.idContactDetails = " + idContactDetails + " ";
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = System.Data.CommandType.Text;

                rdr = cmdSelect.ExecuteReader(CommandBehavior.Default);
                List<TblContactDetailsTO> list = ConvertDTToList(rdr);
                if (list != null && list.Count == 1)
                {
                    return list[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (rdr != null) rdr.Dispose();
                conn.Close();
                cmdSelect.Dispose();
            }
        }
        public List<TblContactDetailsTO> ConvertDTToList(SqlDataReader dimOrgTypeTODT)
        {
            List<TblContactDetailsTO> tblContactDetailsTOList = new List<TblContactDetailsTO>();
            if (dimOrgTypeTODT != null)
            {
                while (dimOrgTypeTODT.Read())
                {
                    TblContactDetailsTO tblContactDetailsTONew = new TblContactDetailsTO();
                    if (dimOrgTypeTODT["idContactDetails"] != DBNull.Value)
                        tblContactDetailsTONew.IdContactDetails = Convert.ToInt32(dimOrgTypeTODT["IdContactDetails"].ToString());
                    if (dimOrgTypeTODT["firstName"] != DBNull.Value)
                        tblContactDetailsTONew.FirstName = Convert.ToString(dimOrgTypeTODT["firstName"].ToString());
                    if (dimOrgTypeTODT["lastName"] != DBNull.Value)
                        tblContactDetailsTONew.LastName = Convert.ToString(dimOrgTypeTODT["lastName"].ToString());
                    if (dimOrgTypeTODT["phoneNo"] != DBNull.Value)
                        tblContactDetailsTONew.PhoneNo = Convert.ToString(dimOrgTypeTODT["phoneNo"].ToString());
                    if (dimOrgTypeTODT["email"] != DBNull.Value)
                        tblContactDetailsTONew.Email = Convert.ToString(dimOrgTypeTODT["email"].ToString());
                    if (dimOrgTypeTODT["isActive"] != DBNull.Value)
                        tblContactDetailsTONew.IsActive = Convert.ToInt32(dimOrgTypeTODT["isActive"].ToString());
                    if (dimOrgTypeTODT["createdBy"] != DBNull.Value)
                        tblContactDetailsTONew.CreatedBy = Convert.ToInt32(dimOrgTypeTODT["createdBy"].ToString());
                    if (dimOrgTypeTODT["createdOn"] != DBNull.Value)
                        tblContactDetailsTONew.CreatedOn = Convert.ToDateTime(dimOrgTypeTODT["createdOn"].ToString());
                    tblContactDetailsTONew.CreatedByName = "Admin";

                    if (dimOrgTypeTODT["updatedBy"] != DBNull.Value)
                        tblContactDetailsTONew.UpdatedBy = Convert.ToInt32(dimOrgTypeTODT["updatedBy"].ToString());
                    if (dimOrgTypeTODT["updatedOn"] != DBNull.Value)
                        tblContactDetailsTONew.UpdatedOn = Convert.ToDateTime(dimOrgTypeTODT["updatedOn"].ToString());
                    if (tblContactDetailsTONew.UpdatedOn != new DateTime())
                        tblContactDetailsTONew.CreatedByName = "Admin";

                    tblContactDetailsTOList.Add(tblContactDetailsTONew);
                }
            }
            return tblContactDetailsTOList;
        }
        #endregion

        #region Insertion
        public int InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO)
        {
            String sqlConnStr = Startup.ConnectionString;
            SqlConnection conn = new SqlConnection(sqlConnStr);
            SqlCommand cmdInsert = new SqlCommand();
            try
            {
                conn.Open();
                cmdInsert.Connection = conn;
                return ExecuteInsertionCommand(tblContactDetailsTO, cmdInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmdInsert.Dispose();
            }
        }

        public int InsertTblContactDetails(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand cmdInsert = new SqlCommand();
            try
            {
                cmdInsert.Connection = conn;
                cmdInsert.Transaction = tran;
                return ExecuteInsertionCommand(tblContactDetailsTO, cmdInsert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdInsert.Dispose();
            }
        }

        public int ExecuteInsertionCommand(TblContactDetailsTO tblContactDetailsTO, SqlCommand cmdInsert)
        {
            String sqlQuery = @" INSERT INTO [tblContactDetails]( " +
                                "  [firstName]" +
                                " ,[lastName]" +
                                " ,[phoneNo]" +
                                " ,[email]" +
                                " ,[isActive]" +
                                " ,[createdBy]" +
                                " ,[createdOn]" +
                                " ,[updatedBy]" +
                                " ,[updatedOn]" +
                                " )" +
                    " VALUES (" +
                                "  @FirstName " +
                                " ,@LastName " +
                                " ,@PhoneNo " +
                                " ,@Email " +
                                " ,@IsActive " +
                                " ,@CreatedBy " +
                                " ,@CreatedOn" +
                                " ,@UpdatedBy" +
                                " ,@UpdatedOn" +
                                " )";

            cmdInsert.CommandText = sqlQuery;
            cmdInsert.CommandType = System.Data.CommandType.Text;

            cmdInsert.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.FirstName;
            cmdInsert.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.LastName;
            cmdInsert.Parameters.Add("@PhoneNo", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.PhoneNo;
            cmdInsert.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.Email;
            cmdInsert.Parameters.Add("@IsActive", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.IsActive;
            cmdInsert.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.CreatedBy;
            cmdInsert.Parameters.Add("@CreatedOn", System.Data.SqlDbType.DateTime).Value = tblContactDetailsTO.CreatedOn;
            cmdInsert.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.UpdatedBy;
            cmdInsert.Parameters.Add("@UpdatedOn", System.Data.SqlDbType.DateTime).Value = tblContactDetailsTO.UpdatedOn;


            return cmdInsert.ExecuteNonQuery();
        }
        #endregion

        #region Updation
        public int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO)
        {
            String sqlConnStr = Startup.ConnectionString;
            SqlConnection conn = new SqlConnection(sqlConnStr);
            SqlCommand cmdUpdate = new SqlCommand();
            try
            {
                conn.Open();
                cmdUpdate.Connection = conn;
                return ExecuteUpdationCommand(tblContactDetailsTO, cmdUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmdUpdate.Dispose();
            }
        }

        public int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand cmdUpdate = new SqlCommand();
            try
            {
                cmdUpdate.Connection = conn;
                cmdUpdate.Transaction = tran;
                return ExecuteUpdationCommand(tblContactDetailsTO, cmdUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdUpdate.Dispose();
            }
        }

        public int ExecuteUpdationCommand(TblContactDetailsTO tblContactDetailsTO, SqlCommand cmdUpdate)
        {
            String sqlQuery = @" UPDATE [tblContactDetails] SET " +
            "  [firstName] = @FirstName" +
            " ,[lastName]= @LastName" +
            " ,[phoneNo]= @PhoneNo" +
            " ,[email]= @Email" +
            " ,[isActive]= @IsActive" +
            " ,[updatedBy] = @UpdatedBy" +
            " ,[updatedOn] =@UpdatedOn " +
            " WHERE idContactDetails = @IdContactDetails ";

            cmdUpdate.CommandText = sqlQuery;
            cmdUpdate.CommandType = System.Data.CommandType.Text;

            cmdUpdate.Parameters.Add("@IdContactDetails", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.IdContactDetails;
            cmdUpdate.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.FirstName;
            cmdUpdate.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.LastName;
            cmdUpdate.Parameters.Add("@PhoneNo", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.PhoneNo;
            cmdUpdate.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = tblContactDetailsTO.Email;
            cmdUpdate.Parameters.Add("@IsActive", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.IsActive;
            cmdUpdate.Parameters.Add("@CreatedBy", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.CreatedBy;
            cmdUpdate.Parameters.Add("@CreatedOn", System.Data.SqlDbType.DateTime).Value = tblContactDetailsTO.CreatedOn;
            cmdUpdate.Parameters.Add("@UpdatedBy", System.Data.SqlDbType.Int).Value = tblContactDetailsTO.UpdatedBy;
            cmdUpdate.Parameters.Add("@UpdatedOn", System.Data.SqlDbType.DateTime).Value = tblContactDetailsTO.UpdatedOn;


            return cmdUpdate.ExecuteNonQuery();
        }
        #endregion

        #region Deletion
        public int DeleteTblContactDetailsTO(Int32 idContactDetails)
        {
            String sqlConnStr = Startup.ConnectionString;
            SqlConnection conn = new SqlConnection(sqlConnStr);
            SqlCommand cmdDelete = new SqlCommand();
            try
            {
                conn.Open();
                cmdDelete.Connection = conn;
                return ExecuteDeletionCommand(idContactDetails, cmdDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                cmdDelete.Dispose();
            }
        }

        public int DeleteTblContactDetailsTO(Int32 idContactDetails, SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand cmdDelete = new SqlCommand();
            try
            {
                cmdDelete.Connection = conn;
                cmdDelete.Transaction = tran;
                return ExecuteDeletionCommand(idContactDetails, cmdDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmdDelete.Dispose();
            }
        }

        public int ExecuteDeletionCommand(Int32 idContactDetails, SqlCommand cmdDelete)
        {
            cmdDelete.CommandText = "DELETE FROM [tblContactDetails] " +
            " WHERE idContactDetails = " + idContactDetails + "";
            cmdDelete.CommandType = System.Data.CommandType.Text;

            //cmdDelete.Parameters.Add("@idOrgType", System.Data.SqlDbType.Int).Value = dimOrgTypeTO.IdOrgType;
            return cmdDelete.ExecuteNonQuery();
        }
        #endregion
    }
}
