﻿#pragma checksum "..\..\..\..\DoctorView\ReferralWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B02CD9027CB31A28B23EA111F367B1067D6502A9"
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
using Zdravo.DoctorView;
using Zdravo.ViewModel;


namespace Zdravo.DoctorView {
    
    
    /// <summary>
    /// ReferralWindow
    /// </summary>
    public partial class ReferralWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientId_tb;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button patientButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctorSpecialization_cb;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton surgery_rb;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton appt_tb;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox emergency_cb;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\DoctorView\ReferralWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Schedule;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zdravo;component/doctorview/referralwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DoctorView\ReferralWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
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
            this.patientButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\DoctorView\ReferralWindow.xaml"
            this.patientButton.Click += new System.Windows.RoutedEventHandler(this.PatientButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.doctorSpecialization_cb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.surgery_rb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.appt_tb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            
            #line 65 "..\..\..\..\DoctorView\ReferralWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.emergency_cb = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.Schedule = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\DoctorView\ReferralWindow.xaml"
            this.Schedule.Click += new System.Windows.RoutedEventHandler(this.ScheduleButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

