using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WaterPOC.Repository.Models;

[Table("tblFeature")]
public partial class WaterLog
{
    [Column("FeatureName")]
    [Unicode(false)]
    public string? FeatureName { get; set; }

    [Column("LocationDescription")]
    [Unicode(false)]
    public string? LocationDescription { get; set; }

    [Key]
    [Column("ID")]
    public int? Id { get; set; }
}
