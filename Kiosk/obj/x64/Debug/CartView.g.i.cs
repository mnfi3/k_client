﻿#pragma checksum "..\..\..\CartView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E0A02779B3AD5764394758F401B662F2A4E166DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
    /// CartView
    /// </summary>
    public partial class CartView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_main;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_pay;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_pay;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_payment;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back_to_restaurants;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_cost;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_d_cost;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border grd_discount;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_discount_code;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_discount;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_products;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\CartView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_cart;
        
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
            System.Uri resourceLocater = new System.Uri("/Kiosk;component/cartview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CartView.xaml"
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
            
            #line 8 "..\..\..\CartView.xaml"
            ((Kiosk.CartView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grd_main = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.grd_pay = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btn_pay = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\CartView.xaml"
            this.btn_pay.Click += new System.Windows.RoutedEventHandler(this.btn_pay_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grd_payment = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.btn_back_to_restaurants = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\CartView.xaml"
            this.btn_back_to_restaurants.Click += new System.Windows.RoutedEventHandler(this.btn_back_to_restaurants_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_cost = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.txt_d_cost = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.grd_discount = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.txt_discount_code = ((System.Windows.Controls.TextBox)(target));
            
            #line 85 "..\..\..\CartView.xaml"
            this.txt_discount_code.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.txt_discount_code_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_discount = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\CartView.xaml"
            this.btn_discount.Click += new System.Windows.RoutedEventHandler(this.btn_discount_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.grd_products = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.lst_cart = ((System.Windows.Controls.ListView)(target));
            
            #line 111 "..\..\..\CartView.xaml"
            this.lst_cart.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_cart_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

