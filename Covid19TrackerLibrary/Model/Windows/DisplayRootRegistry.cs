using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Covid19TrackerLibrary.Model.Windows
{
    /*Класс отвечающий за логику открытия, закрытия и не только окон
     Основная логика состоит в том что окно привязывается к viewmodel и уже с помощью него открывается
     */
    public class DisplayRootRegistry
    {
        //Пара словарей необходимых для регистрации и проверки открытых окон
        Dictionary<Type, Type> ViewModelWindowsMapping;
        Dictionary<object, Window> OpenWindows;
        
        //Конструктор

        #region Constructor

        public DisplayRootRegistry()
        {
            ViewModelWindowsMapping = new Dictionary<Type, Type>();
            OpenWindows = new Dictionary<object, Window>();
        }

        #endregion

        //Метод реализующий логику регистрации окна
        public void RegistryWindowType<ViewModel, Win>() where ViewModel : class where Win : Window, new()
        {
            Type ViewModelType = typeof(ViewModel);
            if (ViewModelType.IsInterface)
                throw new Exception("Cannot registry interfaces");
            if (ViewModelWindowsMapping.ContainsKey(ViewModelType))
                throw new Exception($"Type is already registred");
            ViewModelWindowsMapping[ViewModelType] = typeof(Win);
        }

        //Метод для выписки окна из списка зарегистрированных 
        public void UnregistryWindowType<ViewModel>()
        {
            Type ViewModelType = typeof(ViewModel);
            if (ViewModelType.IsInterface)
                throw new Exception("Cannot registry interfaces");
            if (ViewModelWindowsMapping.ContainsKey(ViewModelType))
                throw new Exception($"Type is already registred");
            ViewModelWindowsMapping.Remove(ViewModelType);
        }

        //Метод, реализующий логику создание окна с помощью ViewModel
        public Window CreateWindowInstanceWithViewModel(object viewModel)
        {
            if (viewModel == null)
                throw new Exception("View model is null");
            Type WindowType = null;
            Type ViewModelType = viewModel.GetType();
            while(ViewModelType != null && !ViewModelWindowsMapping.TryGetValue(ViewModelType, out WindowType))
                ViewModelType = ViewModelType.BaseType;
            if (WindowType == null)
                throw new Exception($"No registred window type for argument type {viewModel.GetType().FullName}");
            Window Window = (Activator.CreateInstance(WindowType) as Window);
            Window.DataContext = viewModel;
            return Window;
        }

        //Метод, реализующий логику показа окна с помощью async/await
        public async Task ShowModalPresendation(object viewModel)
        {
            Window Window = CreateWindowInstanceWithViewModel(viewModel);
            await Window.Dispatcher.InvokeAsync(() => Window.ShowDialog());
        }

        //Метод, реализующий логику показа окна
        public void ShowPresentation(object viewModel)
        {
            if (viewModel == null)
                throw new Exception("View model is null");
            if (OpenWindows.ContainsKey(viewModel))
                throw new Exception("Ui is already open");
            Window Window = CreateWindowInstanceWithViewModel(viewModel);
            Window.Show();
            OpenWindows[viewModel] = Window;
        }

        //Метод, реализующий логику сокрытия окна
        public void HidePresentation(object viewModel)
        {
            Window window;
            if (!OpenWindows.TryGetValue(viewModel, out window))
                throw new InvalidOperationException("UI for this VM is not displayed");
            window.Close();
            OpenWindows.Remove(viewModel);

        }
    }
}
