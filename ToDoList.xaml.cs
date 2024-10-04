using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Final_Project_Roi
{
    public partial class ToDoList : Page
    {
        public ToDoViewModel ViewModel { get; private set; }

        public ToDoList()
        {
            InitializeComponent();
            ViewModel = new ToDoViewModel();
            DataContext = ViewModel;
        }
    }

    public class ToDoViewModel : INotifyPropertyChanged
    {
        private ToDoItem _selectedToDoItem;
        private string _newTask;
        private bool _isTaskCompleted;
        private bool _isCheckBoxEnabled = false;
        private Visibility _checkBoxVisibility = Visibility.Collapsed;
        private int _taskCounter = 1;

        public ObservableCollection<ToDoItem> ToDoItems { get; set; }

        public ToDoItem SelectedToDoItem
        {
            get => _selectedToDoItem;
            set
            {
                if (_selectedToDoItem != value)
                {
                    _selectedToDoItem = value;
                    OnPropertyChanged();
                    UpdateCheckBoxState();
                }
            }
        }

        public string NewTask
        {
            get => _newTask;
            set
            {
                if (_newTask != value)
                {
                    _newTask = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsTaskCompleted
        {
            get => _isTaskCompleted;
            set
            {
                if (_isTaskCompleted != value)
                {
                    _isTaskCompleted = value;
                    OnPropertyChanged();
                    if (SelectedToDoItem != null)
                    {
                        SelectedToDoItem.IsCompleted = value;
                        OnPropertyChanged(nameof(ToDoItems));
                    }
                }
            }
        }

        public bool IsCheckBoxEnabled
        {
            get => _isCheckBoxEnabled;
            set
            {
                if (_isCheckBoxEnabled != value)
                {
                    _isCheckBoxEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public Visibility CheckBoxVisibility
        {
            get => _checkBoxVisibility;
            set
            {
                if (_checkBoxVisibility != value)
                {
                    _checkBoxVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public ToDoViewModel()
        {
            ToDoItems = new ObservableCollection<ToDoItem>();
            CreateCommand = new RelayCommand(CreateToDo, CanCreateOrUpdate);
            UpdateCommand = new RelayCommand(UpdateToDo, CanModify);
            DeleteCommand = new RelayCommand(DeleteToDo, CanModify);
        }

        private void CreateToDo(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(NewTask))
            {
                var newItem = new ToDoItem { Task = $"{_taskCounter++}. {NewTask}", IsCompleted = false };
                ToDoItems.Add(newItem);
                NewTask = string.Empty;
                OnPropertyChanged(nameof(NewTask));
                OnPropertyChanged(nameof(ToDoItems));
            }
        }

        private void UpdateToDo(object parameter)
        {
            if (SelectedToDoItem != null && !string.IsNullOrWhiteSpace(NewTask))
            {
                SelectedToDoItem.Task = $"{SelectedToDoItem.Index}. {NewTask}";
                OnPropertyChanged(nameof(ToDoItems));
            }
        }

        private void DeleteToDo(object parameter)
        {
            if (SelectedToDoItem != null)
            {
                ToDoItems.Remove(SelectedToDoItem);
                SelectedToDoItem = null;
                OnPropertyChanged(nameof(SelectedToDoItem));
                CheckBoxVisibility = Visibility.Collapsed;
            }
        }

        private bool CanCreateOrUpdate(object parameter)
        {
            return !string.IsNullOrWhiteSpace(NewTask);
        }

        private bool CanModify(object parameter)
        {
            return SelectedToDoItem != null;
        }

        private void UpdateCheckBoxState()
        {
            if (SelectedToDoItem != null)
            {
                IsCheckBoxEnabled = true;
                CheckBoxVisibility = Visibility.Visible;
            }
            else
            {
                IsCheckBoxEnabled = false;
                CheckBoxVisibility = Visibility.Collapsed;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class ToDoItem : INotifyPropertyChanged
    {
        private bool _isCompleted;

        public int Index { get; set; }
        public string Task { get; set; }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
