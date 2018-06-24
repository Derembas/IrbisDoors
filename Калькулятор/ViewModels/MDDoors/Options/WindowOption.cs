using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.MDDoors.Options
{
    public class WindowOption : BaseClasses.Option
    {

        #region Свойства

        // Обрамление окна
        public BaseClasses.Property WindowFrame { get; private set; }

        // Форма окна
        public BaseClasses.Property WindowForm { get; private set; }

        #endregion

        #region Варианты форм окна

        object[] rubberForms;
        object[] metallForms;

        #endregion

        #region Конструктор

        public WindowOption() : base("Окно")
        {
            var windowFrames = new object[]
            {
                Helpers.AllNames.MDWindowFrames.rubberFrame,
                Helpers.AllNames.MDWindowFrames.metalFrame
            };

            rubberForms = new object[]
            {
                Helpers.AllNames.MDWindowForms.ellipse200x580,
                Helpers.AllNames.MDWindowForms.ellipse300x580,
                Helpers.AllNames.MDWindowForms.circle300,
                Helpers.AllNames.MDWindowForms.circle350,
                Helpers.AllNames.MDWindowForms.circle400,
                Helpers.AllNames.MDWindowForms.circle450,
                Helpers.AllNames.MDWindowForms.rectangle400x600,
                Helpers.AllNames.MDWindowForms.rectangle500x700,
                Helpers.AllNames.MDWindowForms.square400,
                Helpers.AllNames.MDWindowForms.square700
            };

            metallForms = new object[] 
            {
                Helpers.AllNames.MDWindowForms.rectangle300x600,
                Helpers.AllNames.MDWindowForms.rectangle400x600,
                Helpers.AllNames.MDWindowForms.rectangle500x700,
                Helpers.AllNames.MDWindowForms.square400,
                Helpers.AllNames.MDWindowForms.square600,
                Helpers.AllNames.MDWindowForms.square700,
                Helpers.AllNames.MDWindowForms.rhomb200,
                Helpers.AllNames.MDWindowForms.rhomb300
            };

            WindowFrame = new BaseClasses.Property("Обрамление окна", Helpers.PropertyTypes.StringType, true) { Values = windowFrames };
            WindowForm = new BaseClasses.Property("Форма окна", Helpers.PropertyTypes.StringType, true, Helpers.AllNames.MDWindowForms.ellipse300x580) { Values = rubberForms };

            WindowFrame.PropertyChanged += WindowFrame_PropertyChanged;

            base.properties.Add(WindowFrame);
            base.properties.Add(WindowForm);
        }

        #endregion

        private void WindowFrame_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName=="Value")
            {
                if (WindowFrame.Value.Equals(Helpers.AllNames.MDWindowForms.ellipse200x580))
                    WindowForm.Values = rubberForms;
                else
                    WindowForm.Values = metallForms;
            }
        }

        
    }
}
