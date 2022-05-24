﻿#pragma checksum "..\..\..\..\DoctorView\NewAppointment.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D3133FB348CCB1387219BCE24FAA71F923A9CBC9"
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


namespace Zdravo {
    
    
    /// <summary>
    /// NewAppointment
    /// </summary>
    public partial class NewAppointment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientId_tb;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox emergency_cb;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button patientButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Schedule;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox date_tb;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox minutes_tb;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hour_tb;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox duration_tb;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\DoctorView\NewAppointment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox rooms_cb;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zdravo;component/doctorview/newappointment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DoctorView\NewAppointment.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.patientId_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.emergency_cb = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.patientButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\DoctorView\NewAppointment.xaml"
            this.patientButton.Click += new System.Windows.RoutedEventHandler(this.Patient_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Schedule = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\DoctorView\NewAppointment.xaml"
            this.Schedule.Click += new System.Windows.RoutedEventHandler(this.ScheduleButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 81 "..\..\..\..\DoctorView\NewAppointment.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.date_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.minutes_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.hour_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.duration_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.rooms_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

