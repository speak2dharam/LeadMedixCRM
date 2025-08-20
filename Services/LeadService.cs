using LeadMedixCRM.Data;
using LeadMedixCRM.DTOs;
using LeadMedixCRM.Interfaces;
using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Services
{
    public class LeadService:ILeadService
    {
        private ApplicationDbContext _context;
        public LeadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(LeadDto dto)
        {
            var Lead = new Lead 
            { 
                PatientName=dto.PatientName,
                Age=dto.Age,
                Gender=dto.Gender,
                CountryID=dto.CountryID,
                ContactNumber=dto.ContactNumber,
                WhatsAppNo=dto.WhatsAppNo,
                Email=dto.Email,
                MedicalIssue=dto.MedicalIssue,
                TreatmentCategoryId=dto.TreatmentCategoryId,
                LeadSourceId=dto.LeadSourceId,
                LeadQualityId=dto.LeadQualityId,
                StatusId=dto.StatusId,
                CreatedBy=dto.CreatedBy,

            };
            _context.Lead.Add(Lead);
            await _context.SaveChangesAsync();

            return "Source added successfully.";
        }

        public Task<bool> Delete(int LeadId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LeadResponseDto>> GetAllAsync(AuthUserDto adto)
        {
            List<Lead> leads;
            if (adto.Role=="SuperAdmin" || adto.Role=="Admin")
            {
                leads = await _context.Lead.ToListAsync();
            }
            else
            {
                leads = await _context.Lead.Where(l => l.CreatedBy == adto.UserId).ToListAsync();
            }

            if (leads == null || !leads.Any())
            {
                return null;
            }

            var countries = await _context.Country.ToListAsync();
            var categories = await _context.TreatmentCategory.ToListAsync();
            var sources = await _context.LeadSource.ToListAsync();
            var qualities = await _context.LeadQuality.ToListAsync();
            var statuses = await _context.LeadStatus.ToListAsync();

            var response = leads.Select(l => new LeadResponseDto
            {
                LeadId = l.LeadId,
                PatientName = l.PatientName,
                Age = l.Age,
                Gender = l.Gender,

                Country = new CountryDto
                {
                    CountryId = l.CountryID,
                    CountryName = countries.FirstOrDefault(c => c.CountryId == l.CountryID)?.CountryName,
                    Alpha2Code = countries.FirstOrDefault(c => c.CountryId == l.CountryID)?.Alpha2Code,
                    Alpha3Code = countries.FirstOrDefault(c => c.CountryId == l.CountryID)?.Alpha3Code,
                    NumericCode = countries.FirstOrDefault(c => c.CountryId == l.CountryID)?.NumericCode,
                    PhoneCode = countries.FirstOrDefault(c => c.CountryId == l.CountryID)?.PhoneCode
                },

                ContactNumber = l.ContactNumber,
                WhatsAppNo = l.WhatsAppNo,
                Email = l.Email,
                MedicalIssue = l.MedicalIssue,

                TreatmentCategoryId = new TreatmentCategoryDto
                {
                    TreatmentCategoryId = l.TreatmentCategoryId,
                    CategoryName = categories.FirstOrDefault(c => c.TreatmentCategoryId == l.TreatmentCategoryId)?.CategoryName
                },

                LeadSourceId = new LeadSourceDto
                {
                    LeadSourceId = l.LeadSourceId,
                    SourceName = sources.FirstOrDefault(s => s.LeadSourceId == l.LeadSourceId)?.SourceName
                },

                LeadQualityId = new LeadQualityDto
                {
                    LeadQualityId = l.LeadQualityId,
                    QualityName = qualities.FirstOrDefault(q => q.LeadQualityId == l.LeadQualityId)?.QualityName
                },

                StatusId = new LeadStatusDto
                {
                    StatusId = l.StatusId,
                    StatusName = statuses.FirstOrDefault(s => s.StatusId == l.StatusId)?.StatusName
                },

                CreatedBy = l.CreatedBy,
                CreatedAt = l.CreatedAt.ToString("dd/MM/yyyy"),
                UpdatedAt = l.UpdatedAt?.ToString("dd/MM/yyyy")
            });

            return response;
        }

        public async Task<LeadResponseDto> GetById(int LeadId, AuthUserDto adto)
        {
            Lead l;
            if (adto.Role == "SuperAdmin" || adto.Role == "Admin")
            {
                l = await _context.Lead.FirstOrDefaultAsync(x => x.LeadId == LeadId);
            }
            else
            {
                l = await _context.Lead.FirstOrDefaultAsync(x => x.LeadId == LeadId && x.CreatedBy==adto.UserId);
            }

            if (l == null)
            {
                return null;
            }

            //var l = await _context.Lead.FirstOrDefaultAsync(x => x.LeadId == LeadId);
            if (l == null) return null;

            var country = await _context.Country.FirstOrDefaultAsync(c => c.CountryId == l.CountryID);
            var category = await _context.TreatmentCategory.FirstOrDefaultAsync(c => c.TreatmentCategoryId == l.TreatmentCategoryId);
            var source = await _context.LeadSource.FirstOrDefaultAsync(s => s.LeadSourceId == l.LeadSourceId);
            var quality = await _context.LeadQuality.FirstOrDefaultAsync(q => q.LeadQualityId == l.LeadQualityId);
            var status = await _context.LeadStatus.FirstOrDefaultAsync(s => s.StatusId == l.StatusId);

            return new LeadResponseDto
            {
                LeadId = l.LeadId,
                PatientName = l.PatientName,
                Age = l.Age,
                Gender = l.Gender,
                Country = new CountryDto 
                { 
                    CountryId = l.CountryID, 
                    CountryName = country?.CountryName,
                    NumericCode = country?.NumericCode,
                    Alpha2Code = country?.Alpha2Code,
                    Alpha3Code = country?.Alpha3Code,
                    PhoneCode = country?.PhoneCode,
                },
                ContactNumber = l.ContactNumber,
                WhatsAppNo = l.WhatsAppNo,
                Email = l.Email,
                MedicalIssue = l.MedicalIssue,
                TreatmentCategoryId = new TreatmentCategoryDto 
                { 
                    TreatmentCategoryId = l.TreatmentCategoryId, 
                    CategoryName = category?.CategoryName
                },
                LeadSourceId = new LeadSourceDto { LeadSourceId = l.LeadSourceId, SourceName = source?.SourceName },
                LeadQualityId = new LeadQualityDto { LeadQualityId = l.LeadQualityId, QualityName = quality?.QualityName },
                StatusId = new LeadStatusDto { StatusId = l.StatusId, StatusName = status?.StatusName },
                CreatedBy = l.CreatedBy,
                CreatedAt = l.CreatedAt.ToString("dd/MM/yyyy"),
                UpdatedAt = l.UpdatedAt?.ToString("dd/MM/yyyy")
            };
        }

        public async Task<LeadDto> Update(int LeadId, LeadDto dto)
        {
            var existing = await _context.Lead.FindAsync(LeadId);
            if (existing == null) throw new Exception("Lead not found.");

            existing.PatientName = dto.PatientName;
            existing.Age = dto.Age;
            existing.Gender = dto.Gender;
            existing.CountryID = dto.CountryID;
            existing.ContactNumber = dto.ContactNumber;
            existing.WhatsAppNo = dto.WhatsAppNo;
            existing.Email = dto.Email;
            existing.MedicalIssue = dto.MedicalIssue;
            existing.TreatmentCategoryId = dto.TreatmentCategoryId;
            existing.LeadSourceId = dto.LeadSourceId;
            existing.LeadQualityId = dto.LeadQualityId;
            existing.StatusId = dto.StatusId;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Map entity to DTO before returning
            return new LeadDto
            {
                PatientName = existing.PatientName,
                Age = existing.Age,
                Gender = existing.Gender,
                CountryID = existing.CountryID,
                ContactNumber = existing.ContactNumber,
                WhatsAppNo = existing.WhatsAppNo,
                Email = existing.Email,
                MedicalIssue = existing.MedicalIssue,
                TreatmentCategoryId = existing.TreatmentCategoryId,
                LeadSourceId = existing.LeadSourceId,
                LeadQualityId = existing.LeadQualityId,
                StatusId = existing.StatusId,
                UpdatedAt = DateTime.UtcNow,
            };
        }
    }
}
