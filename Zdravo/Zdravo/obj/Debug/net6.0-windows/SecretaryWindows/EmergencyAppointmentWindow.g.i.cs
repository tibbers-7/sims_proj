﻿#pragma checksum "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6AF03D2D9CF027C1B4639684EACF3286B54E2BBA"
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
using Zdravo.SecretaryWindows;


namespace Zdravo.SecretaryWindows {
    
    
    /// <summary>
    /// EmergencyAppointmentWindow
    /// </summary>
    public partial class EmergencyAppointmentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jmbgTextBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label foundLabel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createAccountButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxSpecializations;
        
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
            System.Uri resourceLocater = new System.Uri("/Zdravo;V1.0.0.0;component/secretarywindows/emergencyappointmentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.jmbgTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
            this.jmbgTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.jmbgChangedEvent);
            
            #line default
            #line hidden
            return;
            case 2:
            this.foundLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.createAccountButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
            this.createAccountButton.Click += new System.Windows.RoutedEventHandler(this.createAccountClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.comboBoxSpecializations = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 27 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.okButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 28 "..\..\..\..\SecretaryWindows\EmergencyAppointmentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

