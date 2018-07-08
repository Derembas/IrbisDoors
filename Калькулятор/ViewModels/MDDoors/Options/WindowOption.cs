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

        // Не стандартный размер
        public BaseClasses.Property NotStandartSize { get; private set; }

        // Обрамление окна
        public BaseClasses.Property WindowFrame { get; private set; }

        // Форма окна
        public BaseClasses.Property WindowForm { get; private set; }

        #endregion

        #region Варианты форм окна

        object[] windowFrames; // Возможные формы окна

        object[] rubberForms; // Список для резинового обрамления
        object[] metallForms; // Список для металлического обрамления

        #endregion

        #region Конструктор

        public WindowOption() : base("Окно", true)
        {
            windowFrames = new object[]
            {
                Helpers.AllNames.MDWindowFrames.rubberFrame,
                Helpers.AllNames.MDWindowFrames.metalFrame,
                Helpers.AllNames.MDWindowFrames.noFrame
            };

            rubberForms = new object[]
            {
                Helpers.AllNames.MDWindowForms.ellipse200x580,
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

            NotStandartSize = new BaseClasses.Property("Не стандартный размер", Helpers.PropertyTypes.BoolType);
            WindowFrame = new BaseClasses.Property("Обрамление окна", Helpers.PropertyTypes.StringType, true) { Values = windowFrames };
            WindowForm = new BaseClasses.Property("Форма окна", Helpers.PropertyTypes.StringType, true) { Values = rubberForms };

            NotStandartSize.PropertyChanged += NotStandartSize_PropertyChanged;
            WindowFrame.PropertyChanged += WindowFrame_PropertyChanged;

            NotStandartSize.Value = false;

            base.properties.Add(NotStandartSize);
            base.properties.Add(WindowFrame);
            base.properties.Add(WindowForm);
        }



        #endregion

        private void NotStandartSize_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                if ((bool)NotStandartSize.Value)
                {
                    WindowFrame.UseValueList = true;
                    WindowFrame.IsEnabled = true;
                    WindowForm.UseValueList = true;
                    WindowForm.IsEnabled = true;
                }
                else
                {
                    WindowFrame.UseValueList = false;
                    WindowFrame.Value = Helpers.AllNames.MDWindowFrames.rubberFrame;
                    WindowFrame.IsEnabled = false;
                    WindowForm.UseValueList = false;
                    WindowForm.Value = Helpers.AllNames.MDWindowForms.ellipse300x580;
                    WindowForm.IsEnabled = false;
                }
            }
        }

        private void WindowFrame_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName=="Value")
            {
                if (WindowFrame.Value.Equals(Helpers.AllNames.MDWindowFrames.noFrame))
                {
                    WindowForm.UseValueList = false;
                    WindowForm.Value = "";
                    WindowForm.IsEnabled = false;

                }
                else
                {
                    WindowForm.UseValueList = true;
                    WindowForm.IsEnabled = true;

                    if (WindowFrame.Value.Equals(Helpers.AllNames.MDWindowFrames.rubberFrame))
                        WindowForm.Values = rubberForms;
                    else
                        WindowForm.Values = metallForms;
                }
            }
        }

        
    }
}
