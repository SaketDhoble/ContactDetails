using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetails.Models;
using ContactDetails.StaticStuff;
using System.Data;
using System.Data.SqlClient;

namespace ContactDetails.BL.Interfaces
{
    public interface ITblContactDetailsBL
    {
        List<TblContactDetailsTO> SelectTblContactDetailsList();
        TblContactDetailsTO SelectTblContactDetailsTO(Int32 idContactDetails);
        ResultMessage InsertTblContactDetails(TblContactDetailsTO tblContactDetailsTO);
        int InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO);
        int InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran);
        int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO);
        int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran);
        ResultMessage UpdateTblContactDetails(TblContactDetailsTO tblContactDetailsTO);
        int DeleteTblContactDetailsTO(Int32 idContactDetails);
        int DeleteTblContactDetailsTO(Int32 idContactDetails, SqlConnection conn, SqlTransaction tran);
    }
}
