using System;
using Enigma.Model;
using Xamarin.Forms;

namespace Enigma.DataTemplateSelectors
{
    internal class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate BoolDataTemplate { get; set; }
        public DataTemplate FloatDataTemplate { get; set; }
        public DataTemplate Int16DataTemplate { get; set; }
        public DataTemplate Int32DataTemplate { get; set; }
        public DataTemplate StringDataTemplate { get; set; }
        public DataTemplate SelectDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var parameter = (Parameter) item;

            switch (parameter.Type)
            {
                case "Bool":
                    return BoolDataTemplate;

                case "Float":
                    return FloatDataTemplate;

                case "Integer16":
                    return Int16DataTemplate;

                case "Integer32":
                    return Int32DataTemplate;

                case "String":
                    return StringDataTemplate;

                case "Select":
                    return SelectDataTemplate;


                default:
                    throw new NotSupportedException();
            }
        }
    }
}