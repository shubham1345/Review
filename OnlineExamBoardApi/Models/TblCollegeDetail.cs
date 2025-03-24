using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlineExamBoardApi.Models;

namespace OnlineExamBoardApi.Models;

public partial class TblCollegeDetail
{
    public int IntId { get; set; }

    public string? StrCollegeName { get; set; }

    public string? StrCollegeAddress { get; set; }

    public string? StrAffiliationNumber { get; set; }

    public string? StrContactNo { get; set; }

    public string? StrEmail { get; set; }

    public string? StrPhoneNo { get; set; }

    public bool? IsActive { get; set; }

    public int? IntCreatedBy { get; set; }

    public DateTime? DteCreatedDate { get; set; }

    public int? IntModifiedBy { get; set; }

    public DateTime? DteModifiedDate { get; set; }

    public virtual TblUser? IntCreatedByNavigation { get; set; }

    public virtual TblUser? IntModifiedByNavigation { get; set; }

    public virtual ICollection<TblExamResult> TblExamResults { get; set; } = new List<TblExamResult>();

    public virtual ICollection<TblStudentDetail> TblStudentDetails { get; set; } = new List<TblStudentDetail>();
}

 