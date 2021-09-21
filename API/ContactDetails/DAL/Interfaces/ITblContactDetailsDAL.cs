using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDetails.Models;
using System.Data;
using System.Data.SqlClient;

namespace ContactDetails.DAL.Interfaces
{
    public interface ITblContactDetailsDAL
    {
        String SqlSelectQuery();
        List<TblContactDetailsTO> SelectTblContactDetails();
        TblContactDetailsTO SelectTblContactDetailsTO(Int32 idContactDetails);
        List<TblContactDetailsTO> SelectTblContactDetailsByDetails(TblContactDetailsTO tblContactDetailsTO);
        int InsertTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO);

        int InsertTblContactDetails(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran);
        int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO);
        int UpdateTblContactDetailsTO(TblContactDetailsTO tblContactDetailsTO, SqlConnection conn, SqlTransaction tran);
        int DeleteTblContactDetailsTO(Int32 idContactDetails);
        int DeleteTblContactDetailsTO(Int32 idContactDetails, SqlConnection conn, SqlTransaction tran);
    }
}
