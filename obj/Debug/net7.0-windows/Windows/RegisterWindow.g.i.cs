﻿#pragma checksum "..\..\..\..\Windows\RegisterWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0973B15C99B056A3065DFB729FC9C4ED22CD0927"
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
using TravelPal_Newton.Windows;


namespace TravelPal_Newton.Windows {
    
    
    /// <summary>
    /// RegisterWindow
    /// </summary>
    public partial class RegisterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RegisterGrid;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRequestedUsername;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRequestedPassword;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCountry;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSignUpReady;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxCountry;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblregisterFeedback;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Windows\RegisterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TravelPal-Newton;component/windows/registerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\RegisterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RegisterGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtRequestedUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtRequestedPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lblCountry = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.BtnSignUpReady = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\Windows\RegisterWindow.xaml"
            this.BtnSignUpReady.Click += new System.Windows.RoutedEventHandler(this.BtnSignUpReady_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ComboBoxCountry = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.lblregisterFeedback = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.btnGo = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\..\Windows\RegisterWindow.xaml"
            this.btnGo.Click += new System.Windows.RoutedEventHandler(this.btnGo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

