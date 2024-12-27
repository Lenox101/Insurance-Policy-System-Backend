using System.ComponentModel.DataAnnotations;

namespace InsurancePolicyAPI.Models;

public class InsurancePolicy
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string PolicyNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string HolderName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string PolicyType { get; set; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal CoverageAmount { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal PremiumAmount { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Active";
} 