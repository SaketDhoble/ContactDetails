using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetails.Models;
using ContactDetails.StaticStuff;
using ContactDetails.DAL.Interfaces;
using ContactDetails.BL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ContactDetails.BL
{
    public class TblContactDetailsBL : ITblContactDetailsBL
    {
        #region Selection
        private readonly ITblContactDetailsDAL _iTblContactDetailsDAL;
        public TblContactDetailsBL(ITblContactDetailsDAL iTblContactDetailsDAL)
        {
            _iTblContactDetailsDAL = iTblContactDetailsDAL;
        }
        public List<TblContactDetailsTO> SelectTblContactDetailsList()
        {
            return _iTblContactDetailsDAL.SelectTblContactDetails();
        }

        public TblContactDetailsTO SelectTblContactDetailsTO(Int32 idContactDetails)
        {
            return _iTblContactDetailsDAL.SelectTblContactDetailsTO(idContactDetails);
        }

        #endregion

        #region Insertion

        public ResultMessage InsertTblContactDetails(TblContactDetailsTO tblContactDetailsTO)
        {
            ResultMessage resultMessage = new ResultMessage();

            try
            {
                List<TblContactDetailsTO> aleadyExistTblContactDetailsTOList = _iTblContactDetailsDAL.SelectTblContactDetailsByDetails(tblContactDetailsTO);
                //Check if already exist
                if (aleadyExistTblContactDetailsTOList.Count >= 1)
                {
                    resultMessage.DefaultSuccessBehaviour();
                    resultMessage.DisplayMessage = "Record already exist";
                    return resultMessage;
                }

                tblContactDetailsTO.CreatedBy = 1;
                tblContactDetailsTO.CreatedBy = 1;
                tblContactDetailsTO.CreatedOn = DateTime.Now; //Server DateTime
                tblContactDetailsTO.UpdatedOn = DateTime.Now; //Server DateTime


                Int32 result = InsertTblContactDetailsTO(tblContactDetailsTO);
                if (result == 1)
                {
                    resultMessage.DefaultSuccessBehaviour();
                    resultMessage.DisplayMessage += " #" + tblContactDetailsTO.IdContactDetails;
                }
                return resultMessage;
            }
            catch (Exception ex)
            {
                resultMessage.DefaultExceptionBehaviour(ex, "Exception in Method - ResultMessage InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO)");
                throw;
            }
        }

        public int InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO)
        {
            return _iTblContactDetailsDAL.InsertTblContactDetailsTO(tblContactDetailsTO);
        }

        public int InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran)
        {
            return _iTblContactDetailsDAL.InsertTblContactDetails(tblContactDetailsTO, conn, tran);
        }


        #endregion

        #region Updation

        public ResultMessage UpdateTblContactDetails(TblContactDetailsTO tblContactDetailsTO)
        {
            ResultMessage resultMessage = new ResultMessage();

            try
            {
                TblContactDetailsTO existingTblContactDetailsTO = _iTblContactDetailsDAL.SelectTblContactDetailsTO(tblContactDetailsTO.IdContactDetails);
                if (existingTblContactDetailsTO == null)
                {
                    resultMessage.DefaultSuccessBehaviour();
                    resultMessage.DisplayMessage = "Record not found";
                    resultMessage.Text = resultMessage.DisplayMessage;
                    return resultMessage;
                }

                if (existingTblContactDetailsTO.IsActive == 0)
                {
                    resultMessage.DefaultSuccessBehaviour();
                    resultMessage.DisplayMessage = "Contact details not active";
                    resultMessage.Text = resultMessage.DisplayMessage;
                    return resultMessage;
                }

                List<TblContactDetailsTO> aleadyExistTblContactDetailsTOList = _iTblContactDetailsDAL.SelectTblContactDetailsByDetails(tblContactDetailsTO);
                //Check if already exist
                if (aleadyExistTblContactDetailsTOList.Count >= 1)
                {
                    resultMessage.DefaultSuccessBehaviour();
                    resultMessage.DisplayMessage = "Record already exist";
                    resultMessage.Text = resultMessage.DisplayMessage;
                    return resultMessage;
                }

                tblContactDetailsTO.UpdatedBy = 1;
                tblContactDetailsTO.UpdatedOn = DateTime.Now; //Server DateTime

                Int32 result = UpdateTblContactDetailsTO(tblContactDetailsTO);
                if (result == 1)
                {
                    resultMessage.DefaultSuccessBehaviour();
                    resultMessage.DisplayMessage += " #" + tblContactDetailsTO.IdContactDetails;
                }
                return resultMessage;
            }
            catch (Exception ex)
            {
                resultMessage.DefaultExceptionBehaviour(ex, "Exception in Method - ResultMessage InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO)");
                throw;
            }
        }

        public int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO)
        {
            return _iTblContactDetailsDAL.UpdateTblContactDetailsTO(tblContactDetailsTO);
        }

        public int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran)
        {
            return _iTblContactDetailsDAL.UpdateTblContactDetailsTO(tblContactDetailsTO, conn, tran);
        }

        #endregion

        #region Deletion
        public int DeleteTblContactDetailsTO(Int32 idContactDetails)
        {
            return _iTblContactDetailsDAL.DeleteTblContactDetailsTO(idContactDetails);
        }

        public int DeleteTblContactDetailsTO(Int32 idContactDetails, SqlConnection conn, SqlTransaction tran)
        {
            return _iTblContactDetailsDAL.DeleteTblContactDetailsTO(idContactDetails, conn, tran);
        }

        #endregion
    }
}
