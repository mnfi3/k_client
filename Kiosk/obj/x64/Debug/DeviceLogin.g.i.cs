﻿#pragma checksum "..\..\..\DeviceLogin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7A824B0471B8617BDCF24327CC270EF6C2484602"
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Kiosk {
    
    
    /// <summary>
    /// DeviceLogin
    /// </summary>
    public partial class DeviceLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_next;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_logout;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_device_name;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_device_user_name;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_client_key;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_login;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_user_name;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txt_password;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\DeviceLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kiosk;component/devicelogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DeviceLogin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\DeviceLogin.xaml"
            ((Kiosk.DeviceLogin)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_next = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\..\DeviceLogin.xaml"
            this.btn_next.Click += new System.Windows.RoutedEventHandler(this.btn_next_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\DeviceLogin.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_logout = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\DeviceLogin.xaml"
            this.btn_logout.Click += new System.Windows.RoutedEventHandler(this.btn_logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_device_name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txt_device_user_name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.txt_client_key = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.grd_login = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.txt_user_name = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\DeviceLogin.xaml"
            this.txt_user_name.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txt_user_name_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_password = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 33 "..\..\..\DeviceLogin.xaml"
            this.txt_password.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txt_password_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_login = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\DeviceLogin.xaml"
            this.btn_login.Click += new System.Windows.RoutedEventHandler(this.btn_login_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

