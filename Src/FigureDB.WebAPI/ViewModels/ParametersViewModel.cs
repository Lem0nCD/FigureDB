using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FigureDB.WebAPI.ViewModels
{
    public class ParametersViewModel : IValidatableObject
    {
        private int index;
        public int Index
        {
            get { return index - 1; }
            set { index = value; }
            //get; set;
        }
        public int Size { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (index < 1)
            {
                yield return new ValidationResult("Index is less then 1!");
            }
            if (Size < 1)
            {
                yield return new ValidationResult("Size is less then 1!");
            }
        }
    }
}
