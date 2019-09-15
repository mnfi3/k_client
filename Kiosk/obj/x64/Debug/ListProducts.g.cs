﻿#pragma checksum "..\..\..\ListProducts.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31274767883E36B9147A7E836049415E57D48E54"
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
    /// ListProducts
    /// </summary>
    public partial class ListProducts : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition cln_cart;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_cart;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_total;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_checkout;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_category_name;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back_to_restaurants;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_products;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PopupBox btn_setting;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_category;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_categories;
        
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
            System.Uri resourceLocater = new System.Uri("/Kiosk;component/listproducts.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ListProducts.xaml"
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
            
            #line 9 "..\..\..\ListProducts.xaml"
            ((Kiosk.ListProducts)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cln_cart = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.lst_cart = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.txt_total = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.btn_checkout = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\ListProducts.xaml"
            this.btn_checkout.Click += new System.Windows.RoutedEventHandler(this.btn_checkout_Click);
            
            #line default
            #line hidden
            
            #line 80 "..\..\..\ListProducts.xaml"
            this.btn_checkout.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.btn_checkout_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_category_name = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btn_back_to_restaurants = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\ListProducts.xaml"
            this.btn_back_to_restaurants.Click += new System.Windows.RoutedEventHandler(this.btn_back_to_restaurants_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lst_products = ((System.Windows.Controls.ListView)(target));
            
            #line 110 "..\..\..\ListProducts.xaml"
            this.lst_products.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_products_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_setting = ((MaterialDesignThemes.Wpf.PopupBox)(target));
            return;
            case 10:
            
            #line 163 "..\..\..\ListProducts.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 165 "..\..\..\ListProducts.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.grd_category = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.lst_categories = ((System.Windows.Controls.ListView)(target));
            
            #line 173 "..\..\..\ListProducts.xaml"
            this.lst_categories.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_categories_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

