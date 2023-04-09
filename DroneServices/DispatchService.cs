using DroneDTO;
using DroneRepositories;
using DroneRepositories.Interfaces;
using DronesDTO;
using DronesEntity;
using DroneServices.Interfaces;
using DronesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DroneServices
{
    public class DispatchService : IDispatchService
    {
        private readonly IDroneRepository _droneRepository = null;
        private readonly IMedicationRepository _medicationRepository = null;
        private readonly IDispatchRepository _dispatchRepository = null;
        public DispatchService(IDispatchRepository dispatchRepository, IMedicationRepository medicationRepository, IDroneRepository droneRepository)
        {
            _dispatchRepository = dispatchRepository;
            _droneRepository = droneRepository;
            _medicationRepository = medicationRepository;
        }

        public IList<DispatchMedicationReturnDTO> GetListByDroneId(int id)
        {
            var list = (from dispatch in _dispatchRepository.GetListByDroneId(id)
                                 join medication in _medicationRepository.GetAllAvailables() on dispatch.MedicationId equals medication.Id
                                 select new DispatchMedicationReturnDTO
                                 { 
                                     DroneId = dispatch.DroneId,
                                     MedicationId = dispatch.MedicationId,
                                     Name = medication.Name,
                                     Weight = medication.Weight,
                                     NoOfMedications = dispatch.NoOfMedications,
                                     Code = medication.Code,
                                     Image = medication.Image

                                 }).ToList();
            return list;
            
        }

        public string Save(DispatchDTO medicationDTO)
        {
            string result = "Insert failed";
            try
            {
                if (medicationDTO != null)
                {
                    IList<DroneMedicationEntity> dispatchList = _dispatchRepository.GetListByDroneId(medicationDTO.DroneId);

                    DroneEntity droneEntity = _droneRepository.GetById(medicationDTO.DroneId);
                    if (droneEntity != null)
                    {
                        MedicationEntity medicationEntity1 = _medicationRepository.GetById(medicationDTO.MedicationId);
                      
                        if (medicationEntity1 != null)
                        {
                            double totalMedictions = dispatchList != null ? dispatchList.Sum(x => x.NoOfMedications) : 0;
                            double savedMediWeight = 0;
                            double newMediWeight = 0;
                            savedMediWeight = totalMedictions * (double)medicationEntity1.Weight;
                            newMediWeight = medicationDTO.NoOfMedications * (double)medicationEntity1.Weight;


                            if (droneEntity.WeightLimit < (savedMediWeight + newMediWeight))
                            {
                                result = "Can not added to drone, it will be overloaded.";

                            }
                            else if (droneEntity.BatteryCapasity < 25)
                            {
                                result = "Can not added to drone, battery level is below 25%";
                            }
                            else
                            {
                                DroneMedicationEntity medicationEntity = new DroneMedicationEntity();
                                medicationEntity.DroneId = medicationDTO.DroneId;
                                medicationEntity.MedicationId = medicationDTO.MedicationId;
                                medicationEntity.NoOfMedications = medicationDTO.NoOfMedications;
                                _dispatchRepository.Save(medicationEntity);
                                result = "Insert Suceess";
                            }
                        }
                        else
                        {
                            result = "Medication not found";
                        }
                    }
                    else
                    {
                        result = "Drone not found";
                    }
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

