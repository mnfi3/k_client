﻿#pragma checksum "..\..\ListProducts.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "508A4694AAD7DCBAAF6FF31381F0CE38"
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
        
        
        #line 23 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_main;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_cart;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_products;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grd_category;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_categories;
        
        #line default
        #line hidden
        
        
        #line 252 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back_to_restaurants;
        
        #line default
        #line hidden
        
        
        #line 253 "..\..\ListProducts.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cart;
        
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
            
            #line 1 "..\..\ListProducts.xaml"
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
            
            #line 9 "..\..\ListProducts.xaml"
            ((Kiosk.ListProducts)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\ListProducts.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.grd_main = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.lst_cart = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.lst_products = ((System.Windows.Controls.ListView)(target));
            
            #line 132 "..\..\ListProducts.xaml"
            this.lst_products.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_products_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grd_category = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.lst_categories = ((System.Windows.Controls.ListView)(target));
            
            #line 188 "..\..\ListProducts.xaml"
            this.lst_categories.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_categories_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_back_to_restaurants = ((System.Windows.Controls.Button)(target));
            
            #line 252 "..\..\ListProducts.xaml"
            this.btn_back_to_restaurants.Click += new System.Windows.RoutedEventHandler(this.btn_back_to_restaurants_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_cart = ((System.Windows.Controls.Button)(target));
            
            #line 253 "..\..\ListProducts.xaml"
            this.btn_cart.Click += new System.Windows.RoutedEventHandler(this.btn_cart_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

