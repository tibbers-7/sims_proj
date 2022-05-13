﻿#pragma checksum "..\..\..\DoctorHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99C8C13A1FD12A2F6D03D43C777D462C354446FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Zdravo;
using Zdravo.ViewModel;


namespace Zdravo {
    
    
    /// <summary>
    /// DoctorHome
    /// </summary>
    public partial class DoctorHome : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 85 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hour_tb;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minutes_tb;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox date_tb;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AppointmentTable;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton vacationRadio;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton sickLeaveRadio;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox reason_tb;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox startDate_tb;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox endDate_tb;
        
        #line default
        #line hidden
        
        
        #line 238 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Schedule;
        
        #line default
        #line hidden
        
        
        #line 250 "..\..\..\DoctorHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.TextBlock myDateTime;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zdravo;component/doctorhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorHome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\DoctorHome.xaml"
            ((Zdravo.DoctorHome)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 54 "..\..\..\DoctorHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 64 "..\..\..\DoctorHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Referral_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.hour_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.minutes_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.date_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 132 "..\..\..\DoctorHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 133 "..\..\..\DoctorHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AppointmentTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            
            #line 180 "..\..\..\DoctorHome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogoutButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.vacationRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this.sickLeaveRadio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 14:
            this.reason_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.startDate_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.endDate_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.Schedule = ((System.Windows.Controls.Button)(target));
            
            #line 238 "..\..\..\DoctorHome.xaml"
            this.Schedule.Click += new System.Windows.RoutedEventHandler(this.VacationButton_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.myDateTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 10:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 176 "..\..\..\DoctorHome.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.Row_DoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

