using KBHKY2_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KBHKY2_GUI_WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Brand> Brands { get; set; }
        public RestCollection<Owner> Owners { get; set; }


        private Car selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {

                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Id = value.Id,
                        Model = value.Model,
                        BasePrice = value.BasePrice,
                        BrandId = value.BrandId
                    };
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        private Brand selectedBrand;
        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {

                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Id = value.Id,
                        Name = value.Name
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        private Owner selectedOwner;
        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set
            {

                if (value != null)
                {
                    selectedOwner = new Owner()
                    {
                        Id = value.Id,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Age = value.Age,
                        CarId = value.CarId
                    };
                    OnPropertyChanged();
                    (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        public ICommand CreateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("http://localhost:54669/", "car", "hub");
                Brands = new RestCollection<Brand>("http://localhost:54669/", "brand", "hub");
                Owners = new RestCollection<Owner>("http://localhost:54669/", "owner", "hub");

                CreateCarCommand = new RelayCommand(() =>
                {
                    Cars.Add(new Car()
                    {
                        Model = SelectedCar.Model,
                        BasePrice = SelectedCar.BasePrice,
                        BrandId = SelectedCar.BrandId
                    });
                });
                UpdateCarCommand = new RelayCommand(() =>
                {
                    Cars.Update(SelectedCar);
                });
                DeleteCarCommand = new RelayCommand(() =>
                {
                    Cars.Delete(SelectedCar.Id);
                },
                () =>
                {
                    return SelectedCar != null;
                });

                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name
                    });
                });
                UpdateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Update(SelectedBrand);
                });
                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.Id);
                },
                () =>
                {
                    return SelectedBrand != null;
                });

                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        FirstName = SelectedOwner.FirstName,
                        LastName = SelectedOwner.LastName,
                        Age = SelectedOwner.Age,
                        CarId = SelectedOwner.CarId
                    });
                });
                UpdateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Update(SelectedOwner);
                });
                DeleteOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Delete(SelectedOwner.Id);
                },
                () =>
                {
                    return SelectedOwner != null;
                });

                SelectedCar = new Car();
                SelectedBrand = new Brand();
                SelectedOwner = new Owner();
            }

        }
    }
}
