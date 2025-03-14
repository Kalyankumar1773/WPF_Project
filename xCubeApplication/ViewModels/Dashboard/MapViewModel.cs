﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using xCubeApplication.Helpers;

namespace xCubeApplication.ViewModels.Dashboard
{
    public class MapViewModel : BaseViewModel
    {
        private double _scaleX = 1.0;
        private double _scaleY = 1.0;

        public double ScaleX
        {
            get => _scaleX;
            set
            {
                _scaleX = value;
                OnPropertyChanged("ScaleX");
            }
        }

        public double ScaleY
        {
            get => _scaleY;
            set
            {
                _scaleY = value;
                OnPropertyChanged("ScaleY");
            }
        }

        public ICommand _zoomInCommand;
        public ICommand ZoomInCommand
        {
            get
            {
                return _zoomInCommand ?? (_zoomInCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        ZoomIn();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }
        public ICommand _zoomOutCommand;
        public ICommand ZoomOutCommand
        {
            get
            {
                return _zoomOutCommand ?? (_zoomOutCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        ZoomOut();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }
       

        private void ZoomIn()
        {
            ScaleX *= 1.2;
            ScaleY *= 1.2;
        }

        private void ZoomOut()
        {
            ScaleX *= 0.8;
            ScaleY *= 0.8;
        }

        private void OnMouseWheel(MouseWheelEventArgs e)
        {
            if (e.Delta > 0) 
                ZoomIn();
            else if (e.Delta < 0) 
                ZoomOut();
        }
    }
}
