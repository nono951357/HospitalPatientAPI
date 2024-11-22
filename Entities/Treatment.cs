using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HospitalPatientAPI.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TreatmentDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation properties
        [JsonIgnore]
        [ForeignKey("PatientId")]
        public virtual Patient? Patient { get; set; }
        [JsonIgnore]
        [ForeignKey("DoctorId")]
        public virtual Doctor? Doctor { get; set; }

    }
}
