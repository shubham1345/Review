using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public static class Procedure
    {

        #region common 
        public const string GetAllGender = "sp_get_genderdetail";
        public const string GetAllMenuByRole = "sp_get_all_menu_by_role";
        #endregion
    
        #region college 
        public const string GetCollegeDetails = "sp_get_collegedetail";
        public const string InsertUpdateDeleteCollege = "sp_insert_update_delete_college";
        #endregion
    
        #region branch 
        public const string GetBranchDetails = "sp_get_branchdetail";
        public const string InsertUpdateDeleteBranch = "sp_insert_update_delete_branch";
        #endregion
    
        #region student 
        public const string GetStudentDetails = "sp_get_studentdetail";
        public const string InsertUpdateDeleteStudent = "sp_insert_update_delete_student";
        #endregion
    
        #region User 
        public const string GetUserByUserName = "sp_get_logindetail";
        public const string InsertUpdateDeleteUser = "sp_insert_update_delete_user";
        #endregion
    }
}
