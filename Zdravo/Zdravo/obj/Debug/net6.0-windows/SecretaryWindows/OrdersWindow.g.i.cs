﻿#pragma checksum "..\..\..\..\SecretaryWindows\OrdersWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC2897BD3E19A05A7173A83D887C8B61CD6175FE"
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
    /// OrdersWindow
    /// </summary>
    public partial class OrdersWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid table;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox quantityTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox noteTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Zdravo;V1.0.0.0;component/secretarywindows/orderswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
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
            this.table = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            
            #line 29 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitOrderClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 30 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.quantityTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.noteTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 38 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.ActiveClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 39 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.AllClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 22 "..\..\..\..\SecretaryWindows\OrdersWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NoteClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

