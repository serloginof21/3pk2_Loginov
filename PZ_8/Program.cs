using System;

namespace PZ_8
{

    class Program
    {
        static void Main(string[] args)
        {
            var _student = ContactDataFactory.CreateContactData("Students") as Students;
            _student.Name = "Loginov Sergey";
            _student.PhoneNumber = "89228484575";
            _student.Email = "sergeylogg@gmail.com";

            var _spec = ContactDataFactory.CreateContactData("Specialization") as Specialization;
            _spec.Name = "Seliverstov S.A.";
            _spec.PhoneNumber = "89054157190";
            _spec.Email = "ssa3421980@mail.com";

            var _college = ContactDataFactory.CreateContactData("College") as College;
            _college.Name = "OKEI";
            _college.PhoneNumber = "323-675-124";
            _college.Address = "Chkalova, 11";

            var AllContacts = new List<IContact> { _student, _spec, _college };

            foreach (var contact in AllContacts)
            {
                Console.WriteLine("\nName: " + contact.Name);
                Console.WriteLine("Phone number: " + contact.PhoneNumber);
            }
        }
    }
}