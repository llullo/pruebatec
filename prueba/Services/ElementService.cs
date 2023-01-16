using AutoMapper;
using Entities.Models;
using prueba.Models;
using prueba.Models.Enums;
using prueba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace prueba.Services
{
    public class ElementService : IElementService
    {
        private readonly IElementRepository _elementRepository;
        private readonly IMapper _mapper;

        public ElementService(IElementRepository elementRepository, IMapper mapper)
        {
            _elementRepository = elementRepository;
            _mapper = mapper;
        }

        public void CreateElement(ElementDTO element)
        {
            element.State = StateEnum.Created;
            var el = ManageElementInQueue(element);
            _elementRepository.Create(_mapper.Map<Element>(el));
            _elementRepository.Save();
        }

        public void DeleteElement(ElementDTO element)
        {
            _elementRepository.Delete(_mapper.Map<Element>(element));
            _elementRepository.Save();
        }

        public ElementDTO GetElementById(int id)
        {
            var element = _mapper.Map<ElementDTO>(_elementRepository.FindByCondition(condition => condition.Id == id).FirstOrDefault());
            return element;
        }

        public List<ElementDTO> GetElementsByQueueId(int queueId)
        {
            List<ElementDTO> eList = new List<ElementDTO>();

            var elements = _elementRepository.FindByCondition(condition => condition.QueueId == queueId).ToList();
            foreach (var e in elements)
            {
                var eDTO = _mapper.Map<ElementDTO>(e);
                eList.Add(eDTO);
            }
            return eList;
        }

        
        public List<ElementDTO> GetElements()
        {
            var elements = _elementRepository.FindAll();
            List<ElementDTO> eList = new List<ElementDTO>();
            foreach (var e in elements)
            {
                var eDTO = _mapper.Map<ElementDTO>(e);
                eList.Add(eDTO);
            }
            return eList;
        }

        public void UpdateElement(ElementDTO element)
        {
            _elementRepository.Update(_mapper.Map<Element>(element));
            _elementRepository.Save();
        }
        //lógica gestor de colas
        public List<ElementDTO> GetRemainingsElements(int queueId)
        {
            if (queueId == 1)
            {

                return CheckIfAttendedQ1();
            }
            else
            {
                return CheckIfAttendedQ2();
            }
        }

        private ElementDTO ManageElementInQueue(ElementDTO element)
        {
            var TimeLeftQ1 = CheckIfAttendedQ1().Count() * 120;
            var TimeLeftQ2 = CheckIfAttendedQ2().Count() * 180;

            if (TimeLeftQ1 <= TimeLeftQ2)
            {
                element.QueueId = 1;
            }
            else
            {
                element.QueueId = 2;
            }
            element.StartDate = DateTime.Now;
            element.State = StateEnum.Waiting;
            return element;
        }

        private List<ElementDTO> CheckIfAttendedQ1()
        {
            List<ElementDTO> elementsRemaining = new List<ElementDTO>();
            var listEl = GetElementsByQueueId(1);
            foreach (var element in listEl)
            {
                var oldDate = DateTime.Parse(element.StartDate.ToString());
                if ((DateTime.Now - oldDate).TotalMinutes >= 2)
                {
                    DeleteElement(element);
                }
                else
                {
                    elementsRemaining.Add(element);
                }
            }
            return elementsRemaining;
        }

        private List<ElementDTO> CheckIfAttendedQ2()
        {
            List<ElementDTO> elementsRemaining = new List<ElementDTO>();
            var listEl = GetElementsByQueueId(2);
            foreach (var element in listEl)
            {
                var oldDate = DateTime.Parse(element.StartDate.ToString());
                if ((DateTime.Now - oldDate).TotalMinutes >= 3)
                {
                    DeleteElement(element);
                }
                else
                {
                    elementsRemaining.Add(element);
                }
            }
            return elementsRemaining;
        }
    }
}
