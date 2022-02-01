namespace TestTaskApplication.Model
{
    class Employee
    {
        private string _ID;
        private string _Surname;
        private string _Name;
        private string _Patronymic;
        private string _Position;
        private string _Salary;
        private bool _isFired;
        private string _Department;

        public Employee(int _ID)
        {
            ID = (_ID + 1).ToString();
        }

        public string ID
        {
            get { return _ID; }
            set 
            {
                if (_ID == value)
                    return;
                _ID = value; 
            }
        }

        public string Surname
        {
            get { return _Surname; }
            set
            {
                if (_Surname == value)
                    return;
                _Surname = value;
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value)
                    return;
                _Name = value;
            }
        }

        public string Patronymic
        {
            get { return _Patronymic; }
            set
            {
                if (_Patronymic == value)
                    return;
                _Patronymic = value;
            }
        }

        public string Position
        {
            get { return _Position; }
            set
            {
                if (_Position == value)
                    return;
                _Position = value;
            }
        }

        public string Salary
        {
            get { return _Salary; }
            set
            {
                if (_Salary == value)
                    return;
                _Salary = value;
            }
        }

        public bool isFired
        {
            get { return _isFired; }
            set
            {
                if (_isFired == value)
                    return;
                _isFired = value;
            }
        }

        public string Department
        {
            get { return _Department; }
            set
            {
                if (_Department == value)
                    return;
                _Department = value;
            }
        }
    }
}
