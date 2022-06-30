﻿using Solucao.Application.Contracts;
using Solucao.Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucao.Application.Service.Interfaces
{
    public interface ICalendarService
    {
        Task<ValidationResult> Add(CalendarViewModel calendar, Guid user);
        Task<ValidationResult> Update(CalendarViewModel calendar, Guid user);
        Task<IEnumerable<CalendarViewModel>> GetAll(DateTime date);
        Task<IEnumerable<EquipamentList>> GetAllByDate(DateTime date);
        Task<CalendarViewModel> GetById(Guid id);
        Task<ValidationResult> UpdateDriverOrTechniqueCalendar(Guid id, Guid personId, bool isDriver);
        Task<ValidationResult> UpdateStatusOrTravelOnCalendar(Guid id, string status, string travelOn, bool isTravelOn);
        Task<ValidationResult> UpdateContractMade(Guid id);
        Task<ValidationResult> ValidateLease(DateTime date, Guid clientId, Guid equipamentId, IList<CalendarSpecifications> specifications ,string startTime, string endTime);
        Task<IEnumerable<CalendarViewModel>> Availability(DateTime startDate, DateTime endDate, Guid? clientId, Guid? equipamentId);


    }
}
