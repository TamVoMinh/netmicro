using Microsoft.AspNetCore.Mvc;
using Nmro.Web.ModelBinding;

namespace Nmro.IAM.Models
{
    [ModelBinder(BinderType = typeof(JsonModelBinder))]
    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsTrue { get; set; }

        public double FloatNumber { get; set; }

        public SecondTestModel NestedObject { get; set; }
    }

    public class SecondTestModel
    {
        public int SecondId { get; set; }
        public string SecondName { get; set; }
    }
}
