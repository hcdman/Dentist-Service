﻿#pragma checksum "..\..\..\..\Employee\CreateAppointment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FB97FBE61B7F263A64B106FFE636C5B12737F60D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DentalService.Employee;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace DentalService.Employee {
    
    
    /// <summary>
    /// CreateAppointment
    /// </summary>
    public partial class CreateAppointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\Employee\CreateAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker AppointmentDatePicker;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Employee\CreateAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StartTimeComboBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Employee\CreateAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EndTimeComboBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Employee\CreateAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateAppointmentButton;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Employee\CreateAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DentistsDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DentalService;component/employee/createappointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Employee\CreateAppointment.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AppointmentDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 27 "..\..\..\..\Employee\CreateAppointment.xaml"
            this.AppointmentDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.OnAppointmentDateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StartTimeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\..\Employee\CreateAppointment.xaml"
            this.StartTimeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnStartTimeChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EndTimeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\..\Employee\CreateAppointment.xaml"
            this.EndTimeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnEndTimeChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CreateAppointmentButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\Employee\CreateAppointment.xaml"
            this.CreateAppointmentButton.Click += new System.Windows.RoutedEventHandler(this.CreateAppointmentClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 57 "..\..\..\..\Employee\CreateAppointment.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DentistsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 66 "..\..\..\..\Employee\CreateAppointment.xaml"
            this.DentistsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DentistsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

