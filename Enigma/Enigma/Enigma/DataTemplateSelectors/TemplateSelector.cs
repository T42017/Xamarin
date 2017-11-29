using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigma.Model;
using Xamarin.Forms;

namespace Enigma.DataTemplateSelectors
{
    class TemplateSelector : DataTemplateSelector
    {

        public DataTemplate BoolDataTemplate { get; set; }
        public DataTemplate FloatDataTemplate { get; set; }
        public DataTemplate Int16DataTemplate { get; set; }
        public DataTemplate Int32DataTemplate { get; set; }
        public DataTemplate StringDataTemplate { get; set; }
        public DataTemplate SelectDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Parameter parameter = (Parameter) item;

            switch (parameter.Type)
            {
                case Parameter.ParameterType.Bool:
                    return BoolDataTemplate;

                case Parameter.ParameterType.Float:
                    return FloatDataTemplate;

                case Parameter.ParameterType.Integer16:
                    return Int16DataTemplate;

                case Parameter.ParameterType.Integer32:
                    return Int32DataTemplate;

                case Parameter.ParameterType.String:
                    return StringDataTemplate;

                case Parameter.ParameterType.Select:
                    return SelectDataTemplate;


                default:
                    throw new NotSupportedException();
                    

            }


        }
    }
}
