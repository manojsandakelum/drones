using DroneRepositories;
using DroneRepositories.Interfaces;
using DronesDTO;
using DronesEntity;
using DroneServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DroneServices
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository = null;
        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public IList<MedicationReturnDTO> GetAllAvailables()
        {
            var medicationReturns = new List<MedicationReturnDTO>();
            try
            {
                var mappingList = _medicationRepository.GetAllAvailables();

                foreach (var data in mappingList)
                {
                    MedicationReturnDTO dto = new MedicationReturnDTO();
                    dto.Id = data.Id;
                    dto.Name = data.Name;
                    dto.Weight = data.Weight;
                    dto.code = data.Code;
                    dto.image = data.Image;
                    medicationReturns.Add(dto);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return medicationReturns;
        }


        public string Save(MedicationDTO medicationDTO)
        {
            string result = "Insert failed";
            try
            {
                if (medicationDTO != null)
                {
                    string[] ar = medicationDTO.Name.Split('-').ToArray();
                    foreach (string s in ar)
                    {
                        if (s.Trim() != "")
                        {
                            bool isMatch = Regex.IsMatch(s, @"^\w+$", RegexOptions.IgnorePatternWhitespace);
                            if (!isMatch)
                            {
                                return "Medication name only allow letters, numbers, underscore or dash";
                            }
                        }
                    }
                    if (medicationDTO.Code.Trim() != "")
                    {
                        bool isCodeMatch = Regex.IsMatch(medicationDTO.Code, @"^\w+$", RegexOptions.IgnorePatternWhitespace);
                        if (!isCodeMatch)
                        {
                            return "Medication code only allow letters, numbers, underscore";
                        }
                    }
                    MedicationEntity medicationEntity = new MedicationEntity();
                    medicationEntity.Name = medicationDTO.Name;
                    medicationEntity.Weight = medicationDTO.Weight;
                    medicationEntity.Code = medicationDTO.Code;
                    medicationEntity.Image = Convert.FromBase64String(medicationDTO.Image);
                    _medicationRepository.Save(medicationEntity);
                    result = "Insert Suceess";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}

