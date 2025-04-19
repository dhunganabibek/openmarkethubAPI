namespace openmarkethubAPI.Abstractions;

public interface IAuditedEntities
{
    DateTime? CreatedDate { get; set; }
    string? CreatedBy { get; set; }
    DateTime? ModifiedDate { get; set; }
    string? ModifiedBy { get; set; }
}