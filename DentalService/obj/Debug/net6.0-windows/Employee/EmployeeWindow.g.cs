<<<<<<< HEAD
﻿#pragma checksum "..\..\..\..\Employee\EmployeeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33DFDA764C55434B325B4DF5E98D74EAD4E1E511"
=======
﻿#pragma checksum "..\..\..\..\Employee\EmployeeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E8ED29CAFE6AFFD4BCBEAF317F097AC40C567076"
>>>>>>> main
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
    /// EmployeeWindow
    /// </summary>
    public partial class EmployeeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 71 "..\..\..\..\Employee\EmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomerAppoitment;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Employee\EmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerPhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Employee\EmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LoadingLabel;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Employee\EmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateAppointmentButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Employee\EmployeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditAppointmentButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DentalService;component/employee/employeewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Employee\EmployeeWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 17 "..\..\..\..\Employee\EmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
<<<<<<< HEAD
            this.CustomerPhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\Employee\EmployeeWindow.xaml"
            this.CustomerPhoneTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnCustomerPhoneChanged);
=======
            this.CustomerAppoitment = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 89 "..\..\..\..\Employee\EmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateAppointment_Click);
>>>>>>> main
            
            #line default
            #line hidden
            return;
            case 5:
            
<<<<<<< HEAD
            #line 61 "..\..\..\..\Employee\EmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DirtyReadClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 62 "..\..\..\..\Employee\EmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReadCommittedClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LoadingLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 65 "..\..\..\..\Employee\EmployeeWindow.xaml"
            ((System.Windows.Controls.DataGrid)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CreateAppointmentButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\Employee\EmployeeWindow.xaml"
            this.CreateAppointmentButton.Click += new System.Windows.RoutedEventHandler(this.CreateAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditAppointmentButton = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\Employee\EmployeeWindow.xaml"
            this.EditAppointmentButton.Click += new System.Windows.RoutedEventHandler(this.EditAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 94 "..\..\..\..\Employee\EmployeeWindow.xaml"
=======
            #line 107 "..\..\..\..\Employee\EmployeeWindow.xaml"
>>>>>>> main
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InvoiceButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 80 "..\..\..\..\Employee\EmployeeWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

