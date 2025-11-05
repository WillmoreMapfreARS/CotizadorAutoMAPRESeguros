using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotizadorAutoMAPFRESeguros.Share.Models
{
    public class IdentificacionDTO
    {
        public string clientId { get; set; } = string.Empty;
        public NaturalPerson naturalPerson { get; set; } = new NaturalPerson();
        public LoyaltyPlan loyaltyPlan { get; set; } = new LoyaltyPlan();
        public Address address { get; set; } = new Address();
        public List<ContactMethod> contactMethods { get; set; } = new List<ContactMethod>();
        public IdentificationMethod identificationMethod { get; set; } = new IdentificationMethod();
    }

    public class NaturalPerson
    {
        public PersonName personName { get; set; } = new PersonName();
        public string nickname { get; set; } = string.Empty;
        public string genderCode { get; set; } = string.Empty;
        public string genderDesc { get; set; } = string.Empty;
        public EducativeInformation educativeInformation { get; set; } = new EducativeInformation();
        public LabourInformation labourInformation { get; set; }    =new LabourInformation();
    }   

    public class PersonName
    {
        public string name { get; set; } = string.Empty;
        public string firstSurname { get; set; } = string.Empty;
        public string secondSurname { get; set; } = string.Empty;
    }

    public class EducativeInformation
    {
        // El JSON tiene un objeto vacío {}, se puede completar después según estructura real
    }

    public class LabourInformation
    {
        // También está vacío, se puede expandir luego
    }

    public class LoyaltyPlan
    {
        public bool applyLoyaltyPlanInd { get; set; }
    }

    public class Address
    {
        public string addressId { get; set; } = string.Empty;
        public string addressTypeCode { get; set; } = string.Empty;
        public string addressName { get; set; } = string.Empty;
        public string stateCode { get; set; } = string.Empty;
        public string countryCode { get; set; } = string.Empty;
        public bool checkInd { get; set; }  
    }

    public class ContactMethod
    {
        public string contactMethodId { get; set; } = string.Empty;
        public string contactMethodTypeCode { get; set; } = string.Empty;
        public string contactMethodTypeDesc { get; set; } = string.Empty;
        public string contactTypeCode { get; set; } = string.Empty;
        public string contactMethodValue { get; set; } = string.Empty;
        public bool contactDefaultInd { get; set; }
        public bool contactCheckInd { get; set; }
    }

    public class IdentificationMethod
    {
        public string identityDocumentTypeCode { get; set; } = string.Empty;
        public string identityDocumentNumber { get; set; } = string.Empty;
    }

}
